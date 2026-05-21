using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaculdadeProjeto.Models
{
    internal class AlunoLogado
    {
        public static String ra { get; set; } = "";
        public static String nome { get; set; } = "";
        public static String cpf { get; set; } = "";
        public static String telefone { get; set; } = "";
        public static String email { get; set; } = "";
        public static String senha { get; set; } = "";
        public static String cd_endereco { get; set; } = "";
        public static DateTime dataNascimento { get; set; }
        public static bool ativo { get; set; }

        public static bool logOff()
        {
            ra = "";
            nome = "";
            cpf = "";
            telefone = "";
            email = "";
            senha = "";
            cd_endereco = "";
            dataNascimento = DateTime.MinValue;
            ativo = false;
            return false;
        }
    }
}
