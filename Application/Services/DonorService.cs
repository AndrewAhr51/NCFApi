using NCFApi.Domain.Entities;
using NCFApi.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NCFApi.Application.Services
{
    public class DonorService : IDonorService
    {
        private readonly IDonorRepository _donorRepository;

        public DonorService(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }

        public async Task<Donor?> GetDonorByIdAsync(int id)
        {
            return await _donorRepository.GetDonorByIdAsync(id);
        }

        public async Task<IEnumerable<Donor>> GetAllDonorsAsync()
        {
            return await _donorRepository.GetAllDonorsAsync();
        }

        public async Task AddDonorAsync(Donor donor)
        {
            await _donorRepository.AddDonorAsync(donor);
        }

        public async Task UpdateDonorAsync(Donor donor)
        {
            await _donorRepository.UpdateDonorAsync(donor);
        }

        public async Task DeleteDonorAsync(int id)
        {
            await _donorRepository.DeleteDonorAsync(id);
        }
    }
}