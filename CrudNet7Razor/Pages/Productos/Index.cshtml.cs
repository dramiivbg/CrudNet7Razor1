using CrudNet7Razor.Datos;
using CrudNet7Razor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CrudNet7Razor.Pages.Productos
{
    public class IndexModel : PageModel
    {
        private readonly ApplicacionDbContext _context;

        public IndexModel(ApplicacionDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Producto> Productos { get; set; }
        public async Task OnGet()
        {
            Productos = await _context.Producto.ToListAsync();
        }


        [TempData]
        public string mensaje { get; set; }

        public async Task<IActionResult> OnPostBorrar(int id)
        { 
            var producto = await _context.Producto.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            
            _context.Producto.Remove(producto);

            await _context.SaveChangesAsync();
            mensaje = "Producto borrado correctamente";
            return  RedirectToPage("Index");
        }
    }
}
