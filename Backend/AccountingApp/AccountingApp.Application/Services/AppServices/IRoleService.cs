using AccountingApp.Application.Features.RoleFeatures.Commands.DeleteRole;
using AccountingApp.Application.Features.RoleFeatures.Commands.UpdateRole;
using AccountingApp.Application.Features.RoleFeatures.CreateRole;
using AccountingApp.Domain.AppEntities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Application.Services.AppServices
{
    public interface IRoleService
    {
        Task AddAsync(CreateRoleRequest request);
        Task UpdateAsync(UpdateRoleRequest request);
        Task DeleteByIdAsync(string id);
        Task<IList<AppRole>> GetAllRolesAsync();
        Task<AppRole> GetByIdAsync(string id);
        Task<AppRole> GetByCodeAsync(string code);
    }
}
