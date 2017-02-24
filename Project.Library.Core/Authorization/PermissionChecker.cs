using Abp.Authorization;
using Project.Library.Authorization.Roles;
using Project.Library.MultiTenancy;
using Project.Library.Users;

namespace Project.Library.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
