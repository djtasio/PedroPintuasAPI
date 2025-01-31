namespace API_PedroPinturas.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Producto{
    [Key]
    public int Id { get; set; }
    public Color? Color { get; set; }
    public double Precio { get; set; }
    public string? Descripcion { get; set; }
    public string? Calidad { get; set; }
    public string? Productos { get; set; }
}