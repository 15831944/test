using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace CIFR.Web
{

    public interface IFormsAuthentication
    {
        void SetAuthCookie(string USERNAME, bool createPersistentCookie);
        void SignOut();
    }

    public class FormsAuthenticationWrapper : IFormsAuthentication
    {
        public void SetAuthCookie(string USERNAME, bool createPersistentCookie)
        {
            FormsAuthentication.SetAuthCookie(USERNAME, createPersistentCookie);
        }
        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    } 
}
