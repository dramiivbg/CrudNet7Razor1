using CrudNet7Razor.Datos;
using CrudNet7Razor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Reflection.Metadata;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CrudNet7Razor.Pages
{
    public class IndexModel : PageModel
    {



        private readonly ApplicacionDbContext _context;

        public List<int> listCount { get; set; }
        public List<string> listDate { get; set; }


        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, ApplicacionDbContext context)
        {
            _logger = logger;
            _context = context;
        }


    

        public async Task OnGet()
        {

            var productos = await _context.Producto.ToListAsync();

            listCount = new List<int>();
            listDate = new List<string>();

            productos.ForEach(p =>
            {
                var find = productos.FindAll(x => x.FechaCreacion == p.FechaCreacion);
                listCount.Add(((int)find.LongCount()));
                listDate.Add(p.FechaCreacion.Date.ToString("yyyy'-'MM"));

            });

            
            Console.WriteLine(listDate.Count);
            Console.WriteLine(listCount.Count);
         
            
      

        }
    
    }
}