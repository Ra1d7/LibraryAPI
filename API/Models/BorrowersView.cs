using System;
using System.Collections.Generic;

namespace API.Models;

public partial class BorrowersView
{
    public int BorrowerId { get; set; }

    public string Firstname { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public int NumberOfReviews { get; set; }

    public int NumberOfBorrows { get; set; }

    public string? Email { get; set; }

    public string? Website { get; set; }

    public string? PhoneNumber { get; set; }
}
