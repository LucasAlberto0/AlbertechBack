using Microsoft.AspNetCore.Identity;
using System;

public class GerenteModel : IdentityUser
{
    public string Nome { get; set; } = string.Empty;
    
    public string? Empresa { get; set; }        
}
