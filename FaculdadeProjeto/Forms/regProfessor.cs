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
    public partial class regProfessor : Form
    {
        public regProfessor()
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
            new loginProfessor().Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Professor professor = new Professor();
            professor.nome = nomeTextBox.Text;
            professor.email = emailTextBox.Text;
            professor.cpf = CPFTextBox.Text.Replace(".", "").Replace("-", "").Replace("_", "");
            professor.telefone = telefoneTextBox.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Replace("_", "");
            if (senhaTextBox.Text == confirmSenhaTextBox.Text)
                professor.senha = senhaTextBox.Text;
            else
                Erro.setMsg("As senhas precisam ser iguais!");
            
            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsg());
                return;
            }
            BLL.validaDadosProfessor(professor, 'I');
            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsg());
                return;
            }
            MessageBox.Show("Aluno cadastrado com sucesso.");
        }
    }
}
