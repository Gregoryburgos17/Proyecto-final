using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Almacen02.Models
{
    public class ClienteCE
    {
        [Required]
        [Display(Name = "Ingrese Nombre")]
        public string nombre { get; set; }
        [Required]
        [Display(Name = "Ingrese Apellidos")]
        public string apellido { get; set; }
        [Required]
        [Display(Name = "Ingrese Direccion")]
        public string direccion { get; set; }
        [Required]
        [Display(Name = "Ingrese telefono")]
        public int telefono { get; set; }
        [Required]
        [Display(Name = "Ingrese correo")]
        public string correo { get; set; }
        [Required]
        [Display(Name = "Ingrese tipo de cliente")]
        public string tipo_de_cliente { get; set; }
    }
    [MetadataType(typeof(ClienteCE))]
    public partial class clientes
    {
        public string nombrecompleto { get { return nombre + " " + apellido; } }
    }
}