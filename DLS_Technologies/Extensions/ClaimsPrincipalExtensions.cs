using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace DLS_Technologies.Extensions
{
    public static class ClaimsPrincipalExtensions
    {

        public static string GetFullName(this ClaimsPrincipal claimsPrincipal)
        {
            var fullName = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "FullName");
            return fullName.Value;
        }



        public static string FullName(this IPrincipal user)
        {
            if (user.Identity.IsAuthenticated)
            {
                ClaimsIdentity claimsIdentity = user.Identity as ClaimsIdentity;
                var fullName = claimsIdentity.Claims.FirstOrDefault(c => c.Type == "FullName");
                if (!String.IsNullOrEmpty(fullName.Value))
                    return fullName.Value;
                else
                    return "User";
            }
            else
                return "";
            
            /*
            if (user.Identity.IsAuthenticated)
            {
                //ClaimsIdentity claimsIdentity = user.Identity as ClaimsIdentity;
                foreach (var claim in claimsIdentity.Claims)
                {
                    if (claim.Type == "FullName")
                        return claim.Value;
                }
                return "";
            }
            else
                return "";
                */
        }
    }
}