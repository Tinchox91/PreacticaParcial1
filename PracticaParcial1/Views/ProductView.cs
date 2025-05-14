using MVC_conJson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaParcial1.Views
{
  public static class ProductView
    {
        public static List<Producto> CargarProductos()
        {
            List<Producto> productos = new List<Producto>();
            Colors.darkWhite("Ingrese el Id: ", false);
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el nombre del producto:");
            string nombre = Console.ReadLine();           
          Colors.darkWhite("Ingrese el precio del producto: ", false);
            string precio=Valid.isPrice();
            Colors.darkWhite("Ingrese la descripcion del producto: ", false);
            string descripcion = Console.ReadLine();
            Producto producto = new Producto(id,nombre, double.Parse(precio), descripcion);
            productos.Add(producto);
            return productos;
        }
        public static void MostrarProductos(List<Producto> productos)
        {
            foreach (var producto in productos)
            {
                Console.WriteLine($"Id: {producto.Id}, Nombre: {producto.Nombre}, Precio: {producto.Precio}, Descripcion: {producto.description} Precio con IVA: {producto.aplicarIva()}");
            }
        }
    }
}
