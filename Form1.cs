using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoLogin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ConexaoSQL bd = new ConexaoSQL();
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string nome = txtLogin.Text;
            string senhaDigitada = txtSenha.Text;
            if (nome != "" && senhaDigitada != "")
            {
                string comando = string.Format("select senha from logins where nome='{0}';", nome);
                bd.conectarBD();
                string senha = bd.executarconsulta(comando);
                label1.Text = senha;
                VerificaSenha(senhaDigitada, senha);
            }
            else { MessageBox.Show("Erro 01: Falha no Banco ou usuário inexistente"); }
        }

        private void VerificaSenha(string senha1, string senha2)
        {
            if(senha1 == senha2)
            {
                MessageBox.Show("Entrou");
            }
            else
            {
                MessageBox.Show("Senha errada");
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string nome = txtLogin.Text;
            string senha = txtSenha.Text;

            string comando = string.Format("select nome from logins where nome ='{0}';", nome);
            bd.conectarBD();
            string nomeVerificado = bd.executarconsulta(comando);

            if(nomeVerificado == "")
            {
                string comando2 = string.Format("insert into logins (nome, senha) values ('{0}','{1}')", nome, senha);
                bd.executarcomandos(comando2);
            }
            else
            {
                MessageBox.Show("Usuário já existente!");
            }
        }
    }
}
