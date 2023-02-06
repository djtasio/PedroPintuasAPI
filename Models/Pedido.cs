namespace API_PedroPinturas.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//SI QUIERO QUE NO ME MAPEE [NotMapped]
public class Pedido{
    [Key]// [Column("blog_id")]
    public int Id { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //PARA QUE INSERTE AL INSERTAR EL PRODUCTO
    public DateTime Fecha { get; set; }
    public Producto? Productos { get; set; }
    public bool Entrega24h { get; set; }
    public string? Direccion { get; set; }
    [Column(TypeName = "decimal(5, 2)")]
    public double Precio { get; set; }
}