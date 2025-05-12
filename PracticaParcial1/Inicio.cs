using Microsoft.VisualBasic;
using MVC_conJson.Models;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Linq;
using System.IO;
namespace PracticaParcial1
{
    internal class Inicio
    {
        static void Main(string[] args)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string directoryPath = Path.Combine(basePath, "..", "..", "..", "Repository", "Data");

            //Cliente cliente = new Cliente("Sisal", "Esperemos", "54616", "Tu sabee", "6512165", "suaveRico@gmail.com");
            //List<Producto> productos = new List<Producto>();
            //productos.Add(new Producto(01, "Lazaña", 100, "Marollio"));
            //productos.Add(new Producto(34, "Salsa", 200, "No puede faltar!"));
            //Pedido pedido = new Pedido(cliente, productos);

            ////Repository.Repository<Pedido>.Agregar(Path.Combine(directoryPath, "ordenes"), pedido);
            //Repository.Repository<Pedido>.Agregar("ordenes",pedido);


            List<Pedido> pedidos = Repository.Repository<Pedido>.ObtenerTodos(Path.Combine(directoryPath, "ordenes"));

            if (pedidos.Count == 0)
            {
                Console.WriteLine("No se encontraron registros en ordenes.json.");
            }
            else
            {
                foreach (var pedido in pedidos)
                {
                    Console.WriteLine($"Cliente: {pedido.cliente.nombre}");
                    Console.WriteLine($"Productos: {string.Join(", ", pedido.productos.Select(p => p.Nombre))}");
                }
            }


        }
    }

}