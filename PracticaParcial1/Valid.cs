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
        public static string validBucleMail()
        {
            bool val = false;
            do
            {
                string mail = Console.ReadLine();
                val =  Valid.validMail(mail);
                validMailMessage(mail);
                Colors.darkBlue("Ingrese de nuevo: ");
                    mail = Console.ReadLine();
                return mail;
            } while (!val);
        }

        public static DateTime? validDate()
        {
            bool isValid = false;
            do
            {
             string date = Console.ReadLine();
                Colors.yellow($"DEBUG: Leído '{date}'");
                if (string.IsNullOrEmpty(date) || string.IsNullOrWhiteSpace(date))
                {
                    Colors.red("La fecha no puede ser nula o vacía ni contener solo espacios ");
                    isValid = false;
                }
                else
                {
                    try
                    {
                        var fecha = DateTime.Parse(date);
                        isValid = true;
                        return fecha;
                    }
                    catch (FormatException)
                    {
                        Colors.red("La fecha no es válida");
                        isValid = false;
                    }
                }
            } while (!isValid);

            return null;
        }



        public static string isNumber()
        {
            bool isValid = false;
            string input = string.Empty;
            do
            {       
               input= Console.ReadLine();
                isValid = int.TryParse(input, out int number);
                if (isValid && !string.IsNullOrEmpty(input) && !string.IsNullOrWhiteSpace(input) )
                {
                  return input;
                }
                else
                {
                    Colors.red("Ingreso invalido!!");
               
                }
            } while (!isValid);
            return null;
        }
        public static string isPrice()
        {
            bool isValid = false;
            string input = string.Empty;
            do
            {
                input = Console.ReadLine();
                isValid = double.TryParse(input, out double number);
                if (isValid && !string.IsNullOrEmpty(input) && !string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }
                else
                {
                    Colors.red("Ingreso invalido!!");

                }
            } while (!isValid);
            return null;
        }
    }
}
