using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FaculdadeProjeto.Forms
{
    public partial class EdicaoDeProfessor : Form
    {
        Professor professor = new Professor();
        public EdicaoDeProfessor(string id)
        {
            InitializeComponent();
            professor.id = id;
            EdicaoDeProfessor_Load();
        }

        private void EdicaoDeProfessor_Load()
        {
            BLL.validaIDProfessor(professor, 'c');

            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsg());
            }
            else
            {
                idTextBox.Text = professor.id;
                ativoCheckBox.Checked = professor.ativo;
                nomeTextBox.Text = professor.nome;
                CPFTextBox.Text = professor.cpf;
                emailTextBox.Text = professor.email;
                telefoneTextBox.Text = professor.telefone;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Professor _professor = new Professor();
            _professor.id = idTextBox.Text;
            _professor.nome = nomeTextBox.Text;
            _professor.cpf = CPFTextBox.Text.Replace(".", "").Replace("-", "").Replace("_", "");
            _professor.telefone = telefoneTextBox.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Replace("_", "");
            _professor.email = emailTextBox.Text;
            _professor.ativo = ativoCheckBox.Checked;

            if (senhaTextBox.Text == confirmSenhaTextBox.Text)
                _professor.senha = senhaTextBox.Text;
            else
                Erro.setMsg("As senhas precisam ser iguais!" + senhaTextBox.Text + " " + confirmSenhaTextBox.Text);

            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsg());
                return;
            }
            BLL.validaDadosProfessor(_professor, 'A');
            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsg());
                return;
            }
            MessageBox.Show("Professor alterado com sucesso.");
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            new ConsultaProfessor().Show();
            this.Close();
        }
    }
}
