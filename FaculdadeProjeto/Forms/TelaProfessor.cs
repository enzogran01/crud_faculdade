using FaculdadeProjeto.Models;
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
    public partial class TelaProfessor : Form
    {
        private void ConsultaLista()
        {
            listView1.Columns.Clear();
            listView1.Items.Clear();

            listView1.View = View.Details;

            listView1.FullRowSelect = true;
            listView1.GridLines = true;

            listView1.Columns.Add("Codigo", 100);
            listView1.Columns.Add("Nome", 110);
            listView1.Columns.Add("Descrição", 180);
            listView1.Columns.Add("Curso", 180);

            listView1.BeginUpdate();
            for (int i = 1; i <= DAL.ObterMaiorRA(); i++)
            {
                //Erro.setMsg("");

                //aluno.ra = i.ToString();
                //BLL.validaRA(aluno, 'c');
                //if (!Erro.getErro())
                //{
                //    ListViewItem linha = new ListViewItem(i.ToString());
                //    linha.SubItems.Add(aluno.cpf);
                //    linha.SubItems.Add(aluno.nome);
                //    linha.SubItems.Add(aluno.email);
                //    linha.SubItems.Add(aluno.senha);
                //    linha.SubItems.Add(aluno.telefone);
                //    linha.SubItems.Add(aluno.dataNascimento.ToString());

                //    if (!aluno.ativo)
                //    {
                //        linha.BackColor = Color.MistyRose;
                //        linha.ForeColor = Color.DarkRed;
                //    }

                //    listView1.Items.Add(linha);
                }
            }
            //listView1.EndUpdate
        public TelaProfessor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void TelaProfessor_Load(object sender, EventArgs e)
        {
            if (ProfessorLogado.id == "") 
            {
                MessageBox.Show("Por favor, faça login antes de entrar."); 
                new loginProfessor().Show();
                this.Close();
            }


        }
    }
}
