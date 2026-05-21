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
    public partial class ConsultaMatricula : Form
    {
        public ConsultaMatricula()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string raDigitado = raTextBox.Text;

            if (string.IsNullOrEmpty(raDigitado))
            {
                MessageBox.Show("Digite o RA do aluno.");
                return;
            }

            // Chama o método da DAL passando o RA desejado
            List<Matricula> matriculasDoAluno = DAL.BuscarMatriculasPorAluno(raDigitado);

            if (!Erro.getErro())
            {
                // Limpa qualquer configuração anterior
                listView1.Columns.Clear();
                listView1.Items.Clear();

                // Define a visualização como "Details" (obrigatório para aparecer em colunas)
                listView1.View = View.Details;

                // Deixa a linha inteira selecionável e adiciona linhas de grade
                listView1.FullRowSelect = true;
                listView1.GridLines = true;

                listView1.Columns.Add("ID", 50);
                listView1.Columns.Add("Data", 100);
                listView1.Columns.Add("Status", 80);
                listView1.Columns.Add("Turno", 80);
                listView1.Columns.Add("Aluno", 70);
                listView1.Columns.Add("Curso", 110);

                listView1.BeginUpdate();
                foreach (Matricula m in matriculasDoAluno)
                {
                    ListViewItem linha = new ListViewItem(m.id.ToString());
                    linha.SubItems.Add(m.data.ToShortDateString());
                    linha.SubItems.Add(m.ativo.ToString());
                    linha.SubItems.Add(m.turno);
                    linha.SubItems.Add(m.nm_aluno.ToString());
                    linha.SubItems.Add(m.nm_curso.ToString());

                    listView1.Items.Add(linha);
                }

                listView1.EndUpdate();
            }
            else
            {
                MessageBox.Show(Erro.getMsg(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            TelaAdmin telaAdmin = new TelaAdmin();
            telaAdmin.Show();
            this.Close();
        }

        private void raTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
