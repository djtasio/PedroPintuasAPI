using API_PedroPinturas.Data;
using API_PedroPinturas.Models;
using Microsoft.EntityFrameworkCore;


namespace API_PedroPinturas.Services;

public class ColorService
{
    private PedroPinturasDb Db;
    
    public ColorService(PedroPinturasDb db){
        this.Db = db;
    }

    public async Task<List<Color>> GetAll() {
        return await Db.Colores.ToListAsync();
    }

    public async Task<Color> Get(int id){
        return await Db.Colores.FindAsync(id);
    }
}