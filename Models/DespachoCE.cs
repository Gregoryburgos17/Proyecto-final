using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Almacen02.Models
{
    public class DespachoCE
    {
        [Required]
        [Display(Name = "Ingrese FECHA")]
        public System.DateTime fecha { get; set; }
        [Required]
        [Display(Name = "Ingrese TIPO DE ACCION")]
        public string tipo_de_acciom { get; set; }
        [Required]
        [Display(Name = "Ingrese CLIENTE")]
        public int cliente { get; set; }
        [Required]
        [Display(Name = "Ingrese CONTACTOS")]
        public string contactos { get; set; }
        [Required]
        [Display(Name = "Ingrese numero de producto")]
        public int Detalle_de_productos { get; set; }
        [Required]
        [Display(Name = "Ingrese Cantidad de productos")]
        public Nullable<decimal> cant_producto { get; set; }

       

        public virtual clientes clientes { get; set; }
        public virtual producto producto { get; set; }
    }
    [MetadataType(typeof(DespachoCE))]
    public partial class Despacho
    {
        public string nombredata { get { return cliente + " " + Detalle_de_productos; } }
    }
}