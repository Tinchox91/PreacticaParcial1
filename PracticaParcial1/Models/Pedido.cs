using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_conJson.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public Cliente cliente { get; set; }
        public List<Producto> productos { get; set; }

        public Pedido(Cliente cliente, List<Producto> productos)
        {
            this.cliente = cliente;
            this.productos = productos;
        }
        public Pedido()
        {
        }
        public double calcularTotal()
        {
        return this.productos.Sum(p => p.Precio);
        }
        public double calcularTotalConIva()
        {
            return this.productos.Sum(p => p.aplicarIva());
        }
        public List<Producto> GetProductos()
        {
            return this.productos;
        }


    }
}
