using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaculdadeProjeto
{
    public partial class regAluno : Form
    {
        public regAluno()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            new TelaInicial().Show();
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new loginAluno().Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Endereco endereco = new Endereco();
            endereco.cep = CEPTextBox.Text.Replace("-", "").Replace("_", ""); ;
            endereco.rua = ruaTextBox.Text;
            endereco.bairro = bairroTextBox.Text;
            endereco.cidade = cidadeTextBox.Text;
            endereco.estado = estadoTextBox.Text;
            endereco.numero = numeroTextBox.Text;
            endereco.complemento = complementoTextBox.Text;

            int cdEndereco = BLL.validaDadosEndereco(endereco, 'I');
            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsg());
                return;
            }

            Aluno aluno = new Aluno();
            aluno.nome = nomeTextBox.Text;
            aluno.cpf = CPFTextBox.Text.Replace(",", "").Replace("-", "").Replace("_", "");
            aluno.telefone = telefoneTextBox.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Replace("_", "");
            aluno.email = emailTextBox.Text;

            if (senhaTextBox.Text == confirmSenhaTextBox.Text)
                aluno.senha = senhaTextBox.Text;
            else
                Erro.setMsg("As senhas precisam ser iguais!");

            aluno.dataNascimento = datanascDateTime.Value;
            aluno.cd_endereco = cdEndereco.ToString();


            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsg());
                return;
            }
            BLL.validaDadosAluno(aluno, 'I');
            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsg());
                return;
            }

            MessageBox.Show("Aluno cadastrado com sucesso.");
        }

        private async void CEPTextBox_Leave(object sender, EventArgs e)
        {
            string cep = CEPTextBox.Text.Replace("-", "").Replace("_", "");
            if (cep.Length == 8)
            {
                Endereco endereco = await BLL.viaCEP(cep);
                if (endereco == null)
                {
                    MessageBox.Show("Endereço não encontrado");
                    return;
                }
                ruaTextBox.Text = endereco.rua;
                bairroTextBox.Text = endereco.bairro;
                cidadeTextBox.Text = endereco.cidade;
                estadoTextBox.Text = endereco.estado;
            }
        }

        private void CEPTextBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
