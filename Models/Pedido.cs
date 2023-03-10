namespace API_PedroPinturas.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//SI QUIERO QUE NO ME MAPEE [NotMapped]
public class Pedido{
    [Key]// [Column("blog_id")]
    public int Id { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //PARA QUE INSERTE AL INSERTAR EL PRODUCTO
    //[Column("created_at")]
    public DateTime Fecha { get; set; } = DateTime.UtcNow;
    public ICollection<Compra>? Compras { get; set; }
    public bool Entrega24h { get; set; }
    public string? Direccion { get; set; }
    [Column(TypeName = "decimal(5, 2)")]
    public double Precio { get; set; }

    [ForeignKey("Usuario")]
    public int IdUsuario {get;set;}
    public Usuario? Usuario {get;set;}
}