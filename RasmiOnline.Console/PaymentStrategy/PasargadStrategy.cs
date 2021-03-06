﻿namespace RasmiOnline.Console.PaymentStrategy
{
    using System;
    using ZarinPal;
    using Properties;
    using System.Web;
    using Domain.Dto;
    using Domain.Enum;
    using System.Text;
    using Domain.Entity;
    using Newtonsoft.Json;
    using System.Net.Http;
    using Business.Protocol;
    using Gnu.Framework.Core;
    using Business.Observers;
    using DependencyResolver.Ioc;
    using System.Net.Http.Headers;
    using Gnu.Framework.Core.Log;
    using System.Security.Cryptography;
    using Gnu.Framework.Core.Authentication;

    public class PasargadStrategy : IPaymentStrategy
    {
        readonly PaymentGatewayImplementationServicePortTypeClient _zarinPal;
        readonly IUserBusiness _userBusiness;
        readonly ITransactionBusiness _transactionBusiness;
        readonly IOrderBusiness _orderBusiness;
        readonly Lazy<ISmsTemplateBusiness> _smsTemplateBusiness;
        readonly Lazy<IObserverManager> _observerManager;
        public PasargadStrategy()
        {
            _zarinPal = new PaymentGatewayImplementationServicePortTypeClient();
            _userBusiness = IocInitializer.GetInstance<IUserBusiness>();
            _transactionBusiness = IocInitializer.GetInstance<ITransactionBusiness>();
            _orderBusiness = IocInitializer.GetInstance<IOrderBusiness>();
            _observerManager = IocInitializer.GetInstance<Lazy<IObserverManager>>();
            _smsTemplateBusiness = IocInitializer.GetInstance<Lazy<ISmsTemplateBusiness>>();
        }
        public string GetSign(string data)
        {
            var cs = new CspParameters { KeyContainerName = "PaymentTest" };
            cs.Flags = CspProviderFlags.UseMachineKeyStore;
            var rsa = new RSACryptoServiceProvider(cs) { PersistKeyInCsp = false };
            rsa.Clear();
            rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(@"<RSAKeyValue><Modulus>l3/3pY/dp1/Brpr4N1RVnmmrFDxXyVcT81p5QnmaPUR7D0XORHCxf8aSa0yFUIBV9hkHvcjBg52H3sxpQc7QUjTi3fWgcszf/mU96+jFBImx/bJy0CJr8LoFQUpcc880xmHBNp3UO6uMX5IXAWG0ZSiIgHzYQ+g3pFfXY13RS48=</Modulus><Exponent>AQAB</Exponent><P>zeW4fMes29uwxkHc7vvbi3lWC6NargVh5c1Jtrt0jHqZpD5MNRtzkItAm3B5YeCzRRO0CyWKtheBY4t/bUFCfQ==</P><Q>vF2U1zhW1kycXDtl76KOBlKOfjQLPNGkkcPqMixTJx3KOSJqCKhArNIYgf1UBgU4bqchAxCuqM7TmyodGzF3+w==</Q><DP>O+CppUggYhPitdVjnfCKqWYQ+vN3pJIWJVFtNYIQY+YnllczrGIeWpPUpx+vfSJuoBEZ1AAH9eqiC0P/O9O1tQ==</DP><DQ>Sxxx3oQ7tEZmTyzsT+sdAQ5ofZCZLo5WNj3OJGWiXsW1PqUnbP5Sk9dPKH5ww9nPD+ia9FLxoqSeoo/ffVlzgw==</DQ><InverseQ>Q11pTeLrqvkedc3hltnPvRn10WJXrdfeJvwE5HyHnB5w0LS1g19J/FrtKvUNgcb1mSOjnqdmmdexel8hp280ng==</InverseQ><D>HI5ZXpKkhATvm/rH6J3z2X0vawwIvAG21/roulfzc7Lxwyo0PABF5MDIHoN46XiXO2DybZpmp2lND/jVqjrSVzIiC3/7npWZpEbhy7sHFdS+QWW/DaFWZ2WJPHBvLnWx33v2OJxi4TQqlvvsXMisW4ZhsfuTfYrukZdKX5EeVxk=</D></RSAKeyValue>");
            byte[] signMain = rsa.SignData(Encoding.UTF8.GetBytes(data), new
            SHA1CryptoServiceProvider());
            string sign = Convert.ToBase64String(signMain);
            return sign;
        }

        private string CreateTimeSpan(DateTime dt)
        {
            var month = dt.Month < 10 ? "0" + dt.Month.ToString() : dt.Month.ToString();
            var day = dt.Day < 10 ? "0" + dt.Day.ToString() : dt.Day.ToString();
            var h = dt.Hour < 10 ? "0" + dt.Hour.ToString() : dt.Hour.ToString();
            var m = dt.Minute < 10 ? "0" + dt.Minute.ToString() : dt.Minute.ToString();
            var s = dt.Second < 10 ? "0" + dt.Second.ToString() : dt.Second.ToString();
            return $"{dt.Year}/{month}/{day} {h}:{m}:{s}";
        }

        public IActionResponse<string> Do(PaymentGateway gateway, TransactionModel model)
        {
            try
            {
                var currentUser = _userBusiness.Find(model.UserId);
                if (currentUser == null)
                {
                    return new ActionResponse<string>()
                    {
                        Message = LocalMessage.UsernameIsWrong
                    };
                }
                var transaction = new Transaction
                {
                    OrderId = model.OrderId,
                    Price = model.Price,
                    PaymentGatewayId = model.PaymentGatewayId,
                    Authority = "100",
                    Status = "100",
                    TrackingId = model.PaymentGatewayId.ToString(),
                    InsertDateMi = DateTime.Now,
                    InsertDateSh = PersianDateTime.Now.ToString(PersianDateTimeFormat.Date)
                };
                var doTransaction = _transactionBusiness.Do(transaction);
                if (!doTransaction.IsSuccessful)
                    return new ActionResponse<string>
                    {
                        IsSuccessful = false,
                        Message = LocalMessage.Exception
                    };
                var dataModel = new
                {
                    InvoiceNumber = transaction.TransactionId.ToString(),
                    InvoiceDate = transaction.InsertDateSh,
                    TerminalCode = int.Parse(gateway.Username),
                    MerchantCode = int.Parse(gateway.Password),
                    Amount = Convert.ToDecimal(model.Price),
                    RedirectAddress = AppSettings.TransactionRedirectUrl_Pasargad,
                    Timestamp = CreateTimeSpan(transaction.InsertDateMi),
                    Action = "1003",
                    Mobile = currentUser.MobileNumber,
                    currentUser.Email
                };
                var data = JsonConvert.SerializeObject(dataModel);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var requestMessage = new HttpRequestMessage
                {
                    RequestUri = new Uri("https://pep.shaparak.ir/Api/v1/Payment/GetToken"),
                    Method = HttpMethod.Post,
                    Content = content
                };
                requestMessage.Headers.Add("Sign", GetSign(data));
                var client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.SendAsync(requestMessage).Result;
                var deserializeResponse = JsonConvert.DeserializeObject<PasargadGetTokenReponse>(Encoding.UTF8.GetString(response.Content.ReadAsByteArrayAsync().Result));
                if (deserializeResponse.IsSuccess)
                    return new ActionResponse<string>
                    {
                        IsSuccessful = true,
                        Result = $"https://pep.shaparak.ir/payment.aspx?n={deserializeResponse.Token}"
                        //Result = transaction.TransactionId.ToString()
                    };
                else return new ActionResponse<string>
                {
                    IsSuccessful = false,
                    Message = deserializeResponse.Message
                };
            }
            catch (Exception e)
            {
                FileLoger.Error(e);
                return new ActionResponse<string>
                {
                    IsSuccessful = false,
                    Message = LocalMessage.Error
                };
            }
        }

        public IActionResponse<string> Verify(PaymentGateway gateway, Transaction model, object responseGateway = null)
        {
            try
            {
                var deserializeCheckingResponse = new PasargadCheckResponse();
                if (responseGateway == null)
                    return new ActionResponse<string>
                    {
                        IsSuccessful = false,
                        Message = "عملیات پرداخت از سمت درگاه تایید نشد، لطفا مجددا عملیات پرداخت را تکرار نمایید",
                    };
                #region Checking
                using (HttpClient chkHttp = new HttpClient())
                {
                    var checkingSerilizedModel = JsonConvert.SerializeObject(new
                    {
                        InvoiceNumber = model.TransactionId.ToString(),
                        InvoiceDate = model.InsertDateSh,
                        TerminalCode = int.Parse(gateway.Username),
                        MerchantCode = int.Parse(gateway.Password),
                        TransactionReferenceID = (string)responseGateway
                    });
                    var checkingContent = new StringContent(checkingSerilizedModel, Encoding.UTF8, "application/json");
                    var chkResponse = chkHttp.PostAsync("https://pep.shaparak.ir/Api/v1/Payment/CheckTransactionResult", checkingContent).Result;
                    //FileLoger.Info("deserializeCheckingResponse : " + Encoding.UTF8.GetString(chkResponse.Content.ReadAsByteArrayAsync().Result));
                    deserializeCheckingResponse = JsonConvert.DeserializeObject<PasargadCheckResponse>(Encoding.UTF8.GetString(chkResponse.Content.ReadAsByteArrayAsync().Result));
                }
                #endregion
                if (deserializeCheckingResponse.IsSuccess)
                {
                    var deserializeResponse = new PasargadVerifyResponse();
                    using (HttpClient verifyHttp = new HttpClient())
                    {
                        var verifyModel = new
                        {
                            InvoiceNumber = model.TransactionId.ToString(),
                            InvoiceDate = model.InsertDateSh,
                            TerminalCode = int.Parse(gateway.Username),
                            MerchantCode = int.Parse(gateway.Password),
                            deserializeCheckingResponse.Amount,
                            TimeStamp = CreateTimeSpan(DateTime.Now)
                        };
                        var verifyContent = new StringContent(JsonConvert.SerializeObject(verifyModel), Encoding.UTF8, "application/json");
                        var requestMessage = new HttpRequestMessage
                        {
                            RequestUri = new Uri("https://pep.shaparak.ir/Api/v1/Payment/VerifyPayment"),
                            Method = HttpMethod.Post,
                            Content = verifyContent
                        };
                        var data = JsonConvert.SerializeObject(verifyModel);
                        requestMessage.Headers.Add("Sign", GetSign(data));
                        verifyHttp.DefaultRequestHeaders.Accept.Add(new
                        MediaTypeWithQualityHeaderValue("application/json"));
                        var response = verifyHttp.SendAsync(requestMessage).Result;
                        //FileLoger.Info("verifyResponse : " + Encoding.UTF8.GetString(response.Content.ReadAsByteArrayAsync().Result));
                        deserializeResponse = JsonConvert.DeserializeObject<PasargadVerifyResponse>(Encoding.UTF8.GetString(response.Content.ReadAsByteArrayAsync().Result));
                    }
                    if (deserializeResponse.IsSuccess)
                    {
                        model.IsSuccess = true;
                        model.TrackingId = responseGateway.ToString();
                        model.Status = "1";
                        if (model.OrderId != 0)
                        {
                            if (_transactionBusiness.GetTotalPayedPrice(model.OrderId) == 0)
                                _orderBusiness.UpdateStatus(model.OrderId);
                            else _orderBusiness.UpdateStatus(model.OrderId, OrderStatus.DeliveryFiles);
                        }

                        _transactionBusiness.Update(model);

                        _observerManager.Value.Notify(ConcreteKey.Success_Payment, new ObserverMessage
                        {
                            SmsContent = string.Format(_smsTemplateBusiness.Value.GetText(MessagingType.Sms, ConcreteKey.Success_Payment), model.OrderId, model.Price.ToString("N0") + LocalMessage.MoneyCurrency),
                            //string.Format(LocalMessage.Transaction_Add_Sms, (HttpContext.Current.User as ICurrentUserPrincipal).FullName, model.OrderId),
                            BotContent = string.Format(_smsTemplateBusiness.Value.GetText(MessagingType.RoboTele, ConcreteKey.Success_Payment), (HttpContext.Current.User as ICurrentUserPrincipal).FullName,
                                                    model.OrderId, gateway.BankName.GetLocalizeDescription(),
                                                    model.Price.ToString("0,0"),
                                                    model.TrackingId),
                            //string.Format(LocalMessage.Transaction_Add_Bot, (HttpContext.Current.User as ICurrentUserPrincipal).FullName,
                            //                        model.OrderId, gateway.BankName.GetLocalizeDescription(),
                            //                        model.Price.ToString("0,0"),
                            //                        model.TrackingId),
                            Key = nameof(Transaction),
                            UserId = (HttpContext.Current.User as ICurrentUserPrincipal).UserId,
                        });
                        return new ActionResponse<string>
                        {
                            IsSuccessful = true,
                            Message = "عملیات پرداخت با موفقیت انجام شد",
                            Result = model.TrackingId.ToString()
                        };
                    }
                    //----------
                }
                model.IsSuccess = false;
                model.Status = "-1";
                _transactionBusiness.Update(model);
                return new ActionResponse<string>
                {
                    IsSuccessful = false,
                    Message = "عملیات پرداخت از سمت درگاه تایید نشد، لطفا مجددا عملیات پرداخت را تکرار نمایید",
                    Result = model.TrackingId.ToString()
                };

            }
            catch (Exception e)
            {
                FileLoger.Error(e);
                return new ActionResponse<string>
                {
                    IsSuccessful = false,
                    Message = "عملیات پرداخت از سمت درگاه تایید نشد، لطفا مجددا عملیات پرداخت را تکرار نمایید",
                    Result = model.TrackingId.ToString()
                };
            }
        }
    }
}