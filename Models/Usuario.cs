using System;
using System.Collections.Generic;

namespace mrteam.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }
}
