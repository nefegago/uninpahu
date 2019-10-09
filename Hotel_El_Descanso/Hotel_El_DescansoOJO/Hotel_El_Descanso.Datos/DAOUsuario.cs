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
    public class DAOUsuario
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
        public List<UsuariosHotel> Listar() 
        {
            List<UsuariosHotel> lista = new List<UsuariosHotel>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ListarUsuario", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null && dr.HasRows)
                {
                    while (dr.Read())
                    {
                        UsuariosHotel c = new UsuariosHotel((int)dr["Id"],
                        (string)dr["Identificacion"],
                        (string)dr["Nombre"],
                        (string)dr["Usuarios"], 
                        (string)dr["Clave"],
                        (string)dr["Perfil"],
                        (string)dr["Estado"],
                        (string)dr["Correo"]
                        );
                        lista.Add(c);
                    }
                }
            }
            return lista;
        }

        public UsuariosHotel TraerPorId(int Id)
        {
            UsuariosHotel Usuario = new UsuariosHotel();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("TraerUsuarioPorId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", Id);
                SqlDataReader dr = cmd.ExecuteReader(); 
                if (dr != null && dr.HasRows)
                {
                    dr.Read();
                    Usuario = new UsuariosHotel((int)dr["Id"],
                     (string)dr["Identificacion"], (string)dr["Nombre"],
                     (string)dr["Usuarios"], (string)dr["Clave"],
                     (string)dr["Perfil"], (string)dr["Estado"],
                        (string)dr["Correo"]
                     );
                }
            }

            return Usuario;
        }

        public int Insertar(UsuariosHotel Usuario)
        {
            int n = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("InsertarUsuario", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Identificacion", Usuario.Identificacion);
                cmd.Parameters.AddWithValue("@Nombre", Usuario.Nombre);
                cmd.Parameters.AddWithValue("@Usuarios", Usuario.Usuarios);
                cmd.Parameters.AddWithValue("@Clave", Usuario.Clave);
                cmd.Parameters.AddWithValue("@Perfil", Usuario.Perfil);
                cmd.Parameters.AddWithValue("@Estado", Usuario.Estado);
                cmd.Parameters.AddWithValue("@Correo", Usuario.Correo);
                n = cmd.ExecuteNonQuery();
            }
            return n;
        }

        public int Actualizar(UsuariosHotel Usuario)
        {
            int n = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ActualizarUsuario", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Usuario.Id);
                cmd.Parameters.AddWithValue("@Identificacion", Usuario.Identificacion);
                cmd.Parameters.AddWithValue("@Nombre", Usuario.Nombre);
                cmd.Parameters.AddWithValue("@Usuarios", Usuario.Usuarios);
                cmd.Parameters.AddWithValue("@Clave", Usuario.Clave);
                cmd.Parameters.AddWithValue("@Perfil", Usuario.Perfil);
                cmd.Parameters.AddWithValue("@Estado", Usuario.Estado);
                cmd.Parameters.AddWithValue("@Correo", Usuario.Correo);
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
                SqlCommand cmd = new SqlCommand("EliminarUsuario", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                n = cmd.ExecuteNonQuery();
            }
            return n;
        }














    }
}
