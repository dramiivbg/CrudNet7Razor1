using CrudNet7Razor.Modelos;
using Microsoft.EntityFrameworkCore;

namespace CrudNet7Razor.Datos
{
    public class ApplicacionDbContext: DbContext
    {

        public ApplicacionDbContext(DbContextOptions<ApplicacionDbContext> options) : base(options) 
        { 


        }

        public DbSet<Producto> Producto { get; set; }
    }
}
