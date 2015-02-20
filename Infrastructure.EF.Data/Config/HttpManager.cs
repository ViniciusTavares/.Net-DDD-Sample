using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Infrastructure.Interfaces;

namespace Infrastructure.Config
{
    public class HttpManager : IHttpManager
    {
        public const string ContextName = "HttpContext";

        public ApplicationDbContext Context()
        {
            if (HttpContext.Current.Items[ContextName] == null)
            {
                HttpContext.Current.Items[ContextName] = new ApplicationDbContext();
            }
            return HttpContext.Current.Items[ContextName] as ApplicationDbContext;
        }

        public void CloseConnection()
        {
            var context = HttpContext.Current.Items[ContextName] as ApplicationDbContext;

            if (context != null)
            {
                context.Dispose();
            }
        }
    }
}
