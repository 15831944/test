using CIFR.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CIFR.Web
{
    public class ManagerAuthorizeAttribute : AuthorizeAttribute
    {
        public ManagerAuthorizeAttribute()
        {
        }
  

 

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {

            HttpContext.Current.Response.Redirect("/Administration/Login11", true);
        }
    }
}
