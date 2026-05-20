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
        public static void insereProfessor(Professor professor)
        {
            conecta();
            String aux = "INSERT INTO Professor " +
                "(nm_professor, cd_cpf, cd_telefone_professor, nm_email, cd_senha_professor) VALUES" +
                "(@nm_professor, @cd_cpf, @cd_telefone_professor, @nm_email, @cd_senha_professor)";
            strSQL = new SqlCommand(aux, conn);
            strSQL.Parameters.AddWithValue("@cd_professor", professor.id);
            strSQL.Parameters.AddWithValue("@nm_professor", professor.nome);
            strSQL.Parameters.AddWithValue("@cd_cpf", professor.cpf);
            strSQL.Parameters.AddWithValue("@cd_telefone_professor", professor.telefone);
            strSQL.Parameters.AddWithValue("@nm_email", professor.email);
            strSQL.Parameters.AddWithValue("@cd_senha_professor", professor.senha);
            try
            {
                strSQL.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Erro.setMsg("Chave Duplicada!");
            }
            desconecta();
        }

        public static void atualizaProfessor(Professor professor)
        {
            conecta();
            String aux = "UPDATE Professor " +
                "SET nm_professor = @nm_professor, cd_cpf = @cd_cpf, cd_telefone_professor = @cd_telefone_professor, nm_email = @nm_email, cd_senha_professor = @cd_senha_professor" +
                "WHERE cd_professor = @cd_professor";
            strSQL = new SqlCommand(aux, conn);
            strSQL.Parameters.AddWithValue("@cd_professor", professor.id);
            strSQL.Parameters.AddWithValue("@nm_professor", professor.nome);
            strSQL.Parameters.AddWithValue("@cd_cpf", professor.cpf);
            strSQL.Parameters.AddWithValue("@cd_telefone_professor", professor.telefone);
            strSQL.Parameters.AddWithValue("@nm_email", professor.email);
            strSQL.Parameters.AddWithValue("@cd_senha_professor", professor.senha);
            try
            {
                strSQL.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Erro.setMsg("Chave Duplicada!");
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
            catch (Exception)
            {
                Erro.setMsg("Chave Duplicada!");
            }
            desconecta();
        }

        public static void consultaProfessor(Professor professor)
        {
            conecta();
            String aux = "SELECT * FROM Professor WHERE cd_professor = @cd_professor";
            strSQL = new SqlCommand(aux, conn);
            strSQL.Parameters.AddWithValue("@cd_professor", professor.id);
            adaptador = new SqlDataAdapter(strSQL);
            dt.Clear();
            adaptador.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                professor.nome = dt.Rows[0]["nm_professor"].ToString();
                professor.cpf = dt.Rows[0]["cd_cpf"].ToString();
                professor.telefone = dt.Rows[0]["cd_telefone_professor"].ToString();
                professor.email = dt.Rows[0]["nm_email"].ToString();
                professor.senha = dt.Rows[0]["cd_senha_professor"].ToString();
                professor.ativo = Convert.ToBoolean(dt.Rows[0]["ativo"]);
            }
            else
            {
                Erro.setMsg("Professor não encontrado!");
            }
            desconecta();
        }

        // aluno

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
                "cd_ra=@cd_ra, nm_aluno=@nm_aluno, cd_cpf=@cd_cpf, cd_telefone_aluno=@cd_telefone_aluno, nm_email_aluno=@nm_email_aluno, cd_senha_aluno=@cd_senha_aluno, dt_nascimento_aluno=@dt_nascimento_aluno, cd_endereco=@cd_endereco";
            strSQL = new SqlCommand(aux, conn);
            strSQL.Parameters.AddWithValue("@cd_ra", aluno.ra);
            strSQL.Parameters.AddWithValue("@nm_aluno", aluno.nome);
            strSQL.Parameters.AddWithValue("@cd_cpf", aluno.cpf);
            strSQL.Parameters.AddWithValue("@cd_telefone_aluno", aluno.telefone);
            strSQL.Parameters.AddWithValue("@nm_email_aluno", aluno.email);
            strSQL.Parameters.AddWithValue("@cd_senha_aluno", aluno.senha);
            strSQL.Parameters.AddWithValue("@dt_nascimento_aluno", aluno.dataNascimento);
            strSQL.Parameters.AddWithValue("@cd_endereco", Convert.ToInt32(aluno.cd_endereco));
            strSQL.ExecuteNonQuery();

            desconecta();
        }
        public static void deletaAluno(Aluno aluno)
        {
            conecta();

            String aux = "DELETE FROM Aluno WHERE cd_ra = @cd_ra";

            strSQL = new SqlCommand(aux, conn);
            strSQL.Parameters.Add("@cd_ra", aluno.ra);
            strSQL.ExecuteNonQuery();

            desconecta();
        }
        public static void consultaAluno(Aluno aluno)
        {
            conecta();

            String aux = "SELECT * FROM Aluno WHERE cd_ra = @cd_ra";

            strSQL = new SqlCommand(aux, conn);
            strSQL.Parameters.Add("@cd_ra", aluno.ra);
            result = strSQL.ExecuteReader();
            Erro.setErro(false);
            if (result.Read())
            {
                aluno.ra = result.GetString(0);
                aluno.cpf = result.GetString(1);
                aluno.nome = result.GetString(2);
                aluno.email = result.GetString(3);
                aluno.senha = result.GetString(4);
                aluno.telefone = result.GetString(5);
                aluno.dataNascimento = result.GetDateTime(6);
                aluno.ativo = result.GetBoolean(7);
                aluno.cd_endereco = result.GetString(8);
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
    }
}
