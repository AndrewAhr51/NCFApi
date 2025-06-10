using NCFApi.Domain.Entities;
using NCFApi.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NCFApi.Application.Services
{
    public class CharitableOrganizationService : ICharitableOrganizationService
    {
        private readonly ICharitableOrganizationRepository _organizationRepository;

        public CharitableOrganizationService(ICharitableOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public async Task<CharitableOrganization?> GetOrganizationByIdAsync(int id)
        {
            return await _organizationRepository.GetOrganizationByIdAsync(id);
        }

        public async Task<IEnumerable<CharitableOrganization>> GetAllOrganizationsAsync()
        {
            return await _organizationRepository.GetAllOrganizationsAsync();
        }

        public async Task AddOrganizationAsync(CharitableOrganization organization)
        {
            await _organizationRepository.AddOrganizationAsync(organization);
        }

        public async Task UpdateOrganizationAsync(CharitableOrganization organization)
        {
            await _organizationRepository.UpdateOrganizationAsync(organization);
        }

        public async Task DeleteOrganizationAsync(int id)
        {
            await _organizationRepository.DeleteOrganizationAsync(id);
        }
    }
}