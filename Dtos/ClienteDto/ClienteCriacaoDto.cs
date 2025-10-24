using System.ComponentModel.DataAnnotations;

public class ClienteCriacaoDto
{
    [Required(ErrorMessage = "O campo de Nome é obrigatório")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo de Email é obrigatório")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo de Ramo da empresa é obrigatório")]
    public string RamoDaEmpresa { get; set; }


    [Required(ErrorMessage = "O campo de Telefone é obrigatório")]
    public string Telefone { get; set; }  


    [Required(ErrorMessage = "O campo de Cidade é obrigatório")]
    public string Cidade { get; set; }

}