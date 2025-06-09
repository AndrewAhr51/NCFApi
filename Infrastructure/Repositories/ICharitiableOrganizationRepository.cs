using NCFApi.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NCFApi.Infrastructure.Repositories;

public interface ICharitableOrganizationRepository
{
    Task<IEnumerable<CharitableOrganization>> GetAllAsync();
    Task<CharitableOrganization> GetByIdAsync(int organizationId);
    Task AddAsync(CharitableOrganization organization);
    Task UpdateAsync(CharitableOrganization organization);
    Task DeleteAsync(int organizationId);
}
