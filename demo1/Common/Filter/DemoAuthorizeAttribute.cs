using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demo1.Common
{
    public class DemoAuthorizeAttribute:AuthorizeAttribute
    {

        private string ctrlName;
        private string actionName;

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            ctrlName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            actionName = filterContext.ActionDescriptor.ActionName;

            base.OnAuthorization(filterContext);
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool rst = false;
            if (httpContext == null)
            {
                throw new ArgumentNullException("HttpContext");
            }
            //if (!httpContext.User.Identity.IsAuthenticated)
            //{
            //    return false;
            //}
            //获取当前登录的用户名
            string curUser = httpContext.User.Identity.Name;
            //判断权限
            BLL.Gnbll gnbll = new BLL.Gnbll();

            if (gnbll.checkYhqx(curUser, ctrlName, actionName))
            {
                rst = true;
            }
            return rst;
        }
    }
}