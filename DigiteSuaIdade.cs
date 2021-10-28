using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigiteSuaIdade
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void B_Idade_Click(object sender, EventArgs e)
        {
            String idade;
            idade = TB_Idade.Text;
            MessageBox.Show("Sua idade é " + idade + " anos.");
        }
    }
}
