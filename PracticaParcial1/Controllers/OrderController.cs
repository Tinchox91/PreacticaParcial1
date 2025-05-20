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
        private List<Pedido> pedidos;
      public  int conteoID;
        public OrderController()
        {
            directoryPath = Path.Combine(basePath, "..", "..", "..", "Repository", "Data");
            pedidos= Repository.Repository<Pedido>.ObtenerTodos(Path.Combine(directoryPath, "ordenes"));
            conteoID = pedidos.Count;
        }
        public void createOrder(Pedido pedido)       
        {            
           pedido.Id = conteoID + 1;
            Repository.Repository<Pedido>.Agregar(Path.Combine(directoryPath, "ordenes"), pedido);
          Repository.Repository<Pedido>.Agregar("ordenes",pedido);
        }


        public List<Pedido> mostrarPedidos()
        {
           return Repository.Repository<Pedido>.ObtenerTodos(Path.Combine(directoryPath, "ordenes"));
        }


      public void eliminarPedido(string a)
        {
            Repository.Repository<Pedido>.Eliminar(Path.Combine(directoryPath, "ordenes"), p=> p.Id ==int.Parse(a));
        }   



        public void modificarPedido(Pedido pedido)
        {
            Repository.Repository<Pedido>.Actualizar(Path.Combine(directoryPath, "ordenes"), c => c.Id == pedido.Id, pedido);
        }


       

    }
}
