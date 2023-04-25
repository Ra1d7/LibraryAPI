using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Publisher : IUser
{
    public int PublisherId { get; set; }

    public string PublisherName { get; set; } = null!;

    public int ContactId { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    public virtual ContactDetail Contact { get; set; } = null!;
}
