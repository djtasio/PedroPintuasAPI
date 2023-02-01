using API_PedroPinturas.Data;
using API_PedroPinturas.Models;
using Microsoft.EntityFrameworkCore;


namespace API_PedroPinturas.Services;

public class PedidoService
{
    private PedroPinturasDb Db;
    
    public PedidoService(PedroPinturasDb db){
        this.Db = db;
    }

    public async Task<List<Pedido>> GetAll() {
        return await Db.Pedidos.ToListAsync();
    }

    public async Task<Pedido> Get(int id){
        return await Db.Pedidos.FindAsync(id);
    }
}