using MVC_conJson.Models;
using PracticaParcial1.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaParcial1.Views
{
   public static class OrderView
    {
        public static void menuPrincipal() {
            bool exit = false;
            OrderController ct = new OrderController();
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("1.Crear Pedido");
                Console.WriteLine("2.Mostrar Pedidos");
                Console.WriteLine("3.Eliminar Pedido");
                Console.WriteLine("4.Buscar Pedido");
                Console.WriteLine("5.Modificar Pedido");
                Console.WriteLine("6.Salir");
                Console.WriteLine("Ingrese una opción:");
                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        Colors.green("Crear Pedido");                       
                        ct.createOrder(createOrderView());
                        Colors.green("Pedido creado con éxito.");
                        Console.ReadKey();
                        break;
                    case "2":
                        Colors.green("Mostrar Pedidos");
                      OrderView.mostrarPedidosView(  ct.mostrarPedidos());
                                             
                        Console.ReadKey();
                        break;
                    case "3":
                        Colors.green("Eliminar Pedido");
                        break;
                    case "4":
                        Colors.green("Buscar Pedido");
                        break;
                    case "5":
                        Colors.green("Modificar Pedido");
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Colors.red("Opción no válida. Intente nuevamente.");
                        Console.ReadKey();
                        break;
                }

            }
        }
        public static Pedido createOrderView()
        {
           Pedido pedido = new Pedido();           
            Colors.white("Ingrese el nombre del cliente: ",false);
            string nombre = Console.ReadLine();
                       Colors.white("Ingrese el apellido del cliente: ", false);
            string apellido = Console.ReadLine();           
            Colors.white("Ingrese el dni del cliente: ", false);
            string dni = Console.ReadLine();
            Colors.white("Ingrese el telefono del cliente: ", false);           
            string telefono = Console.ReadLine();           
            Colors.white("Ingrese la direccion del cliente: ", false);
            string direccion = Console.ReadLine();          
            Colors.white("Ingrese el email del cliente: ", false);
            // Validar el formato del email
            bool isValidEmail = false;
            string email="";
            while (!isValidEmail)
            {
              email = Console.ReadLine();
                if (Valid.validMail(email))
                {
                    isValidEmail = true;
                }
                else
                {                   
                    Colors.red("El email no es valido!!: ");
                }
            }

            
            pedido.cliente = new Cliente(nombre,apellido,dni,direccion,telefono,email);
            List<Producto> productos = new List<Producto>();
            bool agregarProducto = true;
            while (agregarProducto)
            {
                Console.WriteLine("Ingrese el id del producto:");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el nombre del producto:");
                string nombreProducto = Console.ReadLine();
                Console.WriteLine("Ingrese el precio del producto:");
                double precio = double.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese la marca del producto:");
                string marca = Console.ReadLine();
                productos.Add(new Producto(id, nombreProducto, precio, marca));
                Console.WriteLine("¿Desea agregar otro producto? (s/n)");
                string respuesta = Console.ReadLine();
                if (respuesta.ToLower() != "s")
                {
                    agregarProducto = false;
                }
            }
            pedido.productos = productos;
            return pedido;
            Colors.green("Pedido creado con éxito.");
        }
public static void eliminarPedidoView()
        {
            Console.WriteLine("Ingrese el DNI del cliente para eliminar su pedido:");
            string dni = Console.ReadLine();
            OrderController ct = new OrderController();
            Pedido pedido = ct.buscarPedidoDniCliente(dni);
            if (pedido != null)
            {
                ct.eliminarPedidoDniCliente(dni);
                Colors.green("Pedido eliminado con éxito.");
            }
            else
            {
                Colors.red("No se encontró un pedido con ese DNI.");
            }
        }
        public static void mostrarPedidosView(List<Pedido> pedidos)
        {
            if (pedidos.Count == 0)
            {
                Console.WriteLine("No se encontraron registros en ordenes.json.");
            }
            else
            {
                foreach (var pedido in pedidos)
                {
                   Colors.darkBlue("------------------------------------------------------");
                    Console.WriteLine($"Cliente: {pedido.cliente.nombre}");
                    Console.WriteLine($"Productos: {string.Join(", ", pedido.productos.Select(p => p.Nombre))}");
                }
            }
        }
    }
}
