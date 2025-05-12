using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_conJson.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public string description { get; set; }

        public Producto(int id, string nombre, double precio, string description)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            this.description = description;
        }
        public Producto()
        {
        }
        public double aplicarIva()
        {
            return this.Precio * 1.21;
        }
    }
}
