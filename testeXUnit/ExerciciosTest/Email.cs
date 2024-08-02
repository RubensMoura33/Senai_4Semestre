using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicios
{
    public class Email
    {
        public static bool VerficarEmail (string email)
        {
            if (email.Contains("@") && email.Contains("."))
            {
                return true;
            }

            return false;
        }
    }
}
