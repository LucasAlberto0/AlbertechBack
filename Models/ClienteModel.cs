using Microsoft.AspNetCore.Identity;

public class ClienteModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public DateOnly DataNascimento { get; set; }
    public string Cpf { get; set; }
    public string Endereco { get; set; }
}