using System.ComponentModel.DataAnnotations;

public class ClienteEdicaoDto
{
    public int Id { get; set; }
    
    [StringLength(30, MinimumLength = 3)]
    public string Nome { get; set; }

    [StringLength(30, MinimumLength = 2)]
    public string NomeDaEmpresa { get; set; }

    [StringLength(18, MinimumLength = 2)]
    public string RamoDaEmpresa { get; set; }
    
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [StringLength(15)]
    public string Telefone { get; set; }

    [StringLength(18, MinimumLength = 2)]
    public string Cidade { get; set; }

}