using NCFApi.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NCFApi.Application.Services;
public interface ICharitableOrganizationService
{
    Task<IEnumerable<CharitableOrganizationDto>> GetAllAsync();
    Task<CharitableOrganizationDto> GetByIdAsync(int organizationId);
    Task AddAsync(CharitableOrganizationDto organizationDto);
    Task UpdateAsync(int organizationId, CharitableOrganizationDto organizationDto);
    Task DeleteAsync(int organizationId);
}