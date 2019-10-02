using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel.Habitaciones.Windows
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //Form pasar = new Clientes();
             Form pasar = new Home();
          //  Form pasar = new usuarioForms();
            pasar.Show();

            this.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
