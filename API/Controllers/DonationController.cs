using Microsoft.AspNetCore.Mvc;
using NCFApi.Domain.DTOs;
using NCFApi.Domain.Entities;
using NCFApi.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NCFApi.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DonationsController : ControllerBase
{
    private readonly IDonationRepository _donationRepository;

    public DonationsController(IDonationRepository donationRepository)
    {
        _donationRepository = donationRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DonationDto>>> GetAllDonations()
    {
        var donations = await _donationRepository.GetAllAsync();
        return Ok(donations);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DonationDto>> GetDonationById(int id)
    {
        var donation = await _donationRepository.GetByIdAsync(id);
        if (donation == null)
        {
            return NotFound();
        }
        return Ok(donation);
    }

    [HttpPost]
    public async Task<ActionResult> CreateDonation([FromBody] DonationDto donationDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

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
        return CreatedAtAction(nameof(GetDonationById), new { id = donation.DonationId }, donation);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateDonation(int id, [FromBody] DonationDto donationDto)
    {
        var existingDonation = await _donationRepository.GetByIdAsync(id);
        if (existingDonation == null)
        {
            return NotFound();
        }

        existingDonation.Amount = donationDto.Amount;
        existingDonation.PaymentMethod = donationDto.PaymentMethod;
        existingDonation.Status = donationDto.Status;
        existingDonation.DonationReference = donationDto.DonationReference;
        existingDonation.Notes = donationDto.Notes;

        await _donationRepository.UpdateAsync(existingDonation);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteDonation(int id)
    {
        var donation = await _donationRepository.GetByIdAsync(id);
        if (donation == null)
        {
            return NotFound();
        }

        await _donationRepository.DeleteAsync(id);
        return NoContent();
    }
}
