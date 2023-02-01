namespace API_PedroPinturas.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User{
    [Key]
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? NombreApellidos { get; set; }
    public int Telefono { get; set; }
    public List<Pedido>? Pedidos{ get; set; }
}