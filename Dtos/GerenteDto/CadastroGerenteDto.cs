using System.ComponentModel.DataAnnotations;

public class CadastroGerenteDto
{
    [Required]
    public string Nome { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public DateTime DataNascimento { get; set; }
    [Required]
    public double Cpf { get; set; }

    [Required]
    public int Empresa { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [Compare("Password")]
    public string RePassword { get; set; }
}