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
    public class DAOHuespedes
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

        public List<Huespe> Listar()
        {
            List<Huespe> lista = new List<Huespe>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ListarHuesped", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null && dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Huespe c = new Huespe( 
                        (int)dr["Id"],
                        (string)dr["Nombre"],
                        (string)dr["PrimerApellido"],
                        (string)dr["SegundoApellido"],
                        (string)dr["NoDocumento"],
                        (string)dr["TelefonoFijo"],
                        (string)dr["Celular"],
                        (string)dr["Correo"],
                        (string)dr["FechaNacimiento"]// Convert.ToString()

                        );
                        lista.Add(c);
                    }
                }
            }
            return lista;
        }

        public Huespe TraerPorId(int Id)
        {
            Huespe Huespe = new Huespe();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("TraerCHuespedPorId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", Id);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null && dr.HasRows)
                {
                    dr.Read();
                    Huespe = new Huespe(
                        (int)dr["Id"],
                        (string)dr["Nombre"],
                        (string)dr["PrimerApellido"],
                        (string)dr["SegundoApellido"],
                        (string)dr["NoDocumento"],
                        (string)dr["TelefonoFijo"],
                        (string)dr["Celular"],
                        (string)dr["Correo"],
                        (string)dr["FechaNacimiento"]
                     );
                }
            }

            return Huespe;
        }

        public int Insertar(Huespe Huespe)
        {
            int n = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                con.Open(); 
                SqlCommand cmd = new SqlCommand("InsertarHuesped", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", Huespe.Nombre);
                cmd.Parameters.AddWithValue("@PrimerApellido", Huespe.PrimerApellido);
                cmd.Parameters.AddWithValue("@SegundoApellido", Huespe.SegundoApellido);
                cmd.Parameters.AddWithValue("@NoDocumento", Huespe.Celular);
                cmd.Parameters.AddWithValue("@TelefonoFijo", Huespe.TelefonoFijo);
                cmd.Parameters.AddWithValue("@Celular", Huespe.Celular);
                cmd.Parameters.AddWithValue("@Correo", Huespe.Correo);
                cmd.Parameters.AddWithValue("@FechaNacimiento", Huespe.FechaNacimiento);

                n = cmd.ExecuteNonQuery();
            }
            return n;
        }

        public int Actualizar(Huespe Huespe)
        {
            int n = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ActualizarHuesped", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Huespe.Id);
                cmd.Parameters.AddWithValue("@Nombre", Huespe.Nombre);
                cmd.Parameters.AddWithValue("@PrimerApellido", Huespe.PrimerApellido);
                cmd.Parameters.AddWithValue("@SegundoApellido", Huespe.SegundoApellido);
                cmd.Parameters.AddWithValue("@NoDocumento", Huespe.NoDocumento);
                cmd.Parameters.AddWithValue("@TelefonoFijo", Huespe.TelefonoFijo);
                cmd.Parameters.AddWithValue("@Celular", Huespe.Celular);
                cmd.Parameters.AddWithValue("@Correo", Huespe.Correo);
                cmd.Parameters.AddWithValue("@FechaNacimiento", Huespe.FechaNacimiento);

                n = cmd.ExecuteNonQuery();
            }
            return n;
        }
        public int Eliminar(string Id)
        {
            int n = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EliminarHuesped", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                n = cmd.ExecuteNonQuery();
            }
            return n;
        }





    }
}
