using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Borrowing
{
    public int BorrowId { get; set; }

    public DateTime BorrowDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public DateTime DueDate { get; set; }

    public bool Status { get; set; }

    public int BorrowerId { get; set; }

    public int BorrowedBookId { get; set; }

    public virtual Borrower Borrower { get; set; } = null!;
}
