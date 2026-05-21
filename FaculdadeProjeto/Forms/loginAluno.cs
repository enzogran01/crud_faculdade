using FaculdadeProjeto.Models;
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
    public partial class loginAluno : Form
    {
        public loginAluno()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new regAluno().Show();
            this.Close();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            new TelaInicial().Show();
            this.Close();
        }

        private void mostrarSenhaButton_Click(object sender, EventArgs e)
        {
            if (senhaTextBox.UseSystemPasswordChar)
            {
                senhaTextBox.UseSystemPasswordChar = false;
                mostrarSenhaButton.Text = "Ocultar Senha";
            }
            else
            {
                senhaTextBox.UseSystemPasswordChar = true;
                mostrarSenhaButton.Text = "Mostrar Senha";
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            Aluno _aluno = new Aluno();
            _aluno.email = emailTextBox.Text;
            _aluno.senha = senhaTextBox.Text;

            BLL.validaDadosAluno(_aluno, 'l');
            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsg());
                return;
            }
            else
            {
                MessageBox.Show($"Login efetuado.\n{AlunoLogado.ra}\n{AlunoLogado.nome}\n{AlunoLogado.email}\n{AlunoLogado.senha}\n{AlunoLogado.telefone}\n{AlunoLogado.cpf}\n{AlunoLogado.dataNascimento}\n{AlunoLogado.ativo}");
            }
        }
    }
}
