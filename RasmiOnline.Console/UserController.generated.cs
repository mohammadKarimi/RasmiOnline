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
namespace T4MVC
{
    public class UserController
    {

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
                public readonly string Profile = "Profile";
                public readonly string Referral = "Referral";
                public readonly string Search = "Search";
                public readonly string UserProfile = "UserProfile";
            }
            public readonly string Add = "~/Views/User/Add.cshtml";
            public readonly string Profile = "~/Views/User/Profile.cshtml";
            public readonly string Referral = "~/Views/User/Referral.cshtml";
            public readonly string Search = "~/Views/User/Search.cshtml";
            public readonly string UserProfile = "~/Views/User/UserProfile.cshtml";
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
                    public readonly string _PersonalInfo = "_PersonalInfo";
                    public readonly string _Profile = "_Profile";
                    public readonly string _ResetUserPassword = "_ResetUserPassword";
                    public readonly string _SearchList = "_SearchList";
                    public readonly string _SearchUser = "_SearchUser";
                    public readonly string _Security = "_Security";
                }
                public readonly string _Form = "~/Views/User/Partials/_Form.cshtml";
                public readonly string _PersonalInfo = "~/Views/User/Partials/_PersonalInfo.cshtml";
                public readonly string _Profile = "~/Views/User/Partials/_Profile.cshtml";
                public readonly string _ResetUserPassword = "~/Views/User/Partials/_ResetUserPassword.cshtml";
                public readonly string _SearchList = "~/Views/User/Partials/_SearchList.cshtml";
                public readonly string _SearchUser = "~/Views/User/Partials/_SearchUser.cshtml";
                public readonly string _Security = "~/Views/User/Partials/_Security.cshtml";
            }
        }
    }

}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
