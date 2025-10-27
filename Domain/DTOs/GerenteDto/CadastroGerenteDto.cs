using System.ComponentModel.DataAnnotations;

public class CadastroGerenteDto
{
    [DataType(DataType.Text)]
    [StringLength(30, MinimumLength = 3)]
    [Required(ErrorMessage = "O campo de nome é obrigatório")]
    public string Nome { get; set; }

    [DataType(DataType.EmailAddress)]
    [StringLength(128)]
    [Required(ErrorMessage = "O campo de email é obrigatório")]
    public string Email { get; set; }

    [StringLength(18, MinimumLength = 2)]
    [Required(ErrorMessage = "O campo de empresa é obrigatório")]
    public string? Empresa { get; set; }

    [StringLength(255, MinimumLength = 8)]
    [Required(ErrorMessage = "O campo de senha é obrigatório")]
    public string Senha { get; set; }

    [Compare("Senha")]
    [StringLength(255, MinimumLength = 8)]
    [Required(ErrorMessage = "O campo de senha é obrigatório")]
    public string ConfirmarSenha { get; set; }

}