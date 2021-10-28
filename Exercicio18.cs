using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exercicio18exibe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        class tp_no
        {
            public string nome, idade, genero;
            public tp_no prox;
        }

        void Insere(ref tp_no t, string n, string i, string g)
        {
            tp_no no = new tp_no();
            no.nome = n;
            no.idade = i;
            no.genero = g;
            if (t != null)
                no.prox = t;
            t = no;
        }

        tp_no lista = null;
        tp_no atual = null;
        tp_no anterior = null;

        private void B_Inclui_Click(object sender, EventArgs e)
        {
            Insere(ref lista, TB_Nome.Text, TB_Idade.Text, CB_Genero.Text);

            TB_Nome.Clear();
            TB_Idade.Clear();
            CB_Genero.Text = "";
        }

        private void B_Exibe_Click(object sender, EventArgs e)
        {
            tp_no aux = lista;
            while (aux != null)
            {
                LB_Registros.Items.Add("Nome: " + aux.nome);
                LB_Registros.Items.Add("Idade: " + aux.idade + " anos");
                LB_Registros.Items.Add("Gênero: " + aux.genero);

                aux = aux.prox;
            }

        }

        void procura(tp_no l, string procurado, ref tp_no atu, ref tp_no ant)
        {
            ant = null;
            atu = l; //atu de atual
            while (atu != null && procurado.ToLower() != atu.nome.ToLower())
            {
                ant = atu;
                atu = atu.prox;
            }
        }

        private void B_Procurar_A_Click(object sender, EventArgs e)
        {
            procura(lista, TB_Procurado_A.Text, ref atual, ref anterior);
            if (atual != null) //encontrou (pega da memoria e joga p interface do usuario (IU)
            {
                TB_Nome_A.Text = atual.nome;
                TB_Idade_A.Text = atual.idade;
                CB_Genero_A.Text = atual.genero;
            }
            else //nao encontrou
                MessageBox.Show("Nome não encontrado");
        }

        private void B_Altera_Click(object sender, EventArgs e)
        {
            //pega da IU e leva para a memoria
            atual.nome = TB_Nome_A.Text;
            atual.idade = TB_Idade_A.Text;
            atual.genero = CB_Genero_A.Text;
            Insere(ref lista, TB_Nome_A.Text, TB_Idade_A.Text, CB_Genero_A.Text); //eu que fiz os clears

            TB_Nome_A.Clear();
            TB_Idade_A.Clear();
            CB_Genero_A.Text = "";
        }

        private void B_Procura_Click(object sender, EventArgs e)
        {
            procura(lista, TB_Nome_P.Text, ref atual, ref anterior);
            if (atual != null) //encontrou (pega da memoria e joga p interface do usuario (IU)
            {
                TB_Nome_A.Text = atual.nome;
                TB_Idade_A.Text = atual.idade;
                CB_Genero_A.Text = atual.genero;
            }
            else //nao encontrou
                MessageBox.Show("Nome não encontrado");
        }

        private void B_Exclui_Click(object sender, EventArgs e)
        {
            if (atual == lista)
            {
                lista = atual.prox;
                atual.prox = null;
            }
            else if (atual.prox == null)
            {
                anterior.prox = null;
            }
            else
            {
                anterior.prox = atual.prox;
            }
        }
    }
}
