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
        public EdicaoDeAluno(string ra)
        {
            InitializeComponent();
            aluno.ra = ra;
            EdicaoDeAluno_Load();
        }

        private void EdicaoDeAluno_Load()
        {
            BLL.validaRA(aluno, 'c');

            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsg());
            }
            else
            {
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
            Aluno aluno = new Aluno();
            aluno.ra = raTextBox.Text;
            aluno.nome = nomeTextBox.Text;
            aluno.cpf = CPFTextBox.Text.Replace(",", "").Replace("-", "").Replace("_", "");
            aluno.telefone = telefoneTextBox.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Replace("_", "");
            aluno.email = emailTextBox.Text;
            aluno.ativo = ativoCheckBox.Checked;

            if (senhaTextBox.Text == confirmSenhaTextBox.Text)
                aluno.senha = senhaTextBox.Text;
            else
                Erro.setMsg("As senhas precisam ser iguais!" + senhaTextBox.Text + " " + confirmSenhaTextBox.Text);

            aluno.dataNascimento = datanascDateTime.Value;
            //aluno.cd_endereco = cdEndereco.ToString();

            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsg());
                return;
            }
            BLL.validaDadosAluno(aluno, 'A');
            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsg());
                return;
            }
            MessageBox.Show("Aluno alterado com sucesso.");
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
    }
}
