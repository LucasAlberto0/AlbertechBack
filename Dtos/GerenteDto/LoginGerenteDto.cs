using System.ComponentModel.DataAnnotations;

public class LoginGerenteDto
{
    [Required]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
}