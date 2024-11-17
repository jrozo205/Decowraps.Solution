using Decowraps.Web.Services.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Decowraps.Web.Models
{
    public class SellerViewModel
    {
        public int SellerId { get; set; }

        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public DateOnly BirthDate { get; set; }

        public string? Phone { get; set; }

        public string Email { get; set; } = null!;

        public decimal? Salary { get; set; }

        public DateOnly? CreatedOn { get; set; }

        public string? Address { get; set; }

        public bool Status { get; set; }

        public SellerViewModel() { }

        public SellerViewModel(SellerDTO sellerDTO) 
        {
            SellerId = sellerDTO.sellerId;
            Name = sellerDTO.Name;
            Surname = sellerDTO.Surname;
            BirthDate = sellerDTO.BirthDate;
            Phone = sellerDTO.Phone;
            Email = sellerDTO.Email;
            Salary = sellerDTO.Salary;
            Status = sellerDTO.Status;
            Address = sellerDTO.Address;
            CreatedOn = sellerDTO.CreatedOn;
        }

        public SellerDTO ConvertToSellerDTO() 
        {
            return new SellerDTO()
            {
                sellerId = this.SellerId,
                Name = this.Name,
                Surname = this.Surname,
                BirthDate = this.BirthDate,
                Phone = this.Phone,
                Email = this.Email,
                Salary = this.Salary,
                Status = this.Status,
                Address = this.Address,
                CreatedOn = this.CreatedOn
            };
        }
    }
}
