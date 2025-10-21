using System.ComponentModel.DataAnnotations;

public class CadastroGerenteDto
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime DataNascimento { get; set; }
    public string? Endereco { get; set; }
    public string? Empresa { get; set; }
    public string Cpf { get; set; }
}