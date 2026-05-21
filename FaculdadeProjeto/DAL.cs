using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaculdadeProjeto
{
    internal class DAL
    {
        private static String strConexao = "Server=MatheuxPC\\SQLEXPRESS;Database=Faculdade;Trusted_Connection=True;TrustServerCertificate=True;";
        private static SqlConnection conn = new SqlConnection(strConexao);
        private static SqlCommand strSQL;
        private static SqlDataAdapter adaptador;
        private static DataTable dt = new DataTable();
        private static SqlDataReader result;

        public static void conecta()
        {
            try
            {
                conn.Open();
            } catch (Exception)
            {
                Erro.setMsg("Problemas ao se conectar ao Banco de Dados");
            }
        }
        public static void desconecta()
        {
            conn.Close();
        }
        // professor

        public static int ObterMaiorIDProfessor()
        {
            conecta();

            // MAX(cd_ra) busca o maior número da coluna. 
            // ISNULL(..., 0) garante que se a tabela estiver totalmente vazia, ele retorne 0 em vez de NULL.
            string sql = "SELECT ISNULL(MAX(cd_professor), 0) FROM Professor";

            strSQL = new SqlCommand(sql, conn);

            try
            {
                // ExecuteScalar é perfeito aqui porque a query só devolve 1 linha e 1 coluna (um único número)
                int maiorID = Convert.ToInt32(strSQL.ExecuteScalar());
                return maiorID;
            }
            catch (SqlException sqlErro)
            {
                throw new Exception("Erro ao buscar o maior ID: " + sqlErro.Message);
            }
            finally
            {
                desconecta();
            }
        }
        public static void insereProfessor(Professor professor)
        {
            conecta();
            String aux = "INSERT INTO Professor " +
                "(nm_professor, cd_cpf, cd_telefone_professor, nm_email_professor, cd_senha_professor) VALUES" +
                "(@nm_professor, @cd_cpf, @cd_telefone_professor, @nm_email_professor, @cd_senha_professor)";
            strSQL = new SqlCommand(aux, conn);
            strSQL.Parameters.AddWithValue("@nm_professor", professor.nome);
            strSQL.Parameters.AddWithValue("@cd_cpf", professor.cpf);
            strSQL.Parameters.AddWithValue("@cd_telefone_professor", professor.telefone);
            strSQL.Parameters.AddWithValue("@nm_email_professor", professor.email);
            strSQL.Parameters.AddWithValue("@cd_senha_professor", professor.senha);
            try
            {
                strSQL.ExecuteNonQuery();
            }
            catch (SqlException sqlErro)
            {
                Erro.setMsg(sqlErro.Message);
            }
            desconecta();
        }

        public static void atualizaProfessor(Professor professor)
        {
            conecta();
            String aux = "UPDATE Professor " +
                "SET nm_professor = @nm_professor, cd_cpf = @cd_cpf, cd_telefone_professor = @cd_telefone_professor, nm_email_professor = @nm_email_professor, cd_senha_professor = @cd_senha_professor, ic_ativado = @ic_ativado " +
                "WHERE cd_professor = @cd_professor";
            strSQL = new SqlCommand(aux, conn);
            strSQL.Parameters.AddWithValue("@cd_professor", professor.id);
            strSQL.Parameters.AddWithValue("@nm_professor", professor.nome);
            strSQL.Parameters.AddWithValue("@cd_cpf", professor.cpf);
            strSQL.Parameters.AddWithValue("@cd_telefone_professor", professor.telefone);
            strSQL.Parameters.AddWithValue("@nm_email_professor", professor.email);
            strSQL.Parameters.AddWithValue("@cd_senha_professor", professor.senha);
            strSQL.Parameters.AddWithValue("@ic_ativado", professor.ativo);

            try
            {
                strSQL.ExecuteNonQuery();
            }
            catch (SqlException sqlErro)
            {
                Erro.setMsg(sqlErro.Message);
            }
            desconecta();
        }

        public static void desativaProfessor(Professor professor)
        {
            conecta();
            String aux = "UPDATE Professor " +
                "SET ativo = 0 " +
                "WHERE cd_professor = @cd_professor";
            strSQL = new SqlCommand(aux, conn);
            strSQL.Parameters.AddWithValue("@cd_professor", professor.id);
            try
            {
                strSQL.ExecuteNonQuery();
            }
            catch (SqlException sqlErro)
            {
                Erro.setMsg(sqlErro.Message);
            }
            desconecta();
        }

        public static void consultaProfessor(Professor professor)
        {
            conecta();

            String aux = "SELECT * FROM Professor WHERE cd_professor = @cd_professor";

            strSQL = new SqlCommand(aux, conn);
            strSQL.Parameters.AddWithValue("@cd_professor", professor.id);
            result = strSQL.ExecuteReader();
            Erro.setErro(false);
            if (result.Read())
            {
                professor.id = result["cd_professor"].ToString();
                professor.nome = result.GetString(1);
                professor.cpf = result.GetString(2);
                professor.telefone = result.GetString(3);
                professor.email = result.GetString(4);
                professor.senha = result.GetString(5);
                professor.ativo = result.GetBoolean(6);
            }
            else
                Erro.setMsg("Professor não cadastrado.");

            desconecta();
        }

        // aluno

        public static int ObterMaiorRA()
        {
            conecta();

            // MAX(cd_ra) busca o maior número da coluna. 
            // ISNULL(..., 0) garante que se a tabela estiver totalmente vazia, ele retorne 0 em vez de NULL.
            string sql = "SELECT ISNULL(MAX(cd_ra), 0) FROM Aluno";

            strSQL = new SqlCommand(sql, conn);

            try
            {
                // ExecuteScalar é perfeito aqui porque a query só devolve 1 linha e 1 coluna (um único número)
                int maiorRA = Convert.ToInt32(strSQL.ExecuteScalar());
                return maiorRA;
            }
            catch (SqlException sqlErro)
            {
                throw new Exception("Erro ao buscar o maior RA: " + sqlErro.Message);
            }
            finally
            {
                desconecta();
            }
        }

        public static void insereAluno(Aluno aluno)
        {
            conecta();
            String aux = "INSERT INTO Aluno " +
                "(nm_aluno, cd_cpf, cd_telefone_aluno, nm_email_aluno, cd_senha_aluno, dt_nascimento_aluno, cd_endereco) VALUES" +
                "(@nm_aluno, @cd_cpf, @cd_telefone_aluno, @nm_email_aluno, @cd_senha_aluno, @dt_nascimento_aluno, @cd_endereco)";
            strSQL = new SqlCommand(aux, conn);
            strSQL.Parameters.AddWithValue("@nm_aluno", aluno.nome);
            strSQL.Parameters.AddWithValue("@cd_cpf", aluno.cpf);
            strSQL.Parameters.AddWithValue("@cd_telefone_aluno", aluno.telefone);
            strSQL.Parameters.AddWithValue("@nm_email_aluno", aluno.email);
            strSQL.Parameters.AddWithValue("@cd_senha_aluno", aluno.senha);
            strSQL.Parameters.AddWithValue("@dt_nascimento_aluno", aluno.dataNascimento);
            strSQL.Parameters.AddWithValue("@cd_endereco", Convert.ToInt32(aluno.cd_endereco));
            try
            {
                strSQL.ExecuteNonQuery();
            }
            catch (SqlException sqlErro)
            {
                Erro.setMsg(sqlErro.Message);
            }
            desconecta();
        }
        public static void alteraAluno(Aluno aluno)
        {
            conecta();

            String aux = "UPDATE Aluno SET " +
                "nm_aluno=@nm_aluno, cd_cpf=@cd_cpf, cd_telefone_aluno=@cd_telefone_aluno, nm_email_aluno=@nm_email_aluno, " +
                "cd_senha_aluno=@cd_senha_aluno, " +
                "dt_nascimento_aluno=@dt_nascimento_aluno, ic_ativado=@ic_ativado WHERE cd_ra=@cd_ra";
            strSQL = new SqlCommand(aux, conn);
            strSQL.Parameters.AddWithValue("@cd_ra", aluno.ra);
            strSQL.Parameters.AddWithValue("@nm_aluno", aluno.nome);
            strSQL.Parameters.AddWithValue("@cd_cpf", aluno.cpf);
            strSQL.Parameters.AddWithValue("@cd_telefone_aluno", aluno.telefone);
            strSQL.Parameters.AddWithValue("@nm_email_aluno", aluno.email);
            strSQL.Parameters.AddWithValue("@cd_senha_aluno", aluno.senha);
            strSQL.Parameters.AddWithValue("@dt_nascimento_aluno", aluno.dataNascimento);
            strSQL.Parameters.AddWithValue("@ic_ativado", aluno.ativo);
            //strSQL.Parameters.AddWithValue("@cd_endereco", Convert.ToInt32(aluno.cd_endereco));
            strSQL.ExecuteNonQuery();

            desconecta();
        }
        //public static void deletaAluno(Aluno aluno)
        //{
        //    conecta();

        //    String aux = "DELETE FROM Aluno WHERE cd_ra = @cd_ra";

        //    strSQL = new SqlCommand(aux, conn);
        //    strSQL.Parameters.AddWithValue("@cd_ra", aluno.ra);
        //    strSQL.ExecuteNonQuery();

        //    desconecta();
        //}
        public static void consultaAluno(Aluno aluno)
        {
            conecta();

            String aux = "SELECT * FROM Aluno WHERE cd_ra = @cd_ra";

            strSQL = new SqlCommand(aux, conn);
            strSQL.Parameters.AddWithValue("@cd_ra", aluno.ra);
            result = strSQL.ExecuteReader();
            Erro.setErro(false);
            if (result.Read())
            {
                aluno.ra = result["cd_ra"].ToString();
                aluno.cpf = result.GetString(1);
                aluno.nome = result.GetString(2);
                aluno.email = result.GetString(3);
                aluno.senha = result.GetString(4);
                aluno.telefone = result.GetString(5);
                aluno.dataNascimento = result.GetDateTime(6);
                aluno.ativo = result.GetBoolean(7);
                aluno.cd_endereco = result.GetInt32(8).ToString();
            }
            else
                Erro.setMsg("Aluno não cadastrado.");

            desconecta();
        }

        // endereco
        public static int insereEndereco(Endereco endereco)
        {
            conecta();
            String aux = "INSERT INTO Endereco " +
                "(cd_cep, nm_cidade, sg_estado, nm_rua, nm_bairro, nr_logradouro, ds_complemento) " +
                "OUTPUT INSERTED.cd_endereco " +
                "VALUES (@cep, @cidade, @estado, @rua, @bairro, @numero, @complemento)";
            strSQL = new SqlCommand(aux, conn);
            strSQL.Parameters.AddWithValue("@cep", endereco.cep);
            strSQL.Parameters.AddWithValue("@cidade", endereco.cidade);
            strSQL.Parameters.AddWithValue("@estado", endereco.estado);
            strSQL.Parameters.AddWithValue("@rua", endereco.rua);
            strSQL.Parameters.AddWithValue("@bairro", endereco.bairro);
            strSQL.Parameters.AddWithValue("@numero", endereco.numero ?? "");
            strSQL.Parameters.AddWithValue("@complemento", endereco.complemento ?? "");
            int idGerado = 0;
            try
            {
                idGerado = (int)strSQL.ExecuteScalar();
            }
            catch (SqlException sqlErro)
            {
                Erro.setMsg(sqlErro.Message);
            }
            desconecta();
            return idGerado;
        }
        public static int alteraEndereco(Endereco endereco)
        {
            conecta();

            String aux = "UPDATE Endereco SET " +
                "cd_cep=@cd_cep, nm_cidade=@nm_cidade, sg_estado=@sg_estado, nm_rua=@nm_rua, " +
                "nm_bairro=@nm_bairro, " +
                "nr_logradouro=@nr_logradouro, ds_complemento=@ds_complemento WHERE cd_endereco=@cd_endereco";
            strSQL = new SqlCommand(aux, conn);
            strSQL.Parameters.AddWithValue("@cd_cep", endereco.cep);
            strSQL.Parameters.AddWithValue("@nm_cidade", endereco.cidade);
            strSQL.Parameters.AddWithValue("@sg_estado", endereco.estado);
            strSQL.Parameters.AddWithValue("@nm_rua", endereco.rua);
            strSQL.Parameters.AddWithValue("@nm_bairro", endereco.bairro);
            strSQL.Parameters.AddWithValue("@nr_logradouro", endereco.numero);
            strSQL.Parameters.AddWithValue("@ds_complemento", endereco.complemento);
            strSQL.Parameters.AddWithValue("@cd_endereco", endereco.id);
            strSQL.ExecuteNonQuery();

            desconecta();

            return 0;
        }
        public static void consultaEndereco(Endereco endereco)
        {
            conecta();

            String aux = "SELECT * FROM Endereco WHERE cd_endereco = @cd_endereco";

            strSQL = new SqlCommand(aux, conn);
            strSQL.Parameters.AddWithValue("@cd_endereco", endereco.id);
            result = strSQL.ExecuteReader();
            Erro.setErro(false);
            if (result.Read())
            {
                endereco.id = result["cd_endereco"].ToString();
                endereco.cep = result.GetString(1);
                endereco.cidade = result.GetString(2);
                endereco.estado = result.GetString(3);
                endereco.rua = result.GetString(4);
                endereco.bairro = result.GetString(5);
                endereco.numero = result.GetString(6);
                endereco.complemento = result.GetString(7);
            }
            else
                Erro.setMsg("Endereço não cadastrado.");

            desconecta();
        }
        public static async Task<Endereco> buscaCEP(string cep)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"https://viacep.com.br/ws/{cep}/json/";
                HttpResponseMessage response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    Erro.setMsg("Erro ao buscar CEP.");
                    return null;
                }

                string json = await response.Content.ReadAsStringAsync();
                var doc = System.Text.Json.JsonDocument.Parse(json);
                var root = doc.RootElement;
                Endereco endereco = new Endereco();

                if (root.TryGetProperty("erro", out _))
                {
                    Erro.setMsg("CEP não encontrado.");
                    return null;
                }

                endereco.cep = cep;
                endereco.rua = root.GetProperty("logradouro").GetString();
                endereco.bairro = root.GetProperty("bairro").GetString();
                endereco.cidade = root.GetProperty("localidade").GetString();
                endereco.estado = root.GetProperty("uf").GetString();

                return endereco;
            }
        }
        // curso
        public static int ObterMaiorIDCurso()
        {
            conecta();

            // MAX(cd_ra) busca o maior número da coluna. 
            // ISNULL(..., 0) garante que se a tabela estiver totalmente vazia, ele retorne 0 em vez de NULL.
            string sql = "SELECT ISNULL(MAX(cd_curso), 0) FROM Curso";

            strSQL = new SqlCommand(sql, conn);

            try
            {
                // ExecuteScalar é perfeito aqui porque a query só devolve 1 linha e 1 coluna (um único número)
                int maiorID = Convert.ToInt32(strSQL.ExecuteScalar());
                return maiorID;
            }
            catch (SqlException sqlErro)
            {
                throw new Exception("Erro ao buscar o maior ID: " + sqlErro.Message);
            }
            finally
            {
                desconecta();
            }
        }
        public static void insereCurso(Curso curso)
        {
            conecta();
            String aux = "INSERT INTO Curso " +
                "(nm_curso, vl_curso) VALUES" +
                "(@nm_curso, vl_duracao_curso)";
            strSQL = new SqlCommand(aux, conn);
            strSQL.Parameters.AddWithValue("@nm_curso", curso.nome);
            strSQL.Parameters.AddWithValue("@vl_duracao_curso", curso.duracao);
            try
            {
                strSQL.ExecuteNonQuery();
            }
            catch (SqlException sqlErro)
            {
                Erro.setMsg(sqlErro.Message);
            }
            desconecta();
        }
        public static void atualizaCurso(Curso curso)
        {
            conecta();
            String aux = "UPDATE Curso " +
                "SET nm_curso = @nm_curso, vl_duracao_curso = @vl_duracao_curso " +
                "WHERE cd_curso = @cd_curso";
            strSQL = new SqlCommand(aux, conn);
            strSQL.Parameters.AddWithValue("@cd_curso", curso.id);
            strSQL.Parameters.AddWithValue("@nm_curso", curso.nome);
            strSQL.Parameters.AddWithValue("@vl_duracao_curso", curso.duracao);

            try
            {
                strSQL.ExecuteNonQuery();
            }
            catch (SqlException sqlErro)
            {
                Erro.setMsg(sqlErro.Message);
            }
            desconecta();
        }

        public static void consultaCurso(Curso curso)
        {
            conecta();

            String aux = "SELECT * FROM Curso WHERE cd_curso = @cd_curso";

            strSQL = new SqlCommand(aux, conn);
            strSQL.Parameters.AddWithValue("@cd_curso", curso.id);
            result = strSQL.ExecuteReader();
            Erro.setErro(false);
            if (result.Read())
            {
                curso.id = result["cd_curso"].ToString();
                curso.nome = result.GetString(1);
                curso.duracao = result.GetInt32(2);
            }
            else
                Erro.setMsg("Curso não cadastrado.");

            desconecta();
        }

        // matricula
        public static List<Matricula> BuscarMatriculasPorAluno(string raAluno)
        {
            // 1. Cria a lista vazia que vai guardar as matrículas encontradas
            List<Matricula> listaMatriculas = new List<Matricula>();

            try
            {
                conecta();

                // 2. Query filtrando pelo cd_aluno (que é o RA dele na tabela Matricula)
                string aux = "SELECT M.cd_matricula, M.dt_matricula, M.ds_status, M.ds_turno, M.cd_aluno, M.cd_curso, " +
                     "A.nm_aluno, " +
                     "C.nm_curso " +
                     "FROM Matricula M " +
                     "INNER JOIN Aluno A ON M.cd_aluno = A.cd_ra " +
                     "INNER JOIN Curso C ON M.cd_curso = C.cd_curso " +
                     "WHERE A.cd_ra = @cd_ra";

                strSQL = new SqlCommand(aux, conn);
                strSQL.Parameters.AddWithValue("@cd_ra", raAluno);

                result = strSQL.ExecuteReader();
                Erro.setErro(false);

                while (result.Read())
                {
                    Matricula mat = new Matricula();

                    mat.id = result.GetInt32(0).ToString();
                    mat.data = result.GetDateTime(1);
                    mat.ativo = result.GetString(2);
                    mat.turno = result.GetString(3);
                    mat.ra_aluno = result.GetInt32(4).ToString();
                    mat.nm_aluno = result["nm_aluno"].ToString();
                    mat.id_curso = result.GetInt32(5).ToString();
                    mat.nm_curso = result["nm_curso"].ToString();

                    listaMatriculas.Add(mat);
                }

                if (listaMatriculas.Count == 0)
                {
                    Erro.setErro(true);
                    Erro.setMsg("Nenhuma matrícula encontrada para este aluno.");
                }

                result.Close();
            }
            catch (Exception ex)
            {
                Erro.setErro(true);
                Erro.setMsg("Erro ao buscar matrículas: " + ex.Message);
            }
            finally
            {
                desconecta();
            }
            // Retorna a lista (cheia ou vazia) para quem chamou o método
            return listaMatriculas;
        }
    }
}
