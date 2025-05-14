using MVC_conJson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaParcial1.Views
{
   public static class ClientView
    {
        public static Cliente CargarCliente()
        {
            try
            {
                Cliente cliente = new Cliente();
                Colors.darkWhite("Ingrese nombre: ", false);
                cliente.nombre = Console.ReadLine();
                Colors.darkWhite("Ingrese apellido: ", false);
                cliente.apellido = Console.ReadLine();
                Colors.darkWhite("Ingrese dni: ", false);
                cliente.dni = Valid.isNumber();
                Colors.darkWhite("Ingrese direccion: ", false);
                cliente.direccion = Console.ReadLine();
                Colors.darkWhite("Ingrese telefono: ", false);
                cliente.telefono = Valid.isNumber();
                Colors.darkWhite("Ingrese email: ", false);
                cliente.email = Valid.validBucleMail();
                return cliente;

            }
            catch (Exception e)
            {
                Colors.red("Error al cargar el cliente. ", false);
                Colors.red(e.Message);
                return null;
                throw;
            }
        

        }
        public static void MostrarCliente(Cliente c)
        {
            Colors.blue("Nombre: ", false);
            Colors.green(c.nombre);
            Colors.blue("Apellido: ", false);
            Colors.green(c.apellido);
            Colors.blue("DNI: ", false);
            Colors.green(c.dni);
            Colors.blue("Direccion: ", false);
            Colors.green(c.direccion);
            Colors.blue("Telefono: ", false);
            Colors.green(c.telefono);
            Colors.blue("Email: ", false);
            Colors.green(c.email);           



        }
    }
}
