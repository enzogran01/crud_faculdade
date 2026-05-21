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
    public partial class EdicaoCurso : Form
    {
        Curso curso = new Curso();
        public EdicaoCurso(string id)
        {
            InitializeComponent();
            curso.id = id;
            EdicaoCurso_Load();
        }

        private void EdicaoCurso_Load()
        {
            BLL.validaIDCurso(curso, 'c');

            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsg());
            }
            else
            {
                idTextBox.Text = curso.id;
                nomeTextBox.Text = curso.nome;
                duracaoTextBox.Text = curso.duracao.ToString();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Curso _curso = new Curso();
            _curso.id = idTextBox.Text;
            _curso.nome = nomeTextBox.Text;
            _curso.duracao = int.Parse(duracaoTextBox.Text);

            BLL.validaDadosCurso(_curso, 'A');
            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsg());
                return;
            }
            MessageBox.Show("Curso alterado com sucesso.");
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            new ConsultaCurso().Show();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
