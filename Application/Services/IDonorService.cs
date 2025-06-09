using NCFApi.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NCFApi.Application.Services
{
    public interface IDonorService
    {
        Task<DonorDto?> GetByIdAsync(int donorId); // ✅ Retrieve donor profile
        Task<IEnumerable<DonorDto>> GetAllAsync(); // ✅ List all donors
        Task<DonorDto> CreateDonorAsync(UpdateDonorDto donorDto, int userId); // ✅ Create new donor linked to a user
        Task<bool> UpdateDonorProfileAsync(int donorId, UpdateDonorDto donorDto, int currentUserId); // ✅ Restricted self-update
        Task<bool> DeleteDonorAsync(int donorId, int currentUserId); // ✅ Enforce ownership on delete
    }
}