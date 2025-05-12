using System;
using System.Globalization;
using System.Net.Mail;

namespace PracticaParcial1
{
   public static class Valid
    {
        
       public static bool validMail(string mail)
        {
            if (string.IsNullOrEmpty(mail)||string.IsNullOrWhiteSpace(mail))
            {
                Colors.red("El mail no puede ser nulo o vacio ni contener solo espacios ");
                return false;
            }
            else
            {
                try
                {
                    var email = new MailAddress(mail);
                    return true;
                }
                catch (FormatException)
                {
                    
                    return false;
                }
            }
              

        }
        public static void validMailMessage(string mail)
        {
            if (!string.IsNullOrEmpty(mail)||!string.IsNullOrWhiteSpace(mail))
            {
                try
                {
                    var email = new MailAddress(mail);
                    Colors.green("El mail es valido");
                }
                catch (FormatException e)
                {
                    Colors.red("El mail no es valido!!: ");
                    Colors.darkGray(e.Message);
                }
            }
          

        }
        public static void validBucleMail(string mail)
        {
            bool val = false;
            do
            {
        val=  Valid.validMail(mail);
                validMailMessage(mail);
                Colors.darkBlue("Ingrese de nuevo: ");
                    mail = Console.ReadLine();
                
            } while (!val);
        }    
        
        public static DateTime? validDate(string date)
        {
            if (string.IsNullOrEmpty(date) || string.IsNullOrWhiteSpace(date))
            {
                Colors.red("La fecha no puede ser nula o vacía ni contener solo espacios ");
                return null;
            }
            else
            {
                try
                {
                    var fecha = DateTime.Parse(date);
                    return fecha;
                }
                catch (FormatException)
                {
                    Colors.red("La fecha no es válida");
                    return null;
                }
            }
        }


    }
}
