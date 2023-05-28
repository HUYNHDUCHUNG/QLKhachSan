using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace congngheweb.App_Start
{
    public class AdminAuthorizeAttribute : AuthorizeAttribute
    {
        // Thực hiện xác thực
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }

            // Kiểm tra xem người dùng đã đăng nhập hay chưa
            if (!httpContext.User.Identity.IsAuthenticated)
            {
                return false;
            }

            // Kiểm tra xem người dùng có quyền "admin" hay không
            if (!httpContext.User.IsInRole("admin"))
            {
                return false;
            }

            return true;
        }
    }
}