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

        public List<int> listCountA { get; set; }
        public List<string> listDateA { get; set; }

        public List<string> listProduct { get; set; }
        public List<int> listQty { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, ApplicacionDbContext context)
        {
            _logger = logger;
            _context = context;
        }


    

        public async Task OnGet()
        {

            var productos = await _context.Producto.ToListAsync();


            CreateByMoth(productos);

            QuantityByProduct(productos);

            UpdateByMoth(productos);
            
      

        }

        public async Task CreateByMoth(List<Producto> productos)
        {

            listCount = new List<int>();
            listDate = new List<string>();

            productos.ForEach(p =>
            {
                var find = productos.FindAll(x => x.FechaCreacion.Date.ToString("yyyy'-'MM") == p.FechaCreacion.Date.ToString("yyyy'-'MM"));

                var find2 = listDate.Find(x => x.Equals(p.FechaCreacion.Date.ToString("yyyy'-'MM")));

                if (find2 == null)
                {

                    listCount.Add(((int)find.LongCount()));
                    listDate.Add(p.FechaCreacion.Date.ToString("yyyy'-'MM"));

                }
         
            });
            Console.WriteLine("--------Create---------");

            listCount.ForEach(x => Console.WriteLine(x));
            listDate.ForEach(x => Console.WriteLine(x));

        }

        public async Task QuantityByProduct(List<Producto> productos)
        {

            listProduct = new List<string>();
            listQty = new List<int>();

            productos.ForEach(p => {
            
                listProduct.Add(p.NombreProducto.ToString());
                listQty.Add(p.EnStock);
            
            });

            Console.WriteLine("--------Quantity---------");

            listProduct.ForEach(x => Console.WriteLine(x));
            listQty.ForEach(x => Console.WriteLine(x));

        }

        public async Task UpdateByMoth(List<Producto> productos)
        {

            listCountA = new List<int>();
            listDateA = new List<string>();

            productos.ForEach(p =>
            {
                var find = productos.FindAll(x => x.FechaActualizacion.Date.ToString("yyyy'-'MM") == p.FechaActualizacion.Date.ToString("yyyy'-'MM"));

                var find2 = listDateA.Find(x => x.Equals(p.FechaActualizacion.Date.ToString("yyyy'-'MM")));

                if (find2 == null && p.FechaActualizacion.Date.ToString("yyyy'-'MM").ToCharArray()[0] != '0')
                {

                    listCountA.Add(((int)find.LongCount()));
                    listDateA.Add(p.FechaActualizacion.Date.ToString("yyyy'-'MM"));

                }

            });

            Console.WriteLine("--------Update---------");

            listCountA.ForEach(x => Console.WriteLine(x));
            listDateA.ForEach(x => Console.WriteLine(x));


        }

    }
}