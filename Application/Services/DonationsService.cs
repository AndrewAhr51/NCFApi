using NCFApi.Domain.DTOs;
using NCFApi.Domain.Entities;
using NCFApi.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCFApi.Application.Services;

public class DonationService : IDonationService
{
    private readonly IDonationRepository _donationRepository;

    public DonationService(IDonationRepository donationRepository)
    {
        _donationRepository = donationRepository;
    }

    public async Task<IEnumerable<DonationDto>> GetAllAsync()
    {
        var donations = await _donationRepository.GetAllAsync();
        return donations.Select(d => MapToDto(d));
    }

    public async Task<DonationDto> GetByIdAsync(int donationId)
    {
        var donation = await _donationRepository.GetByIdAsync(donationId);
        return donation != null ? MapToDto(donation) : null;
    }

    public async Task<IEnumerable<DonationDto>> GetByDonorIdAsync(int donorId)
    {
        var donations = await _donationRepository.GetByDonorIdAsync(donorId);
        return donations.Select(d => MapToDto(d));
    }

    public async Task<IEnumerable<DonationDto>> GetByOrganizationIdAsync(int organizationId)
    {
        var donations = await _donationRepository.GetByOrganizationIdAsync(organizationId);
        return donations.Select(d => MapToDto(d));
    }

    public async Task AddAsync(DonationDto donationDto)
    {
        var donation = new Donation
        {
            DonorId = donationDto.DonorId,
            OrganizationId = donationDto.OrganizationId,
            Amount = donationDto.Amount,
            DonationDate = donationDto.DonationDate,
            PaymentMethod = donationDto.PaymentMethod,
            DonationReference = donationDto.DonationReference,
            Status = donationDto.Status,
            Notes = donationDto.Notes
        };

        await _donationRepository.AddAsync(donation);
    }

    public async Task UpdateAsync(int donationId, DonationDto donationDto)
    {
        var existingDonation = await _donationRepository.GetByIdAsync(donationId);
        if (existingDonation == null) return;

        existingDonation.Amount = donationDto.Amount;
        existingDonation.PaymentMethod = donationDto.PaymentMethod;
        existingDonation.Status = donationDto.Status;
        existingDonation.DonationReference = donationDto.DonationReference;
        existingDonation.Notes = donationDto.Notes;

        await _donationRepository.UpdateAsync(existingDonation);
    }

    public async Task DeleteAsync(int donationId)
    {
        await _donationRepository.DeleteAsync(donationId);
    }

    private DonationDto MapToDto(Donation donation)
    {
        return new DonationDto
        {
            DonationId = donation.DonationId,
            DonorId = donation.DonorId,
            OrganizationId = donation.OrganizationId,
            Amount = donation.Amount,
            DonationDate = donation.DonationDate,
            PaymentMethod = donation.PaymentMethod,
            DonationReference = donation.DonationReference,
            Status = donation.Status,
            Notes = donation.Notes
        };
    }
}