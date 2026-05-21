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
    public partial class ConsultaProfessor : Form
    {
        Professor professor = new Professor();
        public ConsultaProfessor()
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
            listView1.Columns.Add("CPF", 110);
            listView1.Columns.Add("Nome Completo", 180);
            listView1.Columns.Add("E-mail", 180);
            listView1.Columns.Add("Senha", 180);
            listView1.Columns.Add("Telefone", 110);

            // Dica de performance: congela o visual do ListView enquanto adiciona as linhas
            listView1.BeginUpdate();
            for (int i = 1; i <= DAL.ObterMaiorRA(); i++)
            {
                Erro.setMsg("");

                professor.id = i.ToString();
                BLL.validaID(professor, 'c');
                if (!Erro.getErro())
                {
                    ListViewItem linha = new ListViewItem(i.ToString());
                    linha.SubItems.Add(professor.cpf);
                    linha.SubItems.Add(professor.nome);
                    linha.SubItems.Add(professor.email);
                    linha.SubItems.Add(professor.senha);
                    linha.SubItems.Add(professor.telefone);

                    if (!professor.ativo)
                    {
                        linha.BackColor = Color.MistyRose;
                        linha.ForeColor = Color.DarkRed;
                    }

                    listView1.Items.Add(linha);
                }
            }
            listView1.EndUpdate();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                new EdicaoDeProfessor(listView1.SelectedItems[0].Text).Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, selecione um aluno na lista para excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            new TelaInicial().Show();
            this.Close();
        }
    }
}
