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
    public partial class clienteForms : Form
    {

        List<ClientesHotel> lista = null;
        BLCliente bLCliente = new BLCliente();
        ClientesHotel c;
        bool _nuevo = false;

        public clienteForms()
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
                lista = bLCliente.Listar();
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
                                        lista[i].TelefonoFijo,
                                        lista[i].Celular,
                                        lista[i].Correo,
                                        lista[i].FechaNacimiento,
                                        lista[i].NoTarjetaCredito
                                      );
                }
            }
        }





        private void ClienteForms_Load(object sender, EventArgs e)
        {

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
                c = new ClientesHotel("",
                                      txtNombre.Text,
                                      txtPrimerApellido.Text,
                                      textSegundoApellido.Text,
                                      textTelefonoFijo.Text,
                                      textCelular.Text,
                                      textCorreo.Text,
                                      textFechaNacimiento.Text,
                                      textNoTarjetaCredito.Text
                    );
                n = bLCliente.Insertar(c);
            }
            else
            {
                c.Nombre = txtNombre.Text;
                c.PrimerApellido = txtPrimerApellido.Text;
                c.SegundoApellido = textSegundoApellido.Text;
                c.TelefonoFijo = textTelefonoFijo.Text;
                c.Celular = textCelular.Text;
                c.Correo = textCorreo.Text;
                c.FechaNacimiento = textFechaNacimiento.Text;
                c.NoTarjetaCredito = textNoTarjetaCredito.Text;
                n = bLCliente.Actualizar(c);
            }
            if (n > 0)
            {
                MessageBox.Show("Datos Cliente grabados Correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActivarControlDatos(gbDatos, false);
                ActivarButton(true);
                dgvDatos.Enabled = true;
                LimpiarControl(gbDatos);
                btnEditar.Text = "Editar";
                lista = bLCliente.Listar();
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
                    c = bLCliente.TraerPorId((int)dgvDatos[0, dgvDatos.CurrentRow.Index].Value);
                    txtNombre.Text = c.Nombre;
                    txtPrimerApellido.Text = c.PrimerApellido;
                    textSegundoApellido.Text = c.SegundoApellido;
                    textTelefonoFijo.Text = c.TelefonoFijo;
                    textCelular.Text = c.Celular;
                    textCorreo.Text = c.Correo;
                    textFechaNacimiento.Text = c.FechaNacimiento;
                    textNoTarjetaCredito.Text = c.NoTarjetaCredito;

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
                c = bLCliente.TraerPorId((int)dgvDatos[0, dgvDatos.CurrentRow.Index].Value);
                DialogResult rpta = MessageBox.Show("Desea eliminar el registro", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rpta == System.Windows.Forms.DialogResult.Yes)
                {
                    /*
                    string n = bLCliente.Eliminar(c.Id); if (n > 0)
                    {
                        MessageBox.Show("Registro Cliente Eliminado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lista = bLCliente.Listar();
                        CargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar Cliente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    */
                }

            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        //
    }
}
