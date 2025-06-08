
using NCFApi.Domain.DTOs;
using System.Threading.Tasks;

namespace NCFApi.Infrastructure.Repositories
{
    public interface IRoleService
    {
        Task<RolesDto> CreateRoleAsync(CreateRoleDto roleDto);
        Task<RolesDto?> GetRoleByIdAsync(int id);
        Task<bool> UpdateRoleAsync(int id, CreateRoleDto roleDto);
        Task<bool> DeleteRoleAsync(int id);
    }
}