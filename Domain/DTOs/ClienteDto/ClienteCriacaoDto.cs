using System.ComponentModel.DataAnnotations;

public class ClienteCriacaoDto
{
    [DataType(DataType.Text)]
    [StringLength(30, MinimumLength = 3)]
    [Required(ErrorMessage = "O campo de nome é obrigatório")]
    public string Nome { get; set; }

    [StringLength(30, MinimumLength = 3)]
    [Required(ErrorMessage = "O campo de nome da empresa é obrigatório")]
    public string NomeDaEmpresa { get; set; }

    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "O campo de email é obrigatório")]
    public string Email { get; set; }

    [StringLength(18, MinimumLength = 3)]
    [Required(ErrorMessage = "O campo de ramo da empresa é obrigatório")]
    public string RamoDaEmpresa { get; set; }


    [Required(ErrorMessage = "O campo de telefone é obrigatório")]
    public string Telefone { get; set; }  

    [StringLength(18)]
    [Required(ErrorMessage = "O campo de cidade é obrigatório")]
    public string Cidade { get; set; }

    [StringLength(10, MinimumLength = 3)]
    [Required(ErrorMessage = "O campo de status é obrigatório")]
    public string Status { get; set; }
}