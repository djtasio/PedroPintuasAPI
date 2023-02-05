namespace API_PedroPinturas.Models;
using Microsoft.EntityFrameworkCore; 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Index(nameof(Username), IsUnique = true)]
public class User : Model{
    [Required]
    public string? Username { get; set; }
    [Required]
    public string? Password { get; set; }
    [Required]
    public string? NombreApellidos { get; set; }
    public int Telefono { get; set; }
    public List<Pedido>? Pedidos{ get; set; }
}