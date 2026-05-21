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
    public partial class LoginAdmin : Form
    {
        public LoginAdmin()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

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
            Admin admin = new Admin();
            admin.email = emailTextBox.Text;
            admin.senha = senhaTextBox.Text;

            BLL.validaEntradaAdmin(admin);
            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsg());
                return;
            }
            MessageBox.Show("Login Realizado com sucesso!");
            TelaAdmin telaAdmin = new TelaAdmin();
            telaAdmin.Show();
            this.Close();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            TelaAdmin telaAdmin = new TelaAdmin();
            telaAdmin.Show();
            this.Hide();
        }

        private void LoginAdmin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.A)
            {
                // Torna o botão visível na tela!
                btnAdmin.Visible = true;

                // Opcional: Dá um foco visual direto no botão que acabou de surgir
                btnAdmin.Focus();

                // Impede que o Windows faça o som de "bip" ou propague o atalho para outros cantos
                e.Handled = true;
            }
        }
    }
}
