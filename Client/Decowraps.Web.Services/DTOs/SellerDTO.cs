namespace Decowraps.Web.Services.DTOs
{
    public class SellerDTO
    {
        public int sellerId { get; set; }

        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public DateOnly BirthDate { get; set; }

        public string? Phone { get; set; }

        public string Email { get; set; } = null!;

        public decimal? Salary { get; set; }

        public DateOnly? CreatedOn { get; set; }

        public string? Address { get; set; }

        public bool Status { get; set; }
    }
}
