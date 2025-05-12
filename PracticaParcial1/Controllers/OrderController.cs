using MVC_conJson.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
     public int ObtenerProximoId()
        {
            var ordenes = Repository.Repository<Pedido>.ObtenerTodos(Path.Combine(directoryPath, "ordenes"));
            if (ordenes == null || ordenes.Count == 0)
                return 1;
            return ordenes.Max(c => Convert.ToInt32(c.Id)) + 1;
        }
   
    }
}
