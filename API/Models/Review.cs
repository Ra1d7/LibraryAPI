using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public int BorrowerId { get; set; }

    public int Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime ReviewDate { get; set; }

    public int? BookId { get; set; }

    public virtual Book? Book { get; set; }

    public virtual Borrower Borrower { get; set; } = null!;
}
