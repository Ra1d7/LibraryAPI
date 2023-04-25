using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string Title { get; set; } = null!;

    public int? Publisher { get; set; }

    public DateTime? PublicationDate { get; set; }

    public string Isbn { get; set; } = null!;

    public int? Pages { get; set; }

    public int Avaliable { get; set; }

    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    public string? Description { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Publisher? PublisherNavigation { get; set; }

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Author> Authors { get; set; } = new List<Author>();
}
