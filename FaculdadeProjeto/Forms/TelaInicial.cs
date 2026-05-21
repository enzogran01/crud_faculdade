using FaculdadeProjeto.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaculdadeProjeto
{
    public partial class TelaInicial : Form
    {
        public TelaInicial()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            regAluno regAluno = new regAluno();
            regAluno.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            regProfessor regProfessor = new regProfessor();
            regProfessor.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ConsultaAluno consultaAluno = new ConsultaAluno();
            consultaAluno.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ConsultaProfessor consultaProfessor = new ConsultaProfessor();
            consultaProfessor.Show();
            this.Hide();
        }
    }
}
