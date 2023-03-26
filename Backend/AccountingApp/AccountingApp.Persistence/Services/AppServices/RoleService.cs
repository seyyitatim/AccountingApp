using AccountingApp.Application.Features.RoleFeatures.Commands.UpdateRole;
using AccountingApp.Application.Features.RoleFeatures.CreateRole;
using AccountingApp.Application.Services.AppServices;
using AccountingApp.Domain.AppEntities.Identity;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.Persistence.Services.AppServices
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<AppRole> roleManager;
        private readonly IMapper mapper;

        public RoleService(RoleManager<AppRole> roleManager, IMapper mapper)
        {
            this.roleManager = roleManager;
            this.mapper = mapper;
        }

        public async Task AddAsync(CreateRoleRequest request)
        {
            CheckIsRoleExistAsync(request.Code, request.Name);
            var role = mapper.Map<AppRole>(request);
            await roleManager.CreateAsync(role);
        }

        public async Task DeleteByIdAsync(string id)
        {
            AppRole role = await GetByIdAsync(id);
            await roleManager.DeleteAsync(role);
        }

        public async Task<IList<AppRole>> GetAllRolesAsync()
        {
            return await roleManager.Roles.ToListAsync();
        }

        public async Task<AppRole> GetByCodeAsync(string code)
        {
            var role = await roleManager.Roles.FirstOrDefaultAsync(r => r.Code == code);
            CheckIsRoleNull(role);
            return role;
        }

        public async Task<AppRole> GetByIdAsync(string id)
        {
            var role = await roleManager.Roles.FirstOrDefaultAsync(r => r.Id == id);
            CheckIsRoleNull(role);
            return role;
        }

        public async Task UpdateAsync(UpdateRoleRequest request)
        {
            AppRole role = await GetByIdAsync(request.Id);
            CheckIsRoleExistAsync(request.Code, request.Name);

            role.Code = request.Code;
            role.Name = request.Name;

            await roleManager.UpdateAsync(role);
        }

        private void CheckIsRoleNull(AppRole role)
        {
            if (role == null) throw new Exception("Role bulunamadı");
        }

        private async Task CheckIsRoleExistAsync(string code, string name)
        {
            var role = await roleManager.Roles.FirstOrDefaultAsync(r => r.Code == code || r.Name == name);
            if (role != null) throw new Exception("Bu rol daha önce kayıt edilmiştir");
        }
    }
}
