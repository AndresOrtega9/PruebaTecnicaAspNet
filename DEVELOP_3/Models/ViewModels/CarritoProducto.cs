using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DEVELOP_3.Models.ViewModels
{
    public class CarritoProducto
    {
        public int Id { get; set; }
        public Nullable<int> Id_Producto { get; set; }
        public Nullable<int> Cantidad { get; set; }
        [Display(Name ="Costo total")]
        public Nullable<decimal> CostoTotal { get; set; }

        public virtual Producto Producto { get; set; }
        public Nullable<decimal> Costo { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        [Display(Name = "U/Medida")]
        public string Unidad_Medida { get; set; }
        public byte[] Imagen { get; set; }
    }
}