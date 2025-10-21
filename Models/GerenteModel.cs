using Microsoft.AspNetCore.Identity;
using System;

public class GerenteModel : IdentityUser
{
    public string Nome { get; set; } = string.Empty;
    public DateTime DataNascimento { get; set; } 
    public string Cpf { get; set; } = string.Empty;
    public string? Endereco { get; set; }        
    public string? Empresa { get; set; }        
}
