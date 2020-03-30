using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Almacen02.Models
{
    public class ProductoCE
    {
        [Required]
        [Display(Name = "Ingrese fecha")]
        public System.DateTime fecha_de_creacion { get; set; }
        [Required]
        [Display(Name = "Ingrese vencimiento")]
        public System.DateTime fecha_vencimiento { get; set; }
        [Required]
        [Display(Name = "Ingrese Nombre")]
        public string nombre { get; set; }
        [Required]
        [Display(Name = "Ingrese Descripcion")]
        public string Descripcion { get; set; }
        [Required]
        [Display(Name = "Ingrese UdM")]
        public string UdM { get; set; }
        [Required]
        [Display(Name = "Ingrese precio")]
        public decimal Costo { get; set; }
        [Required]
        [Display(Name = "Ingrese existencia")]
        public string Existencia { get; set; }
        [Required]
        [Display(Name = "Ingrese estado")]
        public string Estado { get; set; }
    }
    [MetadataType(typeof(ProductoCE))]
    public partial class producto
    {

        public string nombreDE { get { return nombre + " " + Costo; } }
    }
}