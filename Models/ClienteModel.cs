using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

public class ClienteModel
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public string Email { get; set; }

    public string RamoDaEmpresa { get; set; }

    public string Telefone { get; set; }    

    public string Cidade { get; set; }

    public string GerenteId { get; set; }

    public GerenteModel Gerente { get; set; }

}
