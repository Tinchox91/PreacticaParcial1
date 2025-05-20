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
      private static OrderController ct = new OrderController();
        public static void menuPrincipal() {
            bool exit = false;
            
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
                        Console.ReadKey();
                        break;
                    case "2":
                        Colors.green("Mostrar Pedidos");
                      OrderView.mostrarPedidosView(  ct.mostrarPedidos());
                                             
                        Console.ReadKey();
                        break;
                    case "3":
                        Colors.green("Eliminar Pedido");
                        ct.eliminarPedido(eliminarPedidoView());
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
        public static Pedido? createOrderView()
        {
            try
            {
             
                Pedido pedido = new Pedido();
           
                pedido.Id = ct.conteoID+1;
                pedido.cliente = ClientView.CargarCliente();
                pedido.productos = ProductView.CargarProductos();
                Colors.green("Pedido creado con éxito.");
                return pedido;
            }
            catch (Exception)
            {
                Colors.red("Error al crear el pedido.");
                return null;
                throw;
            }

           
        }

public static string eliminarPedidoView()
        {
            Console.Clear();
          OrderView.mostrarPedidosView(ct.mostrarPedidos());
            Colors.white("Ingrese el id del pedido a eliminar: ", false);
           string inde = Valid.isNumber();
            int index = int.Parse(inde);
            var pedidos = ct.mostrarPedidos();
            bool validar = false;
            do
            {
                if (index < 0 || index >= pedidos.Count)
                {
                    validar = true;
                    Colors.red("El pedido no existe.");
                }
                else
                {
                          return inde;
                    validar = false;
                    
                }
     return inde;
            } while (validar);
          


        }

        public static void mostrarPedidosView(List<Pedido> pedidos)
        {
            if (pedidos.Count == 0)
            {
                Console.WriteLine("No se encontraron registros en ordenes.json.");
            } else
            {
                Colors.cyan("Lista de pedidos:");
                foreach (var pedido in pedidos)
                {
                    Colors.darkBlue($"Id del pedido: {pedido.Id} ");
                    ClientView.MostrarCliente(pedido.cliente);
                    Colors.blue("Productos: ");
                    ProductView.MostrarProductos(pedido.productos);
                }
               
               
            }
    }
    }
}
