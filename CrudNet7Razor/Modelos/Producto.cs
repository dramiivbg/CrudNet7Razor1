using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CrudNet7Razor.Modelos
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre del producto")]
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }

        [Display(Name = "cantidad en Stock")]
        public int EnStock { get; set; }

        public int precio { get; set; }

        [Display(Name = "Fecha de creacion")]
        public DateTime FechaCreacion { get; set; }

        [AllowNull]
        public DateTime FechaActualizacion { get; set; }



    }
}
