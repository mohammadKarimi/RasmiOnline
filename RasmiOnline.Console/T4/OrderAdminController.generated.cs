// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
// 0108: suppress "Foo hides inherited member Foo. Use the new keyword if hiding was intended." when a controller and its abstract parent are both processed
// 0114: suppress "Foo.BarController.Baz()' hides inherited member 'Qux.BarController.Baz()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword." when an action (with an argument) overrides an action in a parent controller
#pragma warning disable 1591, 3008, 3009, 0108, 0114
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace RasmiOnline.Console.Controllers
{
    public partial class OrderAdminController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected OrderAdminController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(Task<ActionResult> taskResult)
        {
            return RedirectToAction(taskResult.Result);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(Task<ActionResult> taskResult)
        {
            return RedirectToActionPermanent(taskResult.Result);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ViewResult Edit()
        {
            return new T4MVC_System_Web_Mvc_ViewResult(Area, Name, ActionNames.Edit);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.JsonResult Update()
        {
            return new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.Update);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.PartialViewResult GetOrderPaymentInfo()
        {
            return new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.GetOrderPaymentInfo);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public OrderAdminController Actions { get { return MVC.OrderAdmin; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "OrderAdmin";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "OrderAdmin";
        [GeneratedCode("T4MVC", "2.0")]
        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Add = "Add";
            public readonly string Edit = "Edit";
            public readonly string Update = "Update";
            public readonly string Manage = "Manage";
            public readonly string GetAllTodayOrderList = "GetAllTodayOrderList";
            public readonly string GetAllOlderOrderList = "GetAllOlderOrderList";
            public readonly string GetOrderPaymentInfo = "GetOrderPaymentInfo";
            public readonly string GetOrderList = "GetOrderList";
            public readonly string GetOrderListMobile = "GetOrderListMobile";
            public readonly string GetMobileOrderType = "GetMobileOrderType";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Add = "Add";
            public const string Edit = "Edit";
            public const string Update = "Update";
            public const string Manage = "Manage";
            public const string GetAllTodayOrderList = "GetAllTodayOrderList";
            public const string GetAllOlderOrderList = "GetAllOlderOrderList";
            public const string GetOrderPaymentInfo = "GetOrderPaymentInfo";
            public const string GetOrderList = "GetOrderList";
            public const string GetOrderListMobile = "GetOrderListMobile";
            public const string GetMobileOrderType = "GetMobileOrderType";
        }


        static readonly ActionParamsClass_Add s_params_Add = new ActionParamsClass_Add();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Add AddParams { get { return s_params_Add; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Add
        {
            public readonly string model = "model";
        }
        static readonly ActionParamsClass_Edit s_params_Edit = new ActionParamsClass_Edit();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Edit EditParams { get { return s_params_Edit; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Edit
        {
            public readonly string orderId = "orderId";
            public readonly string langType = "langType";
            public readonly string items = "items";
        }
        static readonly ActionParamsClass_Update s_params_Update = new ActionParamsClass_Update();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Update UpdateParams { get { return s_params_Update; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Update
        {
            public readonly string model = "model";
        }
        static readonly ActionParamsClass_GetOrderPaymentInfo s_params_GetOrderPaymentInfo = new ActionParamsClass_GetOrderPaymentInfo();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_GetOrderPaymentInfo GetOrderPaymentInfoParams { get { return s_params_GetOrderPaymentInfo; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_GetOrderPaymentInfo
        {
            public readonly string orderId = "orderId";
        }
        static readonly ActionParamsClass_GetOrderList s_params_GetOrderList = new ActionParamsClass_GetOrderList();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_GetOrderList GetOrderListParams { get { return s_params_GetOrderList; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_GetOrderList
        {
            public readonly string orderStatus = "orderStatus";
        }
        static readonly ActionParamsClass_GetOrderListMobile s_params_GetOrderListMobile = new ActionParamsClass_GetOrderListMobile();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_GetOrderListMobile GetOrderListMobileParams { get { return s_params_GetOrderListMobile; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_GetOrderListMobile
        {
            public readonly string orderStatus = "orderStatus";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string Add = "Add";
                public readonly string Edit = "Edit";
                public readonly string Edit_Mobile = "Edit.Mobile";
                public readonly string Manage = "Manage";
            }
            public readonly string Add = "~/Views/OrderAdmin/Add.cshtml";
            public readonly string Edit = "~/Views/OrderAdmin/Edit.cshtml";
            public readonly string Edit_Mobile = "~/Views/OrderAdmin/Edit.Mobile.cshtml";
            public readonly string Manage = "~/Views/OrderAdmin/Manage.cshtml";
            static readonly _PartialsClass s_Partials = new _PartialsClass();
            public _PartialsClass Partials { get { return s_Partials; } }
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public partial class _PartialsClass
            {
                static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
                public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
                public class _ViewNamesClass
                {
                    public readonly string _AddOrder = "_AddOrder";
                    public readonly string _AllTodayOrder = "_AllTodayOrder";
                    public readonly string _Factor = "_Factor";
                    public readonly string _ManageItem = "_ManageItem";
                    public readonly string _Order = "_Order";
                    public readonly string _OrderBoard = "_OrderBoard";
                    public readonly string _OrderBoardMobile = "_OrderBoardMobile";
                    public readonly string _OrderListView = "_OrderListView";
                    public readonly string _OrderListViewMobile = "_OrderListViewMobile";
                    public readonly string _OrderPaymentInfo = "_OrderPaymentInfo";
                }
                public readonly string _AddOrder = "~/Views/OrderAdmin/Partials/_AddOrder.cshtml";
                public readonly string _AllTodayOrder = "~/Views/OrderAdmin/Partials/_AllTodayOrder.cshtml";
                public readonly string _Factor = "~/Views/OrderAdmin/Partials/_Factor.cshtml";
                public readonly string _ManageItem = "~/Views/OrderAdmin/Partials/_ManageItem.cshtml";
                public readonly string _Order = "~/Views/OrderAdmin/Partials/_Order.cshtml";
                public readonly string _OrderBoard = "~/Views/OrderAdmin/Partials/_OrderBoard.cshtml";
                public readonly string _OrderBoardMobile = "~/Views/OrderAdmin/Partials/_OrderBoardMobile.cshtml";
                public readonly string _OrderListView = "~/Views/OrderAdmin/Partials/_OrderListView.cshtml";
                public readonly string _OrderListViewMobile = "~/Views/OrderAdmin/Partials/_OrderListViewMobile.cshtml";
                public readonly string _OrderPaymentInfo = "~/Views/OrderAdmin/Partials/_OrderPaymentInfo.cshtml";
            }
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_OrderAdminController : RasmiOnline.Console.Controllers.OrderAdminController
    {
        public T4MVC_OrderAdminController() : base(Dummy.Instance) { }

        [NonAction]
        partial void AddOverride(T4MVC_System_Web_Mvc_ViewResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ViewResult Add()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ViewResult(Area, Name, ActionNames.Add);
            AddOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void AddOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, RasmiOnline.Domain.Entity.Order model);

        [NonAction]
        public override System.Web.Mvc.JsonResult Add(RasmiOnline.Domain.Entity.Order model)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.Add);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            AddOverride(callInfo, model);
            return callInfo;
        }

        [NonAction]
        partial void EditOverride(T4MVC_System_Web_Mvc_ViewResult callInfo, int orderId);

        [NonAction]
        public override System.Web.Mvc.ViewResult Edit(int orderId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ViewResult(Area, Name, ActionNames.Edit);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "orderId", orderId);
            EditOverride(callInfo, orderId);
            return callInfo;
        }

        [NonAction]
        partial void EditOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, int orderId, RasmiOnline.Domain.Enum.LangType langType, System.Collections.Generic.List<RasmiOnline.Domain.Entity.OrderItem> items);

        [NonAction]
        public override System.Web.Mvc.JsonResult Edit(int orderId, RasmiOnline.Domain.Enum.LangType langType, System.Collections.Generic.List<RasmiOnline.Domain.Entity.OrderItem> items)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.Edit);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "orderId", orderId);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "langType", langType);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "items", items);
            EditOverride(callInfo, orderId, langType, items);
            return callInfo;
        }

        [NonAction]
        partial void UpdateOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, RasmiOnline.Domain.Entity.Order model);

        [NonAction]
        public override System.Web.Mvc.JsonResult Update(RasmiOnline.Domain.Entity.Order model)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.Update);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            UpdateOverride(callInfo, model);
            return callInfo;
        }

        [NonAction]
        partial void ManageOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Manage()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Manage);
            ManageOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void GetAllTodayOrderListOverride(T4MVC_System_Web_Mvc_PartialViewResult callInfo);

        [NonAction]
        public override System.Web.Mvc.PartialViewResult GetAllTodayOrderList()
        {
            var callInfo = new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.GetAllTodayOrderList);
            GetAllTodayOrderListOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void GetAllOlderOrderListOverride(T4MVC_System_Web_Mvc_PartialViewResult callInfo);

        [NonAction]
        public override System.Web.Mvc.PartialViewResult GetAllOlderOrderList()
        {
            var callInfo = new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.GetAllOlderOrderList);
            GetAllOlderOrderListOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void GetOrderPaymentInfoOverride(T4MVC_System_Web_Mvc_PartialViewResult callInfo, int orderId);

        [NonAction]
        public override System.Web.Mvc.PartialViewResult GetOrderPaymentInfo(int orderId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.GetOrderPaymentInfo);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "orderId", orderId);
            GetOrderPaymentInfoOverride(callInfo, orderId);
            return callInfo;
        }

        [NonAction]
        partial void GetOrderListOverride(T4MVC_System_Web_Mvc_PartialViewResult callInfo, RasmiOnline.Domain.Enum.OrderStatus? orderStatus);

        [NonAction]
        public override System.Web.Mvc.PartialViewResult GetOrderList(RasmiOnline.Domain.Enum.OrderStatus? orderStatus)
        {
            var callInfo = new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.GetOrderList);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "orderStatus", orderStatus);
            GetOrderListOverride(callInfo, orderStatus);
            return callInfo;
        }

        [NonAction]
        partial void GetOrderListMobileOverride(T4MVC_System_Web_Mvc_PartialViewResult callInfo, RasmiOnline.Domain.Enum.OrderStatus? orderStatus);

        [NonAction]
        public override System.Web.Mvc.PartialViewResult GetOrderListMobile(RasmiOnline.Domain.Enum.OrderStatus? orderStatus)
        {
            var callInfo = new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.GetOrderListMobile);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "orderStatus", orderStatus);
            GetOrderListMobileOverride(callInfo, orderStatus);
            return callInfo;
        }

        [NonAction]
        partial void GetMobileOrderTypeOverride(T4MVC_System_Web_Mvc_PartialViewResult callInfo);

        [NonAction]
        public override System.Web.Mvc.PartialViewResult GetMobileOrderType()
        {
            var callInfo = new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.GetMobileOrderType);
            GetMobileOrderTypeOverride(callInfo);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
