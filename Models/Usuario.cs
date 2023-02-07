namespace API_PedroPinturas.Models;
using Microsoft.EntityFrameworkCore; 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Index(nameof(User), IsUnique = true)]
public class Usuario{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? User { get; set; }
    [Required]
    public string? Contrasenia { get; set; }
    [Required]
    public string? NombreApellidos { get; set; }
    [Required]
    //[Range(8, 10)]
    public int Telefono { get; set; }
    public List<Pedido>? Pedidos{ get; set; }
}