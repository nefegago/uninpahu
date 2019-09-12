using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_El_Descanso.Entidades;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Hotel_El_Descanso.Datos
{
    public class DAOReserva
    {




        string _CadenaConexion;

        public string CadenaConexion
        {
            get
            {
                if (_CadenaConexion == null)
                {
                    _CadenaConexion = ConfigurationManager.ConnectionStrings["Conex"].ConnectionString;
                }
                return _CadenaConexion;
            }
            set
            {
                _CadenaConexion = value;
            }
        }

        //Metodos 

        public List<Reserva> Listar()
        {
            List<Reserva> lista = new List<Reserva>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ListarReserva", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null && dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Reserva c = new Reserva(
                        (int)dr["Id"],
                        (string)dr["FechaInicio"],
                        (string)dr["FechaFin"],
                        (string)dr["Estado"],
                        (int)dr["Habitaciones_Categoria"],
                        (int)dr["Habitaciones_IdHabitaciones"],
                        (int)dr["Usuario_idUsuario"],
                        (int)dr["Servicios_idServicios"],// Convert.ToString()
                        (int)dr["Huspedes_idHuesped"],
                        (string)dr["Clientes_NoDocumento"]
                        );
                        lista.Add(c);
                    }
                }
            }
            return lista;
        }

        
        public Reserva TraerPorId(int Id)
        {
            Reserva Reserva = new Reserva();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("TraerReservaPorId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", Id);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null && dr.HasRows)
                {
                    dr.Read();
                    Reserva = new Reserva(
                        (int)dr["Id"],
                        (string)dr["FechaInicio"],
                        (string)dr["FechaFin"],
                        (string)dr["Estado"],
                        (int)dr["Habitaciones_Categoria"],
                        (int)dr["Habitaciones_IdHabitaciones"],
                        (int)dr["Usuario_idUsuario"],
                        (int)dr["Servicios_idServicios"],
                        (int)dr["Huspedes_idHuesped"],
                        (string)dr["Clientes_NoDocumento"]

                     );
                }
            }

            return Reserva;
        }
        

        public int Insertar(Reserva Reserva)
        {
            int n = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("InsertarReserva", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FechaInicio", Reserva.FechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", Reserva.FechaFin);
                cmd.Parameters.AddWithValue("@Estado", Reserva.Estado);
                cmd.Parameters.AddWithValue("@Habitaciones_Categoria", Reserva.Habitaciones_Categoria);
                cmd.Parameters.AddWithValue("@Habitaciones_IdHabitaciones", Reserva.Habitaciones_IdHabitaciones);
                cmd.Parameters.AddWithValue("@Usuario_idUsuario", Reserva.Usuario_idUsuario);
                cmd.Parameters.AddWithValue("@Servicios_idServicios", Reserva.Servicios_idServicios);
                cmd.Parameters.AddWithValue("@Huespedes_idHuespedes", Reserva.Huspedes_idHuesped);
                cmd.Parameters.AddWithValue("@Clientes_NoDocumento", Reserva.Clientes_NoDocumento);

                n = cmd.ExecuteNonQuery();
            }
            return n;
        }

        public int Actualizar(Reserva Reserva)
        {
            int n = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ActualizarReserva", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Reserva.Id);
                cmd.Parameters.AddWithValue("@FECHAINICIO", Reserva.FechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", Reserva.FechaFin);
                cmd.Parameters.AddWithValue("@Estado", Reserva.Estado);
                cmd.Parameters.AddWithValue("@Habitaciones_Categoria", Reserva.Habitaciones_Categoria);
                cmd.Parameters.AddWithValue("@Habitaciones_IdHabitaciones", Reserva.Habitaciones_IdHabitaciones);
                cmd.Parameters.AddWithValue("@Usuario_idUsuario", Reserva.Usuario_idUsuario);
                cmd.Parameters.AddWithValue("@Servicios_idServicios", Reserva.Servicios_idServicios);
                cmd.Parameters.AddWithValue("@Huspedes_idHuesped", Reserva.Huspedes_idHuesped);
                cmd.Parameters.AddWithValue("@Clientes_NoDocumento", Reserva.Clientes_NoDocumento);

                n = cmd.ExecuteNonQuery();
            }
            return n;
        }
        public int Eliminar(int Id)
        {
            int n = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EliminarReserva", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                n = cmd.ExecuteNonQuery();
            }
            return n;
        }






    }
}
