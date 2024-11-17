
using Decowraps.Services.Application.DTOs;
using Decowraps.Services.Application.Interfaces;
using Decowraps.Services.Domain.Entities;
using Decowraps.Services.Domain.Interfaces;

namespace Decowraps.Services.Application.Services
{
    public class SellerService : ISellerService
    {
        private readonly ISellerRepository _sellerRepository;
        public SellerService(ISellerRepository sellerRepository) 
        {
            _sellerRepository = sellerRepository;
        }

        public async Task<bool> CreateSeller(SellerDTO seller)
        {
            var sellerEntity = new SellerEntity()
            {
                Name = seller.Name,
                Surname = seller.Surname,
                Email = seller.Email,
                Phone = seller.Phone,
                BirthDate = seller.BirthDate,
                Salary = seller.Salary,
                Address = seller.Address,                 
            };

            return await _sellerRepository.CreateSeller(sellerEntity);
        }

        public async Task<bool> DeleteSeller(int sellerId)
        {
            return await _sellerRepository.DeleteSeller(sellerId);
        }

        public async Task<IEnumerable<SellerDTO>> GetAllSellers()
        {
            var sellers = await _sellerRepository.GetAllSellers();
            if (sellers != null && sellers.Any())
                return sellers.Select(x => new SellerDTO()
                {
                    SellerId = x.SellerId,
                    Name = x.Name,
                    Surname = x.Surname,
                    Email = x.Email,
                    Phone = x.Phone,
                    BirthDate = x.BirthDate,
                    Salary = x.Salary,
                    Address = x.Address,
                    Status = x.Status,
                    CreatedOn = x.CreatedOn,
                });
            return [];
        }

        public async Task<SellerDTO> GetSellerById(int sellerId)
        {
            var seller = await _sellerRepository.GetSellerById(sellerId);
            if (seller == null) return new SellerDTO();

            return new SellerDTO()
            {
                SellerId = seller.SellerId,
                Name = seller.Name,
                Surname = seller.Surname,
                Email = seller.Email,
                Phone = seller.Phone,
                BirthDate = seller.BirthDate,
                Salary = seller.Salary,
                Address = seller.Address,
                Status = seller.Status,
                CreatedOn = seller.CreatedOn,
            };
        }

        public async Task<bool> UpdateSeller(SellerDTO seller)
        {
            var sellerEntity = new SellerEntity()
            {
                SellerId = seller.SellerId,
                Name = seller.Name,
                Surname = seller.Surname,
                Email = seller.Email,
                Phone = seller.Phone,
                BirthDate = seller.BirthDate,
                Salary = seller.Salary,
                Address = seller.Address,
            };

            return await _sellerRepository.UpdateSeller(sellerEntity);
        }
    }
}
