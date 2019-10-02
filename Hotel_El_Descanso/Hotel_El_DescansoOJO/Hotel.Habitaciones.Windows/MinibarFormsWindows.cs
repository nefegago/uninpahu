using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotel.MiniBar.Entidades;
using Hotel.MiniBar.Negocio;


      
namespace Hotel.Habitaciones.Windows
{
    public partial class MinibarFormsWindows : Form
    {


        List<MiniBarE> lista = null;
        BLMiniBar blMiniBar = new BLMiniBar();
        MiniBarE c;
        bool _nuevo = false;


        public MinibarFormsWindows()
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
                lista = blMiniBar.Listar();
            }
            dgvDatos.Rows.Clear();
            if (lista.Count > 0)
            {
                for (int i = 0; i < lista.Count; i++)
                {
                    dgvDatos.Rows.Add(
                       lista[i].Id,
                       lista[i].Codigo,
                       lista[i].Nombre,
                       lista[i].Cantidad,
                       lista[i].Precio
                       );
                }

            }
        }












        private void MinibarFormsWindows_Load(object sender, EventArgs e)
        {

        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            _nuevo = true;
            ActivarControlDatos(gbDatos, true);
            btnEditar.Text = "Cancelar";
            ActivarButton(false);
            LimpiarControl(gbDatos);
            txtCodigo.Focus();
        }

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            int n = -1;
            if (_nuevo)
            {
                c = new MiniBarE(0,
                txtCodigo.Text,
                txtNombre.Text,
                textCantidad.Text,
                textPrecio.Text
);
                n = blMiniBar.Insertar(c);
            }
            else
            {
                c.Codigo = txtCodigo.Text;
                c.Nombre = txtNombre.Text;
                c.Cantidad = textCantidad.Text;
                c.Precio = textPrecio.Text;
                n = blMiniBar.Actualizar(c);
            }
            if (n > 0)
            {
                MessageBox.Show("Datos grabados correctamente", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActivarControlDatos(gbDatos, false);
                ActivarButton(true);
                dgvDatos.Enabled = true;
                LimpiarControl(gbDatos);
                btnEditar.Text = "Editar";
                lista = blMiniBar.Listar();
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Error al grabar", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            _nuevo = false;
            if (btnEditar.Text == "Cancelar")
            {
                LimpiarControl(gbDatos);
                ActivarControlDatos(gbDatos, false);
                ActivarButton(true);
                dgvDatos.Enabled = true;
                btnEditar.Text = "Editar";
            }
            else
            {
                if (dgvDatos.RowCount > 0)
                {
                    c = blMiniBar.TraerPorId((int)dgvDatos[0, dgvDatos.
                    CurrentRow.Index].Value);
                    txtCodigo.Text = c.Codigo;
                    txtNombre.Text = c.Nombre;
                    textCantidad.Text = c.Cantidad;
                    textPrecio.Text = Convert.ToDecimal (c.Precio);

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
                c = blMiniBar.TraerPorId((int)dgvDatos[0, dgvDatos.CurrentRow.Index].Value);
                DialogResult rpta =
                MessageBox.Show("Desea eliminar el registro", "Eliminar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rpta == System.Windows.Forms.DialogResult.Yes)
                {
                    int n = blMiniBar.Eliminar(c.Id);
                    if (n > 0)
                    {
                        MessageBox.Show("Registro eliminado", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lista = blMiniBar.Listar();
                        CargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            Form pasar = new Home();
            pasar.Show();
            this.Hide();
        }
    }
}
