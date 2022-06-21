using Microsoft.AspNetCore.Authorization;

namespace Club_27.Authorization
{
    public class WebAuthorizeAttribute : AuthorizeAttribute
    {
        public string[] RolesList
        {
            get { return (Roles ?? string.Empty).Split(','); }
            set { Roles = string.Join(",", value); }
        }
    }

    public sealed class Roles
    {
        public const string Admin = "Admin";
        public const string NonAdmin = "NonAdmin";
    }
}