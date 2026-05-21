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
    public partial class loginProfessor : Form
    {
        Professor professor = new Professor();
        public loginProfessor()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            TelaInicial telaInicial = new TelaInicial();
            telaInicial.Show();
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new regProfessor().Show();
            this.Close();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            Professor professor = new Professor();
            professor.email = emailTextBox.Text;
            professor.senha = senhaTextBox.Text;

            BLL.validaEntradaProfessor(professor);
            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsg());
                return;
            }
            MessageBox.Show("Login Realizado com sucesso!");
        }

        private void btnVoltar_Click_1(object sender, EventArgs e)
        {
            new TelaInicial().Show();
            this.Close();
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new regProfessor().Show();
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
    }
}
