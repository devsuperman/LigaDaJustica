using LigaDaJustica.Models;
using Microsoft.EntityFrameworkCore;

namespace LigaDaJustica.Data
{
    public class Contexto : DbContext{
    
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
                
        public DbSet<SuperHeroi> SuperHerois {get;set;}        

    }
}
