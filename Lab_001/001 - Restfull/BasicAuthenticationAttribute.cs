using _001___Restfull.Models.DAO;
using _001___Restfull.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace _001___Restfull
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request
                    .CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string authenticationToken = actionContext.Request.Headers
                                            .Authorization.Parameter;
                string decodedAuthenticationToken = Encoding.UTF8.GetString(
                    Convert.FromBase64String(authenticationToken));
                string[] AuthCredentials = decodedAuthenticationToken.Split(':');

                ModulesDAO dao = new ModulesDAO();
                DSLDataType oReturn = dao.AuthenticateCredentials(Int32.Parse(AuthCredentials[0]), AuthCredentials[1]);
                if (oReturn.BoolValue)
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(
                        new GenericIdentity(oReturn.Value.ToString()), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request
                        .CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}
