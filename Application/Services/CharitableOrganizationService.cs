using NCFApi.Domain.DTOs;
using NCFApi.Domain.Entities;
using NCFApi.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCFApi.Application.Services;

public class CharitableOrganizationService : ICharitableOrganizationService
{
    private readonly ICharitableOrganizationRepository _organizationRepository;

    public CharitableOrganizationService(ICharitableOrganizationRepository organizationRepository)
    {
        _organizationRepository = organizationRepository;
    }

    public async Task<IEnumerable<CharitableOrganizationDto>> GetAllAsync()
    {
        var organizations = await _organizationRepository.GetAllAsync();
        return organizations.Select(o => MapToDto(o));
    }

    public async Task<CharitableOrganizationDto> GetByIdAsync(int organizationId)
    {
        var organization = await _organizationRepository.GetByIdAsync(organizationId);
        return organization != null ? MapToDto(organization) : null;
    }

    public async Task AddAsync(CharitableOrganizationDto organizationDto)
    {
        var organization = new CharitableOrganization
        {
            Name = organizationDto.Name,
            Description = organizationDto.Description,
            RegistrationNumber = organizationDto.RegistrationNumber,
            Website = organizationDto.Website,
            ContactEmail = organizationDto.ContactEmail,
            ContactPhone = organizationDto.ContactPhone,
            Address = organizationDto.Address,
            City = organizationDto.City,
            State = organizationDto.State,
            Country = organizationDto.Country,
            PostalCode = organizationDto.PostalCode,
            FoundedYear = organizationDto.FoundedYear,
            TotalDonations = organizationDto.TotalDonations,
            IsActive = organizationDto.IsActive
        };

        await _organizationRepository.AddAsync(organization);
    }

    public async Task UpdateAsync(int organizationId, CharitableOrganizationDto organizationDto)
    {
        var existingOrganization = await _organizationRepository.GetByIdAsync(organizationId);
        if (existingOrganization == null) return;

        existingOrganization.Name = organizationDto.Name;
        existingOrganization.Description = organizationDto.Description;
        existingOrganization.ContactEmail = organizationDto.ContactEmail;
        existingOrganization.ContactPhone = organizationDto.ContactPhone;
        existingOrganization.Address = organizationDto.Address;
        existingOrganization.City = organizationDto.City;
        existingOrganization.State = organizationDto.State;
        existingOrganization.Country = organizationDto.Country;
        existingOrganization.PostalCode = organizationDto.PostalCode;
        existingOrganization.TotalDonations = organizationDto.TotalDonations;
        existingOrganization.IsActive = organizationDto.IsActive;

        await _organizationRepository.UpdateAsync(existingOrganization);
    }

    public async Task DeleteAsync(int organizationId)
    {
        await _organizationRepository.DeleteAsync(organizationId);
    }

    private CharitableOrganizationDto MapToDto(CharitableOrganization organization)
    {
        return new CharitableOrganizationDto
        {
            OrganizationId = organization.OrganizationId,
            Name = organization.Name,
            Description = organization.Description,
            RegistrationNumber = organization.RegistrationNumber,
            Website = organization.Website,
            ContactEmail = organization.ContactEmail,
            ContactPhone = organization.ContactPhone,
            Address = organization.Address,
            City = organization.City,
            State = organization.State,
            Country = organization.Country,
            PostalCode = organization.PostalCode,
            FoundedYear = organization.FoundedYear,
            TotalDonations = organization.TotalDonations,
            IsActive = organization.IsActive
        };
    }
}