using System.ComponentModel.DataAnnotations;

public class CadastroGerenteDto
{
    [DataType(DataType.Text)]
    [StringLength(30)]
    [Required()]
    public string Nome { get; set; }

    [DataType(DataType.EmailAddress)]
    [StringLength(128)]
    [Required()]
    public string Email { get; set; }

    public string? Empresa { get; set; }

    [StringLength(255, MinimumLength = 8)]
    [Required()]
    public string Senha { get; set; }

    [Compare("Senha")]
    [StringLength(255, MinimumLength = 8)]
    [Required()]
    public string ConfirmarSenha { get; set; }

}