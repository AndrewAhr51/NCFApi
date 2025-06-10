using NCFApi.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NCFApi.Infrastructure.Repositories
{
    public interface ICharitableOrganizationRepository
    {
        Task<CharitableOrganization?> GetOrganizationByIdAsync(int id);
        Task<IEnumerable<CharitableOrganization>> GetAllOrganizationsAsync();
        Task AddOrganizationAsync(CharitableOrganization organization);
        Task UpdateOrganizationAsync(CharitableOrganization organization);
        Task DeleteOrganizationAsync(int id);
    }
}