using NCFApi.Domain.Entities;
using NCFApi.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NCFApi.Application.Services
{
    public class DonationService : IDonationService
    {
        private readonly IDonationRepository _donationRepository;

        public DonationService(IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
        }

        public async Task<Donation?> GetDonationByIdAsync(int id)
        {
            return await _donationRepository.GetDonationByIdAsync(id);
        }

        public async Task<IEnumerable<Donation>> GetAllDonationsAsync()
        {
            return await _donationRepository.GetAllDonationsAsync();
        }

        public async Task AddDonationAsync(Donation donation)
        {
            await _donationRepository.AddDonationAsync(donation);
        }

        public async Task UpdateDonationAsync(Donation donation)
        {
            await _donationRepository.UpdateDonationAsync(donation);
        }

        public async Task DeleteDonationAsync(int id)
        {
            await _donationRepository.DeleteDonationAsync(id);
        }
    }
}