namespace API_PedroPinturas.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class UsuarioEvento
{
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }

    public int EventoId { get; set; }
    public Evento Evento { get; set; }
    
    [Key]
    public int Id { get; set; }
}