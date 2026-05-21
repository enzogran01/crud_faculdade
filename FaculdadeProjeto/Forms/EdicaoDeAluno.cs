using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaculdadeProjeto.Forms
{
    public partial class EdicaoDeAluno : Form
    {
        Aluno aluno = new Aluno();
        Endereco endereco = new Endereco();
        public EdicaoDeAluno(string ra)
        {
            InitializeComponent();
            aluno.ra = ra;
            EdicaoDeAluno_Load();
        }

        private void EdicaoDeAluno_Load()
        {
            BLL.validaRA(aluno, 'c');
            endereco.id = aluno.cd_endereco;
            BLL.validaEndereco(endereco, 'c');

            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsg());
            }
            else
            {
                CEPTextBox.Text = endereco.cep;
                cidadeTextBox.Text = endereco.cidade;
                estadoTextBox.Text = endereco.estado;
                ruaTextBox.Text = endereco.rua;
                bairroTextBox.Text = endereco.bairro;
                numeroTextBox.Text = endereco.numero;
                complementoTextBox.Text = endereco.complemento;

                raTextBox.Text = aluno.ra;
                ativoCheckBox.Checked = aluno.ativo;
                nomeTextBox.Text = aluno.nome;
                CPFTextBox.Text = aluno.cpf;
                emailTextBox.Text = aluno.email;
                telefoneTextBox.Text = aluno.telefone;
                datanascDateTime.Text = aluno.dataNascimento.ToString();
            }

        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Endereco endereco = new Endereco();
            endereco.id = aluno.cd_endereco;
            endereco.cep = CEPTextBox.Text.Replace("-", "").Replace("_", ""); ;
            endereco.rua = ruaTextBox.Text;
            endereco.bairro = bairroTextBox.Text;
            endereco.cidade = cidadeTextBox.Text;
            endereco.estado = estadoTextBox.Text;
            endereco.numero = numeroTextBox.Text;
            endereco.complemento = complementoTextBox.Text;

            BLL.validaDadosEndereco(endereco, 'A');
            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsg());
                return;
            }

            Aluno _aluno = new Aluno();
            _aluno.ra = raTextBox.Text;
            _aluno.nome = nomeTextBox.Text;
            _aluno.cpf = CPFTextBox.Text.Replace(",", "").Replace("-", "").Replace("_", "");
            _aluno.telefone = telefoneTextBox.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Replace("_", "");
            _aluno.email = emailTextBox.Text;
            _aluno.ativo = ativoCheckBox.Checked;

            if (senhaTextBox.Text == confirmSenhaTextBox.Text)
                _aluno.senha = senhaTextBox.Text;
            else
                Erro.setMsg("As senhas precisam ser iguais!");

            _aluno.dataNascimento = datanascDateTime.Value;

            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsg());
                return;
            }
            BLL.validaDadosAluno(_aluno, 'A');
            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsg());
                return;
            }
            MessageBox.Show("Aluno alterado com sucesso.");
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

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            new ConsultaAluno().Show();
            this.Close();
        }

        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void datanascDateTime_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void telefoneTextBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void confirmSenhaTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void senhaTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CPFTextBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void nomeTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ativoCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CEPTextBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void EdicaoDeAluno_Load(object sender, EventArgs e)
        {

        }
    }
}
