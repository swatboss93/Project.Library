using System.Threading.Tasks;
using Abp.Application.Services;
using Project.Library.Roles.Dto;

namespace Project.Library.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
