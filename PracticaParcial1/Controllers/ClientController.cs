using MVC_conJson.Models;
using PracticaParcial1.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaParcial1.Controllers
{
   public class ClientController
    {
        public Cliente CargarClient() => ClientView.CargarCliente();        
        public void MostarCliente(Cliente c) => ClientView.MostrarCliente(c);
    }
}
