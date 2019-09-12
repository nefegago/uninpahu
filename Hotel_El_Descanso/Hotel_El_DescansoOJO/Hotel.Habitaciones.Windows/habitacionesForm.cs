using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotel_El_Descanso.Entidades;
using Hotel_El_Descanso.Negocio;


namespace Hotel_El_Descanso.Windows
{
    public partial class habitacionesForm : Form
    {

        List<Habitacion> lista = null;
        BlHabitacion blHabitaciones = new BlHabitacion();
        Habitacion c;
        bool _nuevo = false;

        public habitacionesForm()
        {
            InitializeComponent();
            ActivarControlDatos(gbDatos, false);
            CargarDatos();
        }


        private void ActivarControlDatos(Control Contenedor, bool Estado)
        {
            try
            {
                foreach (var item in Contenedor.Controls)
                {
                    if (item.GetType() == typeof(TextBox))
                    {
                        ((TextBox)item).Enabled = Estado;
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void LimpiarControl(Control Contenedor)
        {
            foreach (var item in Contenedor.Controls)
            {
                if (item.GetType() == typeof(TextBox))
                {
                    ((TextBox)item).Clear();
                }
            }
        }

        private void ActivarButton(bool Estado)
        {
            btnNuevo.Enabled = Estado;
            btnGrabar.Enabled = !Estado;
            btnEliminar.Enabled = Estado;
            btnSalir.Enabled = Estado;
        }

        private void CargarDatos()
        {
            if (lista == null)
            {
                lista = blHabitaciones.Listar();
            }
            dgvDatos.Rows.Clear();
            if (lista.Count > 0)
            {
                for (int i = 0; i < lista.Count; i++)
                {
                    dgvDatos.Rows.Add(lista[i].Id, lista[i].Codigo,
                    lista[i].Precio, lista[i].Estado, lista[i].Categoria_IdCategoria);
                }
            }
        }


        //
        //Botón Grabar 
        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            int n = -1;
            if (_nuevo)
            {
                c = new Habitacion(0, txtCodigo.Text,
                                      decimal.Parse(txtPrecio.Text),
                                      textEstados.Text,
                                      int.Parse(textCategoria.Text)
                    );
                n = blHabitaciones.Insertar(c);
            }
            else
            {
                c.Codigo = txtCodigo.Text;
                c.Precio = decimal.Parse(txtPrecio.Text);
                c.Estado = textEstados.Text;
                c.Categoria_IdCategoria = int.Parse(textCategoria.Text);
                n = blHabitaciones.Actualizar(c);
            }
            if (n > 0)
            {
                MessageBox.Show("Datos Habitacion grabados Correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActivarControlDatos(gbDatos, false);
                ActivarButton(true);
                dgvDatos.Enabled = true;
                LimpiarControl(gbDatos);
                btnEditar.Text = "Editar";
                lista = blHabitaciones.Listar();
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Error al grabar Habitacion", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //Botón Editar 
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            _nuevo = false;
            if (btnEditar.Text == "Cancelar")
            {
                LimpiarControl(gbDatos); ActivarControlDatos(gbDatos, false);
                ActivarButton(true);
                dgvDatos.Enabled = true;
                btnEditar.Text = "Editar";
            }
            else
            {
                if (dgvDatos.RowCount > 0)
                {
                    c = blHabitaciones.TraerPorId((int)dgvDatos[0, dgvDatos.CurrentRow.Index].Value);
                    txtCodigo.Text = c.Codigo;
                     
                    //   if ( c.Precio.ToString().Length > 0 )
                    // {

                    txtPrecio.Text = c.Precio.ToString();
                    //}


                    textEstados.Text = c.Estado;
                    textCategoria.Text = c.Categoria_IdCategoria.ToString();

                    ActivarControlDatos(gbDatos, true);
                    ActivarButton(false);
                    dgvDatos.Enabled = false;
                    btnEditar.Text = "Cancelar";
                }
            }
        }


        // Botón Eliminar 
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.RowCount > 0)
            {

                c = blHabitaciones.TraerPorId((int)dgvDatos[0, dgvDatos.CurrentRow.Index].Value);
                DialogResult rpta = MessageBox.Show("Desea eliminar el registro", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rpta == System.Windows.Forms.DialogResult.Yes)
                {
                    int n = blHabitaciones.Eliminar(c.Id); if (n > 0)
                    {
                        MessageBox.Show("Registro Habitacion Eliminado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lista = blHabitaciones.Listar();
                        CargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("Error al Eliminar Habitacion ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        // Botón Salir 
        private void BtnSalir_Click_1(object sender, EventArgs e)
        {
            Close();
        }


        //Botón Nuevo 
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            _nuevo = true;
            ActivarControlDatos(gbDatos, true);
            btnEditar.Text = "Cancelar";
            ActivarButton(false);
            LimpiarControl(gbDatos);
            txtCodigo.Focus();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            Form pasar = new Home();
            pasar.Show();
            this.Hide();
        }
    }
}
