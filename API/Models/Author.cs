using API.Interfaces;
using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Author : IUser
{
    public int AuthorId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public int ContactId { get; set; }

    public string? Bio { get; set; }

    public string? Password { get; set; }

    public virtual ContactDetail Contact { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
