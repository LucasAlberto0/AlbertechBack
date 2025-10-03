using System.ComponentModel.DataAnnotations;

public class CadastroGerenteDto
{
    [Required]
    public string Nome { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public DateOnly DataNascimento { get; set; }
    [Required]
    public string Cpf { get; set; }

    [Required]
    public string Empresa { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [Compare("Password")]
    public string RePassword { get; set; }
}