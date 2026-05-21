using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaculdadeProjeto.Models
{
    internal class AdminLogado
    {
        public static string id { get; set; }
        public static string nome { get; set; }
        public static string email { get; set; }
        public static string senha { get; set; }

        public static bool logoff()
        {
            id = "";
            nome = "";
            email = "";
            senha = "";
            return false;
        }
    }
}
