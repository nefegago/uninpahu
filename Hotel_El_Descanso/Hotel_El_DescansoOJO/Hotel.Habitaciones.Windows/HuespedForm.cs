using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;  
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotel_El_Descanso.Negocio;
using Hotel_El_Descanso.Entidades;
 
namespace Hotel.Habitaciones.Windows
{
    public partial class HuespedForm : Form
    {

        List<Huespe> lista = null;
        BLHuespe blHuesped = new BLHuespe();
        Huespe c;
        bool _nuevo = false;

        public HuespedForm()
        {
            InitializeComponent();
            ActivarControlDatos(gbDatos, false);
            CargarDatos();
            //textBox1.Text = Program.variable1.ToString();
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
                lista = blHuesped.Listar();
            }
            if (lista.Count > 0)
            {
                dgvDatos.Rows.Clear();
                for (int i = 0; i < lista.Count; i++)
                {
                    dgvDatos.Rows.Add(lista[i].Id,
                                        lista[i].Nombre,
                                        lista[i].PrimerApellido,
                                        lista[i].SegundoApellido,
                                        lista[i].NoDocumento,
                                        lista[i].TelefonoFijo,
                                        lista[i].Celular,
                                        lista[i].Correo,
                                        lista[i].FechaNacimiento
                                     
                                      );
                }
            }
        }






        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            _nuevo = true;
            ActivarControlDatos(gbDatos, true);
            btnEditar.Text = "Cancelar";
            ActivarButton(false);
            LimpiarControl(gbDatos);
            txtNombre.Focus();
        }

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            int n = -1;
            if (_nuevo)
            {
                c = new Huespe(0,
                                      txtNombre.Text,
                                      txtPrimerApellido.Text,
                                      textSegundoApellido.Text,
                                      textNoDocumento.Text,
                                      textTelefonoFijo.Text,
                                      textCelular.Text,
                                      textCorreo.Text,
                                      textFechaNacimiento.Text
                    
                    );
                n = blHuesped.Insertar(c);
            }
            else
            {
                c.Nombre = txtNombre.Text;
                c.PrimerApellido = txtPrimerApellido.Text;
                c.SegundoApellido = textSegundoApellido.Text;
                c.NoDocumento = textNoDocumento.Text;
                c.TelefonoFijo = textTelefonoFijo.Text;
                c.Celular = textCelular.Text;
                c.Correo = textCorreo.Text;
                c.FechaNacimiento = textFechaNacimiento.Text;
                n = blHuesped.Actualizar(c);
            }
            if (n > 0)
            {
                MessageBox.Show("Datos Cliente grabados Correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActivarControlDatos(gbDatos, false);
                ActivarButton(true);
                dgvDatos.Enabled = true;
                LimpiarControl(gbDatos);
                btnEditar.Text = "Editar";
                lista = blHuesped.Listar();
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Error al grabar Cliente", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
                    c = blHuesped.TraerPorId((int)dgvDatos[0, dgvDatos.CurrentRow.Index].Value);
                    txtNombre.Text = c.Nombre;
                    txtPrimerApellido.Text = c.PrimerApellido;
                    textSegundoApellido.Text = c.SegundoApellido;
                    textNoDocumento.Text = c.NoDocumento;
                    textTelefonoFijo.Text = c.TelefonoFijo;
                    textCelular.Text = c.Celular;
                    textCorreo.Text = c.Correo;
                    textFechaNacimiento.Text = c.FechaNacimiento;

                    ActivarControlDatos(gbDatos, true);
                    ActivarButton(false);
                    dgvDatos.Enabled = false;
                    btnEditar.Text = "Cancelar";
                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.RowCount > 0)
            {
                c = blHuesped.TraerPorId((int)dgvDatos[0, dgvDatos.CurrentRow.Index].Value);
                DialogResult rpta = MessageBox.Show("Desea eliminar el registro", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rpta == System.Windows.Forms.DialogResult.Yes)
                {

                    int n = blHuesped.Eliminar(c.Id.ToString());
                    if (n > 0)
                    {
                        MessageBox.Show("Registro Cliente Eliminado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lista = blHuesped.Listar();
                        CargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar Cliente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            Form pasar = new Hotel_El_Descanso.Windows.Home();
            pasar.Show();
            this.Hide();
        }

        private void HuespedForm_Load(object sender, EventArgs e)
        {

        }
    }
}
