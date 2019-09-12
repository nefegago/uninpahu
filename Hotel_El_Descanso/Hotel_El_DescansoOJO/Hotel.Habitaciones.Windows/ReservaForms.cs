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
    public partial class ReservaForms : Form
    {

        List<Reserva> lista = null;
        BLReserva bLReserva = new BLReserva();
        Reserva c;
        bool _nuevo = false;

        public ReservaForms()
        {
            InitializeComponent();
            ActivarControlDatos(gbDatos, false);
            CargarDatos();
            
           // txtFechaInicio.Text = Program.variable1.ToString();

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
                lista = bLReserva.Listar();
            }
            if (lista.Count > 0)
            {
                dgvDatos.Rows.Clear();
                for (int i = 0; i < lista.Count; i++)
                {
                    dgvDatos.Rows.Add(
                                        lista[i].Id,
                                        lista[i].FechaInicio,
                                        lista[i].FechaFin,
                                        lista[i].Estado,
                                        lista[i].Habitaciones_Categoria,
                                        lista[i].Habitaciones_IdHabitaciones,
                                        lista[i].Usuario_idUsuario,
                                        lista[i].Servicios_idServicios,
                                        lista[i].Huspedes_idHuesped,
                                        lista[i].Clientes_NoDocumento
                                      );
                }
            }
            /*
            //textUsuario_idUsuario.Text =             Program.vIdUsuario;
            //program.nombre;
            //Program.vIdUsuario;
            //program.nombre;
    */    
    }
                 

        private void BtnEditar_Click_1(object sender, EventArgs e)
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
                    
                    c = bLReserva.TraerPorId((int)dgvDatos[0, dgvDatos.CurrentRow.Index].Value);
                    txtFechaInicio.Text = c.FechaInicio;
                    txtFechaFin.Text = c.FechaFin;
                    textEstado.Text = c.Estado;
                    textHabitaciones_Categoria.Text = c.Habitaciones_Categoria.ToString();
                    textHabitaciones_IdHabitaciones.Text = c.Habitaciones_IdHabitaciones.ToString();
                    textUsuario_idUsuario.Text = c.Usuario_idUsuario.ToString();
                    textServicios_idServicios.Text = c.Servicios_idServicios.ToString();
                    textHuspedes_idHuesped.Text = c.Huspedes_idHuesped.ToString();
                    textClientes_NoDocumento.Text = c.Clientes_NoDocumento;

                    ActivarControlDatos(gbDatos, true);
                    ActivarButton(false);
                    dgvDatos.Enabled = false;
                    btnEditar.Text = "Cancelar";
                 
                }
            }

        }

 

        private void BtnEliminar_Click_1(object sender, EventArgs e)
        {
            if (dgvDatos.RowCount > 0)
            {
                
                c = bLReserva.TraerPorId((int)dgvDatos[0, dgvDatos.CurrentRow.Index].Value);
                DialogResult rpta = MessageBox.Show("Desea eliminar el registro", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rpta == System.Windows.Forms.DialogResult.Yes)
                {

                    int n = bLReserva.Eliminar(c.Id);
                    if (n > 0)
                    {
                        MessageBox.Show("Registro Cliente Eliminado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lista = bLReserva.Listar();
                        CargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar Cliente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                
            }
        }

        private void BtnSalir_Click_1(object sender, EventArgs e) 
        {
            Close();
        }

        private void BtnRegresar_Click_1(object sender, EventArgs e)
        {
            Form pasar = new Hotel_El_Descanso.Windows.Home();
            pasar.Show();
            this.Hide();  
        }

        private void ReservaForm_Load(object sender, EventArgs e)
        {

        }

        private void BtnNuevo_Click_1(object sender, EventArgs e)
        {
            _nuevo = true;
            ActivarControlDatos(gbDatos, true);
            btnEditar.Text = "Cancelar";
            ActivarButton(false);
            LimpiarControl(gbDatos);
            txtFechaInicio.Focus();
        }

        private void BtnGrabar_Click_1(object sender, EventArgs e)
        {
            int n = -1;
            if (_nuevo)
            {
                c = new Reserva(0,
                                      txtFechaInicio.Text,
                                      txtFechaFin.Text,
                                      textEstado.Text,
                                      int.Parse(textHabitaciones_Categoria.Text),
                                      int.Parse(textHabitaciones_IdHabitaciones.Text),
                                      int.Parse(textUsuario_idUsuario.Text),
                                      int.Parse(textServicios_idServicios.Text),
                                      int.Parse(textHuspedes_idHuesped.Text),
                                      textClientes_NoDocumento.Text
                    );
                n = bLReserva.Insertar(c);
            }
            else
            {
                c.FechaInicio = txtFechaInicio.Text;
                c.FechaFin = txtFechaFin.Text;
                c.Estado = textEstado.Text;
                c.Habitaciones_Categoria = int.Parse(textHabitaciones_Categoria.Text);
                c.Habitaciones_IdHabitaciones = int.Parse(textHabitaciones_IdHabitaciones.Text);
                c.Usuario_idUsuario = int.Parse(textUsuario_idUsuario.Text);
                c.Servicios_idServicios = int.Parse(textServicios_idServicios.Text);
                c.Huspedes_idHuesped = int.Parse(textHuspedes_idHuesped.Text);
                c.Clientes_NoDocumento = textClientes_NoDocumento.Text;
                n = bLReserva.Actualizar(c);
            }
            if (n > 0)
            {
                MessageBox.Show("Datos Cliente grabados Correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActivarControlDatos(gbDatos, false);
                ActivarButton(true);
                dgvDatos.Enabled = true;
                LimpiarControl(gbDatos);
                btnEditar.Text = "Editar";
                lista = bLReserva.Listar();
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Error al grabar Cliente", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReservaForms_Load(object sender, EventArgs e)
        {

        }
    }//
}
