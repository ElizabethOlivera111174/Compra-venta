using System.Security.Claims;
using System.Security.Principal;

namespace PowerAutomate.Core.Helpers
{
    public class SessionHelper
    {
          public static string GetValue(IPrincipal User, string Property)
        {
            var r = ((ClaimsIdentity)User.Identity).FindFirst(Property);
            return r == null ? "" : r.Value;
        }

        public static string GetNameIdentifier(IPrincipal User)
        {
            var r = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier);
            return r == null ? "" : r.Value;
        }

        public static string GetName(IPrincipal User)
        {
            var r = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Name);
            return r == null ? "" : r.Value;
        }
        public static string GetEmail(IPrincipal User)
        {
            var r = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Email);
            return r == null ? "" : r.Value;
        }
    }
}