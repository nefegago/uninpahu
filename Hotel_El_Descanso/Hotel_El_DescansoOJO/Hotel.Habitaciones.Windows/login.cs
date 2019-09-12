using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_El_Descanso.Windows
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Program.vIdUsuario = 1;
            Program.vNomUsuario  = "Jhon";

            Form pasar = new Home();
            pasar.Show();

            this.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
           
        private void GbDatos_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
