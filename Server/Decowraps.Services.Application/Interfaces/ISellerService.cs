
using Decowraps.Services.Application.DTOs;

namespace Decowraps.Services.Application.Interfaces
{
    public interface ISellerService
    {
        Task<bool> CreateSeller(SellerDTO seller);
        Task<bool> DeleteSeller(int sellerId);
        Task<IEnumerable<SellerDTO>> GetAllSellers();
        Task<SellerDTO> GetSellerById(int sellerId);
        Task<bool> UpdateSeller(SellerDTO seller);
    }
}
