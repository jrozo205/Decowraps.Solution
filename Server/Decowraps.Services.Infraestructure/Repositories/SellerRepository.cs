using Decowraps.Services.Domain.Entities;
using Decowraps.Services.Domain.Interfaces;
using Decowraps.Services.Infraestructure.Configuration.Context;
using Microsoft.EntityFrameworkCore;

namespace Decowraps.Services.Infraestructure.Repositories
{
    public class SellerRepository : ISellerRepository
    {
        private readonly DecowrapsContextDb _decowrapsContextDb;

        public SellerRepository(DecowrapsContextDb decowrapsContextDb) 
        {
            _decowrapsContextDb = decowrapsContextDb;
        }

        public async Task<bool> CreateSeller(SellerEntity seller)
        {
            seller.CreatedOn = DateOnly.FromDateTime(DateTime.Now);
            seller.Status = true;
            _decowrapsContextDb.Sellers.Add(seller);
            var result = await _decowrapsContextDb.SaveChangesAsync();
            return result == 1;
        }

        public async Task<bool> DeleteSeller(int sellerId)
        {
            var sellerToDelete = _decowrapsContextDb.Sellers.Find(sellerId);
            if (sellerToDelete == null) return false;
            sellerToDelete.Status = false;

            _decowrapsContextDb.Sellers.Update(sellerToDelete);
            var result = await _decowrapsContextDb.SaveChangesAsync();
            return result == 1;
        }

        public async Task<IEnumerable<SellerEntity>> GetAllSellers()
        {
            return await _decowrapsContextDb.Sellers.Where(x=>x.Status).ToArrayAsync();
        }

        public async Task<SellerEntity> GetSellerById(int sellerId)
        {
            return await _decowrapsContextDb.Sellers.FindAsync(sellerId);
        }

        public async Task<bool> UpdateSeller(SellerEntity seller)
        {
            var sellerToUpdate = _decowrapsContextDb.Sellers.Find(seller.SellerId);
            if (sellerToUpdate == null) return false;

            sellerToUpdate.Email = seller.Email;
            sellerToUpdate.Salary = seller.Salary;
            sellerToUpdate.Name = seller.Name;
            sellerToUpdate.Surname  = seller.Surname;
            sellerToUpdate.Phone = seller.Phone;
            sellerToUpdate.BirthDate = seller.BirthDate;

            _decowrapsContextDb.Sellers.Update(sellerToUpdate);
            var result = await _decowrapsContextDb.SaveChangesAsync();
            return result == 1;
        }
    }
}
