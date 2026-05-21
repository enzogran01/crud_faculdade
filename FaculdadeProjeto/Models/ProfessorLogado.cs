using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaculdadeProjeto.Models
{
    internal static class ProfessorLogado
    {
        public static String id { get; set; } = "";
        public static String nome { get; set; } = "";
        public static String cpf { get; set; } = "";
        public static String telefone { get; set; } = "";
        public static String email { get; set; } = "";
        public static String senha { get; set; } = "";
        public static bool ativo { get; set; }

        public static bool logOff()
        {
            id = "";
            nome = "";
            cpf = "";
            telefone = "";
            email = "";
            senha = "";
            ativo = false;
            return false;
        }
    }
}
