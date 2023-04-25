using System;
using System.Collections.Generic;

namespace API.Models;

public partial class ActiveBorrowing
{
    public string Fullname { get; set; } = null!;

    public int BorrowId { get; set; }

    public DateTime? BorrowDate { get; set; }

    public string? ReturnDate { get; set; }

    public DateTime? DueDate { get; set; }

    public string Status { get; set; } = null!;

    public int BorrowerId { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string Title { get; set; } = null!;
}
