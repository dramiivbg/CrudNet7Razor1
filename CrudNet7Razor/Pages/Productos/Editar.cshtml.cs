using CrudNet7Razor.Datos;
using CrudNet7Razor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrudNet7Razor.Pages.Productos
{
    public class EditarModel : PageModel
    {


        private readonly ApplicacionDbContext _context;

        public EditarModel(ApplicacionDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Producto Producto { get; set; }

        [TempData]
        public string mensaje { get; set; }
        public async Task OnGet(int id)
        {
            Producto = await _context.Producto.FindAsync(id);
        }


        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var CursodesdeDB = await _context.Producto.FindAsync(Producto.Id);

                CursodesdeDB.NombreProducto = Producto.NombreProducto;
                CursodesdeDB.Descripcion = Producto.Descripcion;
                CursodesdeDB.EnStock = Producto.EnStock;
                CursodesdeDB.precio = Producto.precio;

                await _context.SaveChangesAsync();
                mensaje = "Producto Editado correctamente";
                return RedirectToPage("Index");
            }


            return RedirectToPage();
        }
    }
}
