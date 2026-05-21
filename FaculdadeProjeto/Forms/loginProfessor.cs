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
    }
}
