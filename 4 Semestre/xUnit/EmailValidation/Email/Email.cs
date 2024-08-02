using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email
{
    public static class Email
    {
        public static bool ValidarEmail(string email)
        {
            if (email.Contains('@') && email.Contains('.'))
            {
                return true;
            }

            return false;
        }
    }
}
