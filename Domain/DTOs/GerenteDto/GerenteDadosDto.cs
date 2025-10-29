public class GerenteDadosDto
{
    public string Nome { get; set; }

    public string Email { get; set; }
    
    public string Empresa { get; set; }

    public int TotalClientes { get; set; }

    public int ClientesAtivos { get; set; }

    public int ClientesEmNegociacao { get; set; }

    public int ClientesInativos { get; set; }
}