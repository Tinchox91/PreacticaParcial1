using MVC_conJson.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace PracticaParcial1.Controllers
{
   public class OrderController
    {
       private string basePath = AppDomain.CurrentDomain.BaseDirectory;
        private string directoryPath;
        public OrderController()
        {
            directoryPath = Path.Combine(basePath, "..", "..", "..", "Repository", "Data");
        }
        public void createOrder(Pedido pedido)
        {            
            pedido.Id = ObtenerProximoId();
            Repository.Repository<Pedido>.Agregar(Path.Combine(directoryPath, "ordenes"), pedido);
          Repository.Repository<Pedido>.Agregar("ordenes",pedido);
        }

        public List<Pedido> mostrarPedidos()
        {
           return Repository.Repository<Pedido>.ObtenerTodos(Path.Combine(directoryPath, "ordenes"));
        }




        public void eliminarPedidoDniCliente(string dniCliente)
        {
            Repository.Repository<Pedido>.Eliminar(Path.Combine(directoryPath, "ordenes"), c => c.cliente.dni == dniCliente);
        }
      public Pedido buscarPedidoDniCliente(string dni)
        {
            return Repository.Repository<Pedido>.ObtenerTodos(Path.Combine(directoryPath, "ordenes")).FirstOrDefault(c => c.cliente.dni == dni);
        }
        public void modificarPedido(Pedido pedido)
        {
            Repository.Repository<Pedido>.Actualizar(Path.Combine(directoryPath, "ordenes"), c => c.Id == pedido.Id, pedido);
        }


        private int ObtenerProximoId()
        {
            var ordenes = Repository.Repository<Pedido>.ObtenerTodos(Path.Combine(directoryPath, "ordenes"));
            if (ordenes == null || ordenes.Count == 0)
                return 1;
            return ordenes.Max(c => Convert.ToInt32(c.Id)) + 1;
        }
    public int total()
        {
            var ordenes = Repository.Repository<Pedido>.ObtenerTodos(Path.Combine(directoryPath, "ordenes"));
            if (ordenes == null || ordenes.Count == 0)
                return 0;
            return ordenes.Sum(c => Convert.ToInt32(c.calcularTotal()));
        }

    }
}
