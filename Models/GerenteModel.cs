using Microsoft.AspNetCore.Identity;

public class GerenteModel 
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public DateTime DataNascimento { get; set; }
    public double Cpf { get; set; }
    public string Endereco { get; set; }
    public int Empresa { get; set; }
}