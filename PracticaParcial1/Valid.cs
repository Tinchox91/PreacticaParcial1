using System;
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

    }
}
