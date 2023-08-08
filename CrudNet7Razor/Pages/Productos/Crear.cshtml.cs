using CrudNet7Razor.Datos;
using CrudNet7Razor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrudNet7Razor.Pages.Productos
{
    public class CrearModel : PageModel
    {

        private readonly ApplicacionDbContext _context;

        public CrearModel(ApplicacionDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Producto Producto { get; set; }

        [TempData]

        public string mensaje { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Producto.FechaCreacion = DateTime.Now;
            _context.Add(Producto);
            await _context.SaveChangesAsync();
            mensaje = "Producto creado correctamente";
            return RedirectToPage("Index");
        }
    }
}
