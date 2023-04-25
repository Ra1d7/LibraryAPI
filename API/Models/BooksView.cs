using System;
using System.Collections.Generic;

namespace API.Models;

public partial class BooksView
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int? YearReleased { get; set; }

    public int? Publisher { get; set; }

    public string Isbn { get; set; } = null!;

    public string Price { get; set; } = null!;

    public string PriceRange { get; set; } = null!;

    public int? Pages { get; set; }

    public string Size { get; set; } = null!;

    public string? Authors { get; set; }
}
