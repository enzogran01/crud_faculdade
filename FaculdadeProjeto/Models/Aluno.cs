using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace FaculdadeProjeto
{
    internal class Aluno
    {
        public String ra { get; set; } = "";
        public String nome { get; set; } = "";
        public String cpf { get; set; } = "";
        public String telefone { get; set; } = "";
        public String email { get; set; } = "";
        public String senha { get; set; } = "";
        public String cd_endereco { get; set; } = "";
        public DateTime dataNascimento { get; set; }
        public bool ativo { get; set; }
    }
}
