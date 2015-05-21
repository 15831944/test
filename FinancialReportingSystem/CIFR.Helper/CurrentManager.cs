using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIFR.Helper
{
    public static class CurrentManager
    {
        public static CIFR.DAL.Manager CurrentLogonManager()
        { 

            if (System.Web.HttpContext.Current.Session[ConstVariables.CurrentManagerSessionKey] != null)
            {
                var manager = System.Web.HttpContext.Current.Session[ConstVariables.CurrentManagerSessionKey] as CIFR.DAL.Manager;
                if (manager != null)
                {
                    return manager;
                }
            }

            return null;
        } 
    }
}
