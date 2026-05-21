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
    public partial class GerenciaAdmin : Form
    {
        Admin admin = new Admin();
        public GerenciaAdmin()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            TelaAdmin telaAdmin = new TelaAdmin();
            telaAdmin.Show();
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            admin.id = idTextBox.Text;
            admin.nome = nomeTextBox.Text;
            admin.email = emailTextBox.Text;
            admin.senha = senhaTextBox.Text;

            BLL.validaDadosAdmin(admin, 'I');
            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsg());
                return;
            }
            MessageBox.Show("Administrador salvo com sucesso.");
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            admin.id = idTextBox.Text;
            BLL.validaIDAdmin(admin, 'c');

            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsg());
            }
            else
            {
                idTextBox.Text = admin.id;
                nomeTextBox.Text = admin.nome;
                emailTextBox.Text = admin.email;
                senhaTextBox.Text = admin.senha;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
            "Tem certeza que deseja Alterar este Administrador? Esta ação não poderá ser desfeita.",
            "Confirmar Alteração",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
            );
            if (resultado == DialogResult.Yes)
            {
                admin.id = idTextBox.Text;
                admin.nome = nomeTextBox.Text;
                admin.email = emailTextBox.Text;
                if (senhaTextBox.Text.Length <= 20)
                {
                    admin.senha = senhaTextBox.Text;
                }
                else if (senhaTextBox.Text.Length < 8)
                {
                    Erro.setMsg("Senha precisa ter entre 8 e 20 caracteres");
                }
                if (Erro.getErro())
                {
                    MessageBox.Show(Erro.getMsg());
                    return;
                }
                BLL.validaDadosAdmin(admin, 'A');
                if (Erro.getErro())
                {
                    MessageBox.Show(Erro.getMsg());
                    return;
                }
                MessageBox.Show("Admin alterado com sucesso.");
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            idTextBox.Clear();
            nomeTextBox.Clear();
            emailTextBox.Clear();
            senhaTextBox.Clear();
            idTextBox.Focus();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
            "Tem certeza que deseja EXCLUIR este Administrador? Esta ação não poderá ser desfeita.",
            "Confirmar EXCLUSÃO",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
            );
            if (resultado == DialogResult.Yes)
            {
                admin.id = idTextBox.Text;
                BLL.validaIDAdmin(admin, 'd');
                if (Erro.getErro())
                {
                    MessageBox.Show(Erro.getMsg());
                    return;
                }
                MessageBox.Show("Administrador deletado com sucesso.");
            }
        }

        private void senhaTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
