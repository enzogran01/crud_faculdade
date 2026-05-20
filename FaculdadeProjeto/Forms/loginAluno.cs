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
    }
}
