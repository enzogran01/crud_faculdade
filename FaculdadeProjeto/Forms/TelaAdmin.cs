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
    public partial class TelaAdmin : Form
    {
        public TelaAdmin()
        {
            InitializeComponent();
        }

        private void TelaAdmin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConsultaCurso consultaCurso = new ConsultaCurso();
            consultaCurso.Show();   
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ConsultaAluno consultaAluno = new ConsultaAluno();
            consultaAluno.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ConsultaProfessor consultaProfessor = new ConsultaProfessor();
            consultaProfessor.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConsultaMatricula consultaMatricula = new ConsultaMatricula();
            consultaMatricula.Show();
            this.Close();
        }

        private void TelaAdmin_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            new TelaInicial().Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GerenciaAdmin gerenciaAdmin = new GerenciaAdmin();
            gerenciaAdmin.Show();
            this.Close();
        }
    }
}
