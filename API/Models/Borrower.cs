global using API.Interfaces;
using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Borrower : IUser
{
    public int BorrowerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public int ContactId { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Borrowing> Borrowings { get; set; } = new List<Borrowing>();

    public virtual ContactDetail Contact { get; set; } = null!;

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
