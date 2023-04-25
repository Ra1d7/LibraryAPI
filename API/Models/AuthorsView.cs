using System;
using System.Collections.Generic;

namespace API.Models;

public partial class AuthorsView
{
    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string Lastname { get; set; } = null!;

    public string? TitlesWorkedOn { get; set; }
}
