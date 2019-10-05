using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotel.Usuario.Entidades;
using Hotel.Usuario.Negocio;


namespace Hotel.Habitaciones.Windows
{
    public partial class usuarioForms : Form
    {
        public usuarioForms()
        {
            InitializeComponent();
            ActivarControlDatos(gbDatos, false);
            CargarDatos();
        }

        List<UsuariosHotel> lista = null;
        BLUsuario blUsuario = new BLUsuario();
        UsuariosHotel c;
        bool _nuevo = false;

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
                lista = blUsuario.Listar();
            }
            if (lista.Count > 0)
            {
                dgvDatos.Rows.Clear();
                for (int i = 0; i < lista.Count; i++)
                {
                    dgvDatos.Rows.Add(lista[i].Id,
                                        lista[i].Identificacion,
                                        lista[i].Nombre,
                                        lista[i].Nombre,
                                        lista[i].Clave,
                                        lista[i].Perfil,
                                        lista[i].Estado,
                                        lista[i].Correo
                                      );
                }
            }
        }























        private void UsuarioForms_Load(object sender, EventArgs e)
        {

        }

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            int n = -1;
            if (_nuevo)
            {
                c = new UsuariosHotel(0, txtIdentificacion.Text,
                                      txtNombre.Text,
                                      textUsuarios.Text,
                                      textClave.Text,
                                      textPerfil.Text,
                                      textEstado.Text,
                                      textCorreo.Text
                    );
                n = blUsuario.Insertar(c);
            }
            else
            {
                c.Identificacion = txtIdentificacion.Text;
                c.Nombre = txtNombre.Text;
                c.Usuarios = textUsuarios.Text;
                c.Clave = textClave.Text;
                c.Perfil = textPerfil.Text;
                c.Estado = textEstado.Text;
                c.Correo = textCorreo.Text;
                n = blUsuario.Actualizar(c);
            }
            if (n > 0)
            {
                MessageBox.Show("Datos Usuario grabados Correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActivarControlDatos(gbDatos, false);
                ActivarButton(true);
                dgvDatos.Enabled = true;
                LimpiarControl(gbDatos);
                btnEditar.Text = "Editar";
                lista = blUsuario.Listar();
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Error al grabar Usuario", "Aviso",
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
                    c = blUsuario.TraerPorId((int)dgvDatos[0, dgvDatos.CurrentRow.Index].Value);
                    txtIdentificacion.Text = c.Identificacion;
                    txtNombre.Text = c.Nombre;
                    textUsuarios.Text = c.Usuarios;
                    textClave.Text = c.Clave;
                    textPerfil.Text = c.Perfil;
                    textEstado.Text = c.Estado;
                    textCorreo.Text = c.Correo;

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
                c = blUsuario.TraerPorId((int)dgvDatos[0, dgvDatos.CurrentRow.Index].Value);
                DialogResult rpta = MessageBox.Show("Desea eliminar el registro", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rpta == System.Windows.Forms.DialogResult.Yes)
                {
                    int n = blUsuario.Eliminar(c.Id); if (n > 0)
                    {
                        MessageBox.Show("Registro Usuario Eliminado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lista = blUsuario.Listar();
                        CargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar Usuario", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            _nuevo = true;
            ActivarControlDatos(gbDatos, true);
            btnEditar.Text = "Cancelar";
            ActivarButton(false);
            LimpiarControl(gbDatos);
            txtIdentificacion.Focus();
        }
    }
}
