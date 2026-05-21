using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaculdadeProjeto
{
    internal class Matricula
    {
        public string id { get; set; }
        public DateTime data { get; set; }
        public string ativo { get; set; }
        public string turno { get; set; }
        public string ra_aluno { get; set; }
        public string nm_aluno { get; set; }
        public string id_curso { get; set; }
        public string nm_curso { get; set; }
    }
}
