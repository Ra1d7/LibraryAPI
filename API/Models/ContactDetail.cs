using System;
using System.Collections.Generic;

namespace API.Models;

public partial class ContactDetail
{
    public int ContactId { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Website { get; set; }

    public virtual ICollection<Author> Authors { get; set; } = new List<Author>();

    public virtual ICollection<Borrower> Borrowers { get; set; } = new List<Borrower>();
}
