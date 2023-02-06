namespace API_PedroPinturas.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Usuario{
    [Key]
    public int Id { get; set; }
    public string? User { get; set; }
    public string? Contrasenia { get; set; }
    public string? NombreApellidos { get; set; }
    public int Telefono { get; set; }
    public List<Pedido>? Pedidos{ get; set; }
}