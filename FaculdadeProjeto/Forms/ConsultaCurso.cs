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
    public partial class ConsultaCurso : Form
    {
        Curso curso = new Curso();
        public ConsultaCurso()
        {
            InitializeComponent();
            ConsultaLista();
        }

        private void ConsultaLista()
        {
            // Limpa qualquer configuração anterior
            listView1.Columns.Clear();
            listView1.Items.Clear();

            // Define a visualização como "Details" (obrigatório para aparecer em colunas)
            listView1.View = View.Details;

            // Deixa a linha inteira selecionável e adiciona linhas de grade
            listView1.FullRowSelect = true;
            listView1.GridLines = true;

            // Adiciona os textos de identificação de cada coluna (Texto, Largura em pixels)
            listView1.Columns.Add("ID/Código", 100);
            listView1.Columns.Add("Nome", 180);
            listView1.Columns.Add("Duracao", 80);

            // Dica de performance: congela o visual do ListView enquanto adiciona as linhas
            listView1.BeginUpdate();
            for (int i = 1; i <= DAL.ObterMaiorRA(); i++)
            {
                Erro.setMsg("");

                curso.id = i.ToString();
                BLL.validaIDCurso(curso, 'c');
                if (!Erro.getErro())
                {
                    ListViewItem linha = new ListViewItem(i.ToString());
                    linha.SubItems.Add(curso.nome);
                    linha.SubItems.Add(curso.duracao.ToString());

                    listView1.Items.Add(linha);
                }
            }
            listView1.EndUpdate();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                new EdicaoCurso(listView1.SelectedItems[0].Text).Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, selecione um curso na lista para editar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            new TelaAdmin().Show();
            this.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
