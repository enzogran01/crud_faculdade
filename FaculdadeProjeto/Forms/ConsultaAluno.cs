using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace FaculdadeProjeto.Forms
{
    public partial class ConsultaAluno : Form
    {
        Aluno aluno = new Aluno();
        public ConsultaAluno()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Limpa qualquer configuração anterior
            listView1.Columns.Clear();
            listView1.Items.Clear();

            // Define a visualização como "Details" (obrigatório para aparecer em colunas)
            listView1.View = View.Details;

            // Deixa a linha inteira selecionável e adiciona linhas de grade
            listView1.FullRowSelect = true;
            listView1.GridLines = true;

            listView1.Columns.Add("RA", 100);
            listView1.Columns.Add("Nome Completo", 180);
            listView1.Columns.Add("CPF", 110);
            listView1.Columns.Add("E-mail de Contato", 180);
            // Dica de performance: congela o visual do ListView enquanto adiciona as linhas
            listView1.BeginUpdate(); 
            for (int i = 1; i <= DAL.ObterMaiorRA(); i++)
            {
                Erro.setMsg("");

                // Adiciona os textos de identificação de cada coluna (Texto, Largura em pixels)

                aluno.ra = i.ToString();
                BLL.validaRA(aluno, 'c');
                if (!Erro.getErro())
                {
                    ListViewItem linha = new ListViewItem(i.ToString());
                    linha.SubItems.Add(aluno.nome);
                    linha.SubItems.Add(aluno.cpf);
                    linha.SubItems.Add(aluno.email);

                    listView1.Items.Add(linha);
                }
            }
            listView1.EndUpdate();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            new TelaInicial().Show();
            this.Close();
        }
    }
}
