namespace API_PedroPinturas.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Pedido : Model{
    public DateTime Fecha { get; set; }
    public Producto? Productos { get; set; }
    public bool Entrega24h { get; set; }
    public string? Direccion { get; set; }
    public double Precio { get; set; }
}