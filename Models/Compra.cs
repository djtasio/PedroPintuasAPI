namespace API_PedroPinturas.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Compra{
    [Key]
    public int Id { get; set; }
    public Producto? Producto { get; set; }
    public int Cantidad { get; set; }

    [ForeignKey("Pedido")]
    public int PedidoId { get; set; }
    public Pedido? pedido { get; set; }
}