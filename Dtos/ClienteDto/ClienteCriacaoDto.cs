using System.ComponentModel.DataAnnotations;

public class ClienteCriacaoDto
{

    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo de Email é obrigatório")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório")]
    public DateOnly DataNascimento { get; set; }

    [Required(ErrorMessage = "O campo de Cpf é obrigatório")]
    
    public string Cpf { get; set; }
    
    public string Endereco { get; set; }
}