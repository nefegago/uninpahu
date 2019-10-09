using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

using Hotel_El_Descanso.Entidades;

namespace Hotel_El_Descanso.Datos
{
    public class DAOHabitaciones
    {


        string _cadenaConexion;
        public string CadenaConexion
        {
            get
            {
                if (_cadenaConexion == null)
                {
                    _cadenaConexion = ConfigurationManager.
                    ConnectionStrings["Conex"].ConnectionString;
                }
                return _cadenaConexion;
            }
            set { _cadenaConexion = value; }
        }


        public List<Habitacion> Listar()
        {
            List<Habitacion> lista = new List<Habitacion>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ListarHabitaciones", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null && dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Habitacion c = new Habitacion((int)dr["IdHabitaciones"],
                        (string)dr["Codigo"], (decimal)dr["Precio"],
                        (string)dr["Estado"], (int)dr["categoria_IdCategoria"]

                        );
                        lista.Add(c);
                    }
                }
            }
            return lista;
        }
        public Habitacion TraerPorId(int Id)
        {
            Habitacion Habitacion = new Habitacion();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("TraerHabitacionPorId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", Id);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null && dr.HasRows)
                {
                    dr.Read();

                    Habitacion = new Habitacion((int)dr["Id"],

                    (string)dr["Codigo"], (decimal)dr["Precio"],
                    (string)dr["Estado"]
                    );
                }
            }
            return Habitacion;
        }
        public int Insertar(Habitacion Habitaciones)
        {
            int n = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("InsertarHabitaciones", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", Habitaciones.Codigo);
                cmd.Parameters.AddWithValue("@precio", Habitaciones.Precio);
                cmd.Parameters.AddWithValue("@estado", Habitaciones.Estado);
                cmd.Parameters.AddWithValue("@Categoria_IdCategoria", Habitaciones.Categoria_IdCategoria);
                n = cmd.ExecuteNonQuery();
            }
            return n;
        }
        public int Actualizar(Habitacion Habitaciones)
        {
            int n = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ActualizarHabitaciones", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Habitaciones.Id);
                cmd.Parameters.AddWithValue("@CODIGO", Habitaciones.Codigo);
                cmd.Parameters.AddWithValue("@PRECIO", Habitaciones.Precio);
                cmd.Parameters.AddWithValue("@ESTADO", Habitaciones.Estado);
                cmd.Parameters.AddWithValue("@CATEGORIAID", Habitaciones.Categoria_IdCategoria);
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
                SqlCommand cmd = new SqlCommand("EliminarHabitaciones", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                n = cmd.ExecuteNonQuery();
            }
            return n;
        }


    }
}
