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
    public partial class SettingController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected SettingController(Dummy d) { }

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
        public virtual System.Web.Mvc.JsonResult SubmitChange()
        {
            return new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.SubmitChange);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.JsonResult SendAddressTo()
        {
            return new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.SendAddressTo);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public SettingController Actions { get { return MVC.Setting; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Setting";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Setting";
        [GeneratedCode("T4MVC", "2.0")]
        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Manage = "Manage";
            public readonly string SubmitChange = "SubmitChange";
            public readonly string GetSupportNumber = "GetSupportNumber";
            public readonly string SendAddressTo = "SendAddressTo";
            public readonly string GetNotification = "GetNotification";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Manage = "Manage";
            public const string SubmitChange = "SubmitChange";
            public const string GetSupportNumber = "GetSupportNumber";
            public const string SendAddressTo = "SendAddressTo";
            public const string GetNotification = "GetNotification";
        }


        static readonly ActionParamsClass_SubmitChange s_params_SubmitChange = new ActionParamsClass_SubmitChange();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_SubmitChange SubmitChangeParams { get { return s_params_SubmitChange; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_SubmitChange
        {
            public readonly string model = "model";
        }
        static readonly ActionParamsClass_SendAddressTo s_params_SendAddressTo = new ActionParamsClass_SendAddressTo();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_SendAddressTo SendAddressToParams { get { return s_params_SendAddressTo; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_SendAddressTo
        {
            public readonly string fullAddress = "fullAddress";
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
                public readonly string Manage = "Manage";
            }
            public readonly string Manage = "~/Views/Setting/Manage.cshtml";
            static readonly _PartialsClass s_Partials = new _PartialsClass();
            public _PartialsClass Partials { get { return s_Partials; } }
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public partial class _PartialsClass
            {
                static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
                public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
                public class _ViewNamesClass
                {
                    public readonly string _Form = "_Form";
                    public readonly string _SupportNumber = "_SupportNumber";
                }
                public readonly string _Form = "~/Views/Setting/Partials/_Form.cshtml";
                public readonly string _SupportNumber = "~/Views/Setting/Partials/_SupportNumber.cshtml";
            }
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_SettingController : RasmiOnline.Console.Controllers.SettingController
    {
        public T4MVC_SettingController() : base(Dummy.Instance) { }

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
        partial void SubmitChangeOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, RasmiOnline.Domain.Entity.Setting model);

        [NonAction]
        public override System.Web.Mvc.JsonResult SubmitChange(RasmiOnline.Domain.Entity.Setting model)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.SubmitChange);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            SubmitChangeOverride(callInfo, model);
            return callInfo;
        }

        [NonAction]
        partial void GetSupportNumberOverride(T4MVC_System_Web_Mvc_PartialViewResult callInfo);

        [NonAction]
        public override System.Web.Mvc.PartialViewResult GetSupportNumber()
        {
            var callInfo = new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.GetSupportNumber);
            GetSupportNumberOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void SendAddressToOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, string fullAddress);

        [NonAction]
        public override System.Web.Mvc.JsonResult SendAddressTo(string fullAddress)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.SendAddressTo);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "fullAddress", fullAddress);
            SendAddressToOverride(callInfo, fullAddress);
            return callInfo;
        }

        [NonAction]
        partial void GetNotificationOverride(T4MVC_System_Web_Mvc_ContentResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ContentResult GetNotification()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ContentResult(Area, Name, ActionNames.GetNotification);
            GetNotificationOverride(callInfo);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
