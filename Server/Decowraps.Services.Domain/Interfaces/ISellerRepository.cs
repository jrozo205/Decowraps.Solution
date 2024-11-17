
using Decowraps.Services.Domain.Entities;

namespace Decowraps.Services.Domain.Interfaces
{
    public interface ISellerRepository
    {
        Task<bool> CreateSeller(SellerEntity seller);
        Task<bool> UpdateSeller(SellerEntity seller);
        Task<bool> DeleteSeller(int sellerId);
        Task<IEnumerable<SellerEntity>> GetAllSellers();
        Task<SellerEntity> GetSellerById(int sellerId);
    }
}
