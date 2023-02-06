using Microsoft.EntityFrameworkCore;
using API_PedroPinturas.Models;

namespace API_PedroPinturas.Data;

public class PedroPinturasDb : DbContext{
    public PedroPinturasDb(DbContextOptions<PedroPinturasDb> options) : base(options){
        
    }
    public DbSet<Color> Colores => Set<Color>();
    public DbSet<Pedido> Pedidos => Set<Pedido>();
    public DbSet<Producto> Productos => Set<Producto>();
    public DbSet<Usuario> Users => Set<Usuario>();
}