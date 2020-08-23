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
    public partial class AttachmentController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected AttachmentController(Dummy d) { }

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
        public virtual System.Web.Mvc.FileResult Download()
        {
            return new T4MVC_System_Web_Mvc_FileResult(Area, Name, ActionNames.Download);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.PartialViewResult GetOrderAttachments()
        {
            return new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.GetOrderAttachments);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.JsonResult Delete()
        {
            return new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.Delete);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult UploadAfterTransacttion()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.UploadAfterTransacttion);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.JsonResult AddOrderAttachments()
        {
            return new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.AddOrderAttachments);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public AttachmentController Actions { get { return MVC.Attachment; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Attachment";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Attachment";
        [GeneratedCode("T4MVC", "2.0")]
        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Download = "Download";
            public readonly string GetOrderAttachments = "GetOrderAttachments";
            public readonly string Delete = "Delete";
            public readonly string UploadAfterTransacttion = "UploadAfterTransacttion";
            public readonly string AddOrderAttachments = "AddOrderAttachments";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Download = "Download";
            public const string GetOrderAttachments = "GetOrderAttachments";
            public const string Delete = "Delete";
            public const string UploadAfterTransacttion = "UploadAfterTransacttion";
            public const string AddOrderAttachments = "AddOrderAttachments";
        }


        static readonly ActionParamsClass_Download s_params_Download = new ActionParamsClass_Download();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Download DownloadParams { get { return s_params_Download; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Download
        {
            public readonly string attachmentId = "attachmentId";
            public readonly string orderId = "orderId";
        }
        static readonly ActionParamsClass_GetOrderAttachments s_params_GetOrderAttachments = new ActionParamsClass_GetOrderAttachments();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_GetOrderAttachments GetOrderAttachmentsParams { get { return s_params_GetOrderAttachments; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_GetOrderAttachments
        {
            public readonly string orderId = "orderId";
            public readonly string attachmentType = "attachmentType";
        }
        static readonly ActionParamsClass_Delete s_params_Delete = new ActionParamsClass_Delete();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Delete DeleteParams { get { return s_params_Delete; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Delete
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_UploadAfterTransacttion s_params_UploadAfterTransacttion = new ActionParamsClass_UploadAfterTransacttion();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_UploadAfterTransacttion UploadAfterTransacttionParams { get { return s_params_UploadAfterTransacttion; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_UploadAfterTransacttion
        {
            public readonly string orderId = "orderId";
        }
        static readonly ActionParamsClass_AddOrderAttachments s_params_AddOrderAttachments = new ActionParamsClass_AddOrderAttachments();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_AddOrderAttachments AddOrderAttachmentsParams { get { return s_params_AddOrderAttachments; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_AddOrderAttachments
        {
            public readonly string orderId = "orderId";
            public readonly string attachmentType = "attachmentType";
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
                public readonly string UploadAfterTransacttion = "UploadAfterTransacttion";
            }
            public readonly string UploadAfterTransacttion = "~/Views/Attachment/UploadAfterTransacttion.cshtml";
            static readonly _PartialsClass s_Partials = new _PartialsClass();
            public _PartialsClass Partials { get { return s_Partials; } }
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public partial class _PartialsClass
            {
                static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
                public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
                public class _ViewNamesClass
                {
                    public readonly string _List = "_List";
                    public readonly string _Uploader = "_Uploader";
                }
                public readonly string _List = "~/Views/Attachment/Partials/_List.cshtml";
                public readonly string _Uploader = "~/Views/Attachment/Partials/_Uploader.cshtml";
            }
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_AttachmentController : RasmiOnline.Console.Controllers.AttachmentController
    {
        public T4MVC_AttachmentController() : base(Dummy.Instance) { }

        [NonAction]
        partial void DownloadOverride(T4MVC_System_Web_Mvc_FileResult callInfo, int attachmentId, int orderId);

        [NonAction]
        public override System.Web.Mvc.FileResult Download(int attachmentId, int orderId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_FileResult(Area, Name, ActionNames.Download);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "attachmentId", attachmentId);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "orderId", orderId);
            DownloadOverride(callInfo, attachmentId, orderId);
            return callInfo;
        }

        [NonAction]
        partial void GetOrderAttachmentsOverride(T4MVC_System_Web_Mvc_PartialViewResult callInfo, int orderId, RasmiOnline.Domain.Enum.AttachmentType attachmentType);

        [NonAction]
        public override System.Web.Mvc.PartialViewResult GetOrderAttachments(int orderId, RasmiOnline.Domain.Enum.AttachmentType attachmentType)
        {
            var callInfo = new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.GetOrderAttachments);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "orderId", orderId);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "attachmentType", attachmentType);
            GetOrderAttachmentsOverride(callInfo, orderId, attachmentType);
            return callInfo;
        }

        [NonAction]
        partial void DeleteOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.JsonResult Delete(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.Delete);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            DeleteOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void UploadAfterTransacttionOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int orderId);

        [NonAction]
        public override System.Web.Mvc.ActionResult UploadAfterTransacttion(int orderId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.UploadAfterTransacttion);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "orderId", orderId);
            UploadAfterTransacttionOverride(callInfo, orderId);
            return callInfo;
        }

        [NonAction]
        partial void AddOrderAttachmentsOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, int orderId, RasmiOnline.Domain.Enum.AttachmentType attachmentType);

        [NonAction]
        public override System.Web.Mvc.JsonResult AddOrderAttachments(int orderId, RasmiOnline.Domain.Enum.AttachmentType attachmentType)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.AddOrderAttachments);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "orderId", orderId);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "attachmentType", attachmentType);
            AddOrderAttachmentsOverride(callInfo, orderId, attachmentType);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
