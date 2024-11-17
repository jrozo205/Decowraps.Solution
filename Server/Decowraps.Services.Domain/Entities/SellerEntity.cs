using System;
using System.Collections.Generic;

namespace Decowraps.Services.Domain.Entities;

public partial class SellerEntity
{
    public int SellerId { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public string? Phone { get; set; }

    public string Email { get; set; } = null!;

    public decimal? Salary { get; set; }

    public DateOnly CreatedOn { get; set; }

    public string? Address { get; set; }

    public bool Status { get; set; }
}
