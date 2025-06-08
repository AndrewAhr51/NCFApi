using NCFApi.Application.Services;
using NCFApi.Domain.DTOs;
using NCFApi.Domain.Entities;
using NCFApi.Infrastructure.Repositories;
using System.Data;
using System.Threading.Tasks;

namespace NCFApi.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        // ✅ Create a role
        public async Task<RolesDto> CreateRoleAsync(CreateRoleDto roleDto)
        {
            var newRole = new Roles
            {
                Name = roleDto.Name,
                Description = roleDto.Description
            };

            var createdRole = await _roleRepository.AddAsync(newRole);
            return new RolesDto { RoleId = createdRole.Id, Name = createdRole.Name, Description = createdRole.Description };
        }

        // ✅ Get a role by ID
        public async Task<RolesDto?> GetRoleByIdAsync(int id)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            if (role == null) return null;
            return new RolesDto { RoleId = role.Id, Name = role.Name, Description = role.Description };
        }

        // ✅ Update role details
        public async Task<bool> UpdateRoleAsync(int id, CreateRoleDto roleDto)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            if (role == null) return false;

            role.Name = roleDto.Name;
            role.Description = roleDto.Description;

            return await _roleRepository.UpdateAsync(role);
        }

        // ✅ Delete a role
        public async Task<bool> DeleteRoleAsync(int id)
        {
            return await _roleRepository.DeleteAsync(id);
        }
    }
}