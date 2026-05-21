using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaculdadeProjeto
{
    internal class BLL
    {
        // hash senha
        private static string HashSenha(string senha)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }
        // professor

        public static void validaEntradaProfessor(Professor professor)
        {

            // verifica email
            if (professor.email.Length == 0)
            {
                Erro.setMsg("O campo email é obrigatório.");
                return;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(professor.email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                Erro.setMsg("Email inválido.");
                return;
            }
            // verifica senha
            if (professor.senha.Length < 8)
            {
                Erro.setMsg("A senha deve ter entre 8 e 20 caracteres.");
                return;
            }
            else
            {
                professor.senha = HashSenha(professor.senha);
            }

            Erro.setMsg("");
            Erro.setErro(false);
            DAL.LoginProfessor(professor);
        }
        public static void validaIDProfessor(Professor professor, char op)
        {
            Erro.setMsg("");
            Erro.setErro(false);
            if (professor.id == null)
            {
                Erro.setMsg("O ID é de preenchimento obrigatório.");
                return;
            }
            if (op == 'c')
                DAL.consultaProfessor(professor);
            else
            {
                //DAL.deletaAluno(aluno);
            }
        }

        public static void validaDadosProfessor(Professor professor, char op)
        {
            Erro.setMsg("");
            Erro.setErro(false);
            // verifica nome
            if (professor.nome.Length == 0)
            {
                Erro.setMsg("O campo nome é obrigatório.");
                return;
            }
            // verifica CPF
            if (professor.cpf.Length == 0)
            {
                Erro.setMsg("O campo CPF é obrigatório.");
                return;
            }
            else if (!long.TryParse(professor.cpf, out _))
            {
                Erro.setMsg("O CPF deve conter apenas números.");
                return;
            }
            // verifica telefone
            if (professor.telefone.Length == 0)
            {
                Erro.setMsg("O campo telefone é obrigatório.");
                return;
            }
            else if (!long.TryParse(professor.telefone, out _))
            {
                Erro.setMsg("O telefone deve conter apenas números.");
                return;
            }
            // verifica email
            if (professor.email.Length == 0)
            {
                Erro.setMsg("O campo email é obrigatório.");
                return;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(professor.email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                Erro.setMsg("Email inválido.");
                return;
            }
            // verifica senha
            if (professor.senha.Length <= 20)
            {
                if (professor.senha.Length < 8)
                {
                    Erro.setMsg("A senha deve ter entre 8 e 20 caracteres.");
                    return;
                }
                else if (!System.Text.RegularExpressions.Regex.IsMatch(professor.senha, @"[A-Z]"))
                {
                    Erro.setMsg("A senha deve ter pelo menos uma letra maiúscula.");
                    return;
                }
                else if (!System.Text.RegularExpressions.Regex.IsMatch(professor.senha, @"[a-z]"))
                {
                    Erro.setMsg("A senha deve ter pelo menos uma letra minúscula.");
                    return;
                }
                else if (!System.Text.RegularExpressions.Regex.IsMatch(professor.senha, @"[0-9]"))
                {
                    Erro.setMsg("A senha deve ter pelo menos um número.");
                    return;
                }
                else if (!System.Text.RegularExpressions.Regex.IsMatch(professor.senha, @"[_\-@#!$%&]"))
                {
                    Erro.setMsg("A senha deve ter pelo menos um caractere especial (_-@#!$%&).");
                    return;
                }
                else if (professor.senha.Length <= 20)
                {
                    professor.senha = HashSenha(professor.senha);
                }
            }

            if (op == 'I')
            {
                DAL.insereProfessor(professor);
            }
            else
            {
                DAL.atualizaProfessor(professor);
            }
        }

        // aluno
        public static void validaEntradaAluno(Aluno aluno)
        {

            // verifica email
            if (aluno.email.Length == 0)
            {
                Erro.setMsg("O campo email é obrigatório.");
                return;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(aluno.email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                Erro.setMsg("Email inválido.");
                return;
            }
            // verifica senha
            if (aluno.senha.Length < 8)
            {
                Erro.setMsg("A senha deve ter entre 8 e 20 caracteres.");
                return;
            }
            else
            {
                aluno.senha = HashSenha(aluno.senha);
            }

            DAL.LoginAluno(aluno);
        }
        public static void validaRA(Aluno aluno, char op)
        {
            Erro.setErro(false);
            if (aluno.ra == null)
            {
                Erro.setMsg("O RA é de preenchimento obrigatório.");
                return;
            }
            if (op == 'c')
                DAL.consultaAluno(aluno);
            else
            { 
            //DAL.deletaAluno(aluno);
            }   
        }
        public static void validaDadosAluno(Aluno aluno, char op)
        {
            Erro.setErro(false);
            // verifica nome
            if (aluno.nome.Length == 0)
            {
                Erro.setMsg("O campo nome é obrigatório.");
                return;
            }
            // verifica CPF
            if (aluno.cpf.Length == 0)
            {
                Erro.setMsg("O campo CPF é obrigatório.");
                return;
            }
            else if (!long.TryParse(aluno.cpf, out _))
            {
                Erro.setMsg("O CPF deve conter apenas números.");
                return;
            }
            // verifica telefone
            if (aluno.telefone.Length == 0)
            {
                Erro.setMsg("O campo telefone é obrigatório.");
                return;
            }
            else if (!long.TryParse(aluno.telefone, out _))
            {
                Erro.setMsg("O telefone deve conter apenas números.");
                return;
            }
            // verifica email
            if (aluno.email.Length == 0)
            {
                Erro.setMsg("O campo email é obrigatório.");
                return;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(aluno.email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                Erro.setMsg("Email inválido.");
                return;
            }
            // verifica senha
            if (aluno.senha.Length <= 20)
            {
                if (aluno.senha.Length < 8)
                {
                    Erro.setMsg("A senha deve ter entre 8 e 20 caracteres.");
                    return;
                }
                else if (!System.Text.RegularExpressions.Regex.IsMatch(aluno.senha, @"[A-Z]"))
                {
                    Erro.setMsg("A senha deve ter pelo menos uma letra maiúscula.");
                    return;
                }
                else if (!System.Text.RegularExpressions.Regex.IsMatch(aluno.senha, @"[a-z]"))
                {
                    Erro.setMsg("A senha deve ter pelo menos uma letra minúscula.");
                    return;
                }
                else if (!System.Text.RegularExpressions.Regex.IsMatch(aluno.senha, @"[0-9]"))
                {
                    Erro.setMsg("A senha deve ter pelo menos um número.");
                    return;
                }
                else if (!System.Text.RegularExpressions.Regex.IsMatch(aluno.senha, @"[_\-@#!$%&]"))
                {
                    Erro.setMsg("A senha deve ter pelo menos um caractere especial (_-@#!$%&).");
                    return;
                }
                else
                {
                    aluno.senha = HashSenha(aluno.senha);
                }
            }

            if (op == 'I') { DAL.insereAluno(aluno); }
            if (op == 'A') { DAL.alteraAluno(aluno); }
        }

        // endereco
        public static void validaEndereco(Endereco endereco, char op)
        {
            Erro.setErro(false);
            if (endereco.id == null)
            {
                Erro.setMsg("Endereço id: " + endereco.id);
                return;
            }
            if (op == 'c')
                DAL.consultaEndereco(endereco);
            //else
                //DAL.deletaAluno(endereco);
        }
        public static int validaDadosEndereco(Endereco endereco, char op)
        {
            Erro.setErro(false);
            if (endereco.cep.Length == 0) { Erro.setMsg("O campo CEP é obrigatório."); return 0; }
            if (endereco.rua.Length == 0) { Erro.setMsg("O campo rua é obrigatório."); return 0; }
            if (endereco.bairro.Length == 0) { Erro.setMsg("O campo bairro é obrigatório."); return 0; }
            if (endereco.cidade.Length == 0) { Erro.setMsg("O campo cidade é obrigatório."); return 0; }
            if (endereco.estado.Length == 0) { Erro.setMsg("O campo estado é obrigatório."); return 0; }

            if (op == 'I')
            {
                return DAL.insereEndereco(endereco);
            }

            if (op == 'A')
            {
                return DAL.alteraEndereco(endereco);
            }

            return 0;
        }



        public static async Task<Endereco> viaCEP(string cep)
        {
            return await DAL.buscaCEP(cep);
        }

        // curso

        public static void validaIDCurso(Curso curso, char op)
        {
            Erro.setMsg("");
            Erro.setErro(false);
            if (curso.id == null)
            {
                Erro.setMsg("O ID é de preenchimento obrigatório.");
                return;
            }
            if (op == 'c')
                DAL.consultaCurso(curso);
            else
            {
                //DAL.deletaAluno(aluno);
            }
        }

        public static void validaDadosCurso(Curso curso, char op)
        {
            Erro.setMsg("");
            Erro.setErro(false);
            // verifica nome
            if (curso.nome.Length == 0)
            {
                Erro.setMsg("O campo nome é obrigatório.");
                return;
            }
            // verifica duracao
            if (curso.duracao.ToString().Length == 0)
            {
                Erro.setMsg("O campo horas é obrigatório.");
                return;
            }
            if (op == 'I')
            {
                DAL.insereCurso(curso);
            }
            else
            {
                DAL.atualizaCurso(curso);
            }
        }

        // admin
        public static void validaEntradaAdmin(Admin admin)
        {

            // verifica email
            if (admin.email.Length == 0)
            {
                Erro.setMsg("O campo email é obrigatório.");
                return;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(admin.email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                Erro.setMsg("Email inválido.");
                return;
            }
            // verifica senha
            if (admin.senha.Length <= 0)
            {
                Erro.setMsg("A senha é de preenchimento obrigatório.");
                return;
            }
            else
            {
                admin.senha = HashSenha(admin.senha);
            }

            Erro.setMsg("");
            Erro.setErro(false);
            DAL.LoginAdmin(admin);
        }
        public static void validaIDAdmin(Admin admin, char op)
        {
            Erro.setMsg("");
            Erro.setErro(false);
            if (admin.id == null)
            {
                Erro.setMsg("O ID é de preenchimento obrigatório.");
                return;
            }
            if (op == 'c')
                DAL.consultaAdmin(admin);
            else
            {
                DAL.deletaAdmin(admin);
            }
        }

        public static void validaDadosAdmin(Admin admin, char op)
        {
            Erro.setMsg("");
            Erro.setErro(false);
            if (admin.nome.Length == 0)
            {
                Erro.setMsg("O campo nome é obrigatório.");
                return;
            }
            if (admin.email.ToString().Length == 0)
            {
                Erro.setMsg("O campo email é obrigatório.");
                return;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(admin.email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                Erro.setMsg("Email inválido.");
                return;
            }
            if (admin.senha.Length < 8 && admin.senha.Length > 20)
            {
                Erro.setMsg("A senha deve ter entre 8 e 20 caracteres.");
                return;
            }
            else if (admin.senha.Length <= 20)
            {
                admin.senha = HashSenha(admin.senha);
            }
            if (op == 'I')
            {
                DAL.insereAdmin(admin);
            }
            else
            {
                DAL.atualizaAdmin(admin);
            }
        }
    }
}