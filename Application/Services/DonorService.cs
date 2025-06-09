using NCFApi.Domain.DTOs;
using NCFApi.Domain.Entities;
using NCFApi.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NCFApi.Application.Services
{
    public class DonorService : IDonorService
    {
        private readonly IDonorRepository _donorRepository;
        private readonly ILogger<DonorService> _logger;

        public DonorService(IDonorRepository donorRepository, ILogger<DonorService> logger)
        {
            _donorRepository = donorRepository;
            _logger = logger;
        }

        public async Task<DonorDto?> GetByIdAsync(int donorId)
        {
            var donor = await _donorRepository.GetByIdAsync(donorId);
            return donor != null ? MapToDto(donor) : null;
        }

        public async Task<IEnumerable<DonorDto>> GetAllAsync()
        {
            var donors = await _donorRepository.GetAllAsync();
            return donors.Select(MapToDto);
        }

        public async Task<DonorDto> CreateDonorAsync(UpdateDonorDto donorDto, int userId)
        {
            var donor = new Donor
            {
                UserId = userId,
                FirstName = donorDto.FirstName,
                LastName = donorDto.LastName,
                Email = donorDto.Email,
                PhoneNumber = donorDto.PhoneNumber,
                StreetAddressLine1 = donorDto.StreetAddressLine1,
                StreetAddressLine2 = donorDto.StreetAddressLine2,
                City = donorDto.City,
                State = donorDto.State,
                PostalCode = donorDto.PostalCode,
                Country = donorDto.Country,
                DateOfBirth = donorDto.DateOfBirth?.ToDateTime(TimeOnly.MinValue) ?? default,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var createdDonor = await _donorRepository.AddAsync(donor);
            return MapToDto(createdDonor);
        }

        public async Task<bool> DeleteDonorAsync(int donorId, int currentUserId)
        {
            var donor = await _donorRepository.GetByIdAsync(donorId);
            if (donor == null || donor.UserId != currentUserId)
            {
                _logger.LogWarning("❌ Unauthorized deletion attempt by UserID {UserId} for DonorID {DonorId}", currentUserId, donorId);
                return false;
            }

            return await _donorRepository.DeleteAsync(donorId);
        }

        public async Task<bool> UpdateDonorProfileAsync(int donorId, UpdateDonorDto donorDto, int currentUserId)
        {
            var donor = await _donorRepository.GetByIdAsync(donorId);
            if (donor == null)
            {
                _logger.LogWarning("❌ Donor not found: ID {DonorId}", donorId);
                return false;
            }

            if (donor.UserId != currentUserId)
            {
                _logger.LogWarning("❌ Unauthorized update attempt by UserID {UserId} for DonorID {DonorId}", currentUserId, donorId);
                return false;
            }

            donor.FirstName = donorDto.FirstName;
            donor.LastName = donorDto.LastName;
            donor.Email = donorDto.Email;
            donor.PhoneNumber = donorDto.PhoneNumber;
            donor.StreetAddressLine1 = donorDto.StreetAddressLine1;
            donor.StreetAddressLine2 = donorDto.StreetAddressLine2;
            donor.City = donorDto.City;
            donor.State = donorDto.State;
            donor.PostalCode = donorDto.PostalCode;
            donor.Country = donorDto.Country;
            donor.DateOfBirth = donorDto.DateOfBirth?.ToDateTime(TimeOnly.MinValue) ?? donor.DateOfBirth;

            donor.UpdatedAt = DateTime.UtcNow;

            var result = await _donorRepository.UpdateAsync(donor);
            _logger.LogInformation(result
                ? "✅ Donor {DonorId} updated successfully"
                : "❌ Update failed for DonorID {DonorId}", donorId);

            return result;
        }

        private static DonorDto MapToDto(Donor donor)
        {
            return new DonorDto
            {
                DonorId = donor.Id,
                FirstName = donor.FirstName,
                LastName = donor.LastName,
                Email = donor.Email,
                PhoneNumber = donor.PhoneNumber,
                StreetAddressLine1 = donor.StreetAddressLine1,
                StreetAddressLine2 = donor.StreetAddressLine2,
                City = donor.City,
                State = donor.State,
                PostalCode = donor.PostalCode,
                Country = donor.Country,
                DateOfBirth = donor.DateOfBirth
            };
        }
    }
}