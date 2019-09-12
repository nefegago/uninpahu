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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     
        private void BtnCategoria_Click(object sender, EventArgs e)
        {
            Form pasar = new categoriaForm();
            pasar.Show();
            this.Hide();
        }

        private void BtnClientes_Click(object sender, EventArgs e)
        {
            Form pasar = new clienteForms();
            pasar.Show();
            this.Hide();
        }

        private void BtnHabitaciones_Click(object sender, EventArgs e)
        {
            Form pasar = new habitacionesForm();
            pasar.Show();
            this.Hide();
        }

        private void BtnUsuario_Click(object sender, EventArgs e)
        {
            Form pasar = new usuarioForms();
            pasar.Show();
            this.Hide();
        }

        private void BtnSalir_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form pasar = new MinibarFormsWindows();
            pasar.Show();
            this.Hide();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form pasar = new Hotel.Habitaciones.Windows.HuespedForm();
            pasar.Show(); 
            this.Hide();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Form pasar = new Hotel.Habitaciones.Windows.ReservaForms();
            pasar.Show(); 
            this.Hide(); 
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
