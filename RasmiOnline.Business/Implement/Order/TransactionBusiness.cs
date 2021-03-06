﻿namespace RasmiOnline.Business.Implement
{
    using System;
    using Protocol;
    using Properties;
    using System.Web;
    using Observers;
    using Domain.Dto;
    using System.Linq;
    using Domain.Enum;
    using Domain.Entity;
    using Gnu.Framework.Core;
    using System.Data.Entity;
    using System.Collections.Generic;
    using Gnu.Framework.EntityFramework;
    using Gnu.Framework.Core.Authentication;
    using Gnu.Framework.EntityFramework.DataAccess;

    public class TransactionBusiness : ITransactionBusiness
    {
        #region Constructor
        readonly IUnitOfWork _uow;
        readonly IDbSet<Transaction> _transaction;
        readonly IOrderBusiness _orderBusiness;
        readonly Lazy<ISmsTemplateBusiness> _smsTemplateBusiness;
        readonly Lazy<IObserverManager> _observerManager;
        readonly IPaymentGatewayBusiness _paymentGatewayBusiness;

        public TransactionBusiness(IUnitOfWork uow,
            IOrderBusiness orderBusiness,
            Lazy<IObserverManager> observerManager,
            IPaymentGatewayBusiness paymentGatewayBusiness,
            Lazy<ISmsTemplateBusiness> smsTemplateBusiness)
        {
            _observerManager = observerManager;
            _uow = uow;
            _transaction = _uow.Set<Transaction>();
            _orderBusiness = orderBusiness;
            _paymentGatewayBusiness = paymentGatewayBusiness;
            _smsTemplateBusiness = smsTemplateBusiness;
        }
        #endregion


        public IEnumerable<TransactionDetails> GetDetail(int orderId)
        {
            return (from lj in (from tr in _transaction
                                join cr in _uow.Set<BankCard>() on tr.BankCardId equals cr.BankCardId into lj
                                from leftCr in lj.DefaultIfEmpty()
                                select new { leftCr, tr })
                    join gw in _uow.Set<PaymentGateway>() on lj.tr.PaymentGatewayId equals gw.PaymentGatewayId
                    where lj.tr.OrderId == orderId
                    select new TransactionDetails
                    {
                        TrackingId = lj.tr.TrackingId,
                        Price = lj.tr.Price,
                        InsertDateSh = lj.tr.InsertDateSh,
                        InsertDateMi = lj.tr.InsertDateMi,
                        PaymentGatewayName = gw.Name,
                        IsSuccess = lj.tr.IsSuccess,
                        PaymentGatewayId = lj.tr.PaymentGatewayId,
                        Description = lj.tr.Description,
                        OrderId = lj.tr.OrderId,
                        TransactionId = lj.tr.TransactionId,
                        BankCard = lj.leftCr.Title
                    }).AsNoTracking().ToList();
        }

        /// <summary>
        /// Add Transaction With Task State in Processing
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IActionResponse<Transaction> Do(Transaction model)
        {
            var result = new ActionResponse<Transaction>();
            _transaction.Add(model);
            var saveChange = _uow.SaveChanges();
            result.Result = model;
            result.IsSuccessful = saveChange.ToSaveChangeResult();
            result.Message = saveChange.ToSaveChangeMessageResult(BusinessMessage.Success, BusinessMessage.Error);
            return result;
        }

        /// <summary>
        /// Update Transaction
        /// Is This Transaction Is Success Then Add A Ticket
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IActionResponse<int> Update(Transaction model)
        {
            var result = new ActionResponse<int>();

            _uow.Entry(model).State = EntityState.Modified;
            var saveChange = _uow.SaveChanges();
            result.Result = model.TransactionId;
            result.IsSuccessful = saveChange.ToSaveChangeResult();
            result.Message = saveChange.ToSaveChangeMessageResult(BusinessMessage.Success, BusinessMessage.Error);

            return result;
        }

        public Transaction Find(string authority) => _transaction.FirstOrDefault(X => X.Authority == authority);

        public Transaction Find(int transactionId) => _transaction.Include(x => x.Order).FirstOrDefault(X => X.TransactionId == transactionId);

        public Transaction FindDetails(int transactionId) => _transaction.Include(x => x.Order).Include(x => x.Order.User).FirstOrDefault(X => X.TransactionId == transactionId);

        public IActionResponse<int> Insert(Transaction model)
        {
            var result = new ActionResponse<int>();
            model.Authority = "2";
            model.Status = "2";
            model.InsertDateMi = PersianDateTime.Parse(model.InsertDateSh).ToDateTime();

            _transaction.Add(model);
            var saveChange = _uow.SaveChanges();
            if (saveChange.ToSaveChangeResult())
            {
                _orderBusiness.UpdateOrderDeliverFiles(model.OrderId);
                var pg = _paymentGatewayBusiness.Find(model.PaymentGatewayId);

                _observerManager.Value.Notify(ConcreteKey.Offline_Payment, new ObserverMessage
                {
                    SmsContent = string.Format(_smsTemplateBusiness.Value.GetText(MessagingType.Sms, ConcreteKey.Offline_Payment), model.OrderId, model.Price.ToString("N0") + BusinessMessage.MoneyCurrency),
                    BotContent = string.Format(_smsTemplateBusiness.Value.GetText(MessagingType.RoboTele, ConcreteKey.Offline_Payment), (HttpContext.Current.User as ICurrentUserPrincipal).FullName,
                                               model.OrderId, pg.PaymentGatewayType.GetLocalizeDescription(),
                                               model.Price.ToString("0,0"),
                                               model.TrackingId.ToString(),
                                               PersianDateTime.Now.ToString(PersianDateTimeFormat.FullDateFullTime)),
                    Key = nameof(Transaction),
                    UserId = (HttpContext.Current.User as ICurrentUserPrincipal).UserId,
                });
            }
            result.Result = model.TransactionId;
            result.IsSuccessful = saveChange.ToSaveChangeResult();
            result.Message = saveChange.ToSaveChangeMessageResult(BusinessMessage.Success, BusinessMessage.Error);
            return result;
        }

        public int AllUnReadPaymentCount() => _transaction.Count(X => !X.IsAdminRead && X.IsSuccess);

        public IEnumerable<Transaction> AllUnReadPayment() => _transaction.Where(X => X.IsSuccess && !X.IsAdminRead).AsNoTracking().ToList();

        public IActionResponse<int> Read(int transactionId, bool isOffice)
        {
            var transaction = _transaction.Find(transactionId);
            if (transaction == null)
                return new ActionResponse<int>
                {
                    Message = BusinessMessage.RecordNotFound
                };
            if (isOffice)
            {
                transaction.IsOfficeRead = true;
            }
            else
            {
                transaction.IsAdminRead = true;
            }
            var dbResult = _uow.SaveChanges();
            return new ActionResponse<int>
            {
                IsSuccessful = dbResult.ToSaveChangeResult()
            };
        }

        public int AllUnReadOfficePaymentCount(Guid officeUserId)
        {
            return (from tr in _transaction
                    join or in _uow.Set<Order>() on tr.OrderId equals or.OrderId
                    where or.OfficeUserId == officeUserId && tr.IsSuccess && !tr.IsOfficeRead
                    select tr.TransactionId).Count();
        }

        public IEnumerable<Transaction> AllUnReadOfficePayment(Guid officeUserId)
        {
            return (from tr in _transaction
                    join or in _uow.Set<Order>() on tr.OrderId equals or.OrderId
                    where or.OfficeUserId == officeUserId && tr.IsSuccess && !tr.IsOfficeRead
                    select tr).ToList();
        }

        public IActionResponse<int> Remove(int orderId, int transactionId)
        {
            var transaction = _transaction.Find(transactionId);
            if (transaction == null)
                return new ActionResponse<int>
                {
                    Message = BusinessMessage.RecordNotFound
                };
            _transaction.Remove(transaction);
            var dbResult = _uow.SaveChanges();
            return new ActionResponse<int>
            {
                IsSuccessful = dbResult.ToSaveChangeResult()
            };
        }

        public int GetTotalPayedPrice(int orderId) => _transaction.Where(x => x.OrderId == orderId && x.IsSuccess).Select(x => x.Price).ToList().Sum();

        public IActionResponse<List<Transaction>> Get(TransactionSearchFilter filterModel)
        {
            var response = new ActionResponse<List<Transaction>>();
            var q = _transaction.AsNoTracking().AsQueryable();
            if (filterModel.OrderId != null)
                q = q.Where(x => x.OrderId == filterModel.OrderId);
            if (!string.IsNullOrWhiteSpace(filterModel.MobileNumber))
            {
                long mobNum = 0;
                if (long.TryParse(filterModel.MobileNumber, out mobNum))
                    q = q.Where(x => x.Order.User.MobileNumber == mobNum);
            }
            if (filterModel.PaymentGatewayId != null)
                q = q.Where(x => x.PaymentGatewayId == filterModel.PaymentGatewayId);
            if (filterModel.Status != null)
                q = q.Where(x => x.Status == filterModel.Status);
            if (!string.IsNullOrWhiteSpace(filterModel.TrackingId))
                q = q.Where(x => x.TrackingId.Contains(filterModel.TrackingId));
            if (!string.IsNullOrWhiteSpace(filterModel.FromDateSh))
                q = q.Where(x => x.InsertDateSh.CompareTo(filterModel.FromDateSh) >= 0);
            if (!string.IsNullOrWhiteSpace(filterModel.FromDateSh))
                q = q.Where(x => x.InsertDateSh.CompareTo(filterModel.ToDateSh) <= 0);
            response.Result = q.OrderByDescending(x => x.TransactionId)
                         .Take(filterModel.ItemsCount)
                         .ToList();
            return response;
        }
    }
}
