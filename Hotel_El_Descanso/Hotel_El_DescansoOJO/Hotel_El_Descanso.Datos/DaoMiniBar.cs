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
    public class DaoMiniBar
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

        public List<MiniBar> Listar()
        {
            List<MiniBar> lista = new List<MiniBar>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ListarMiniBar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null && dr.HasRows)
                {
                    while (dr.Read())
                    {
                        MiniBar c = new MiniBar((int)dr["Id"],
                        (string)dr["Codigo"],
                        (string)dr["Nombre"],
                        (int)dr["Cantidad"]
                       // (float)dr["Precio"]
                        );
                        
                        lista.Add(c);
                    }
                }
            }
            return lista;
        }        public MiniBar TraerPorId(int Id)
        {
            MiniBar MiniBarE = new MiniBar();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("TraerMiniBar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", Id);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null && dr.HasRows)
                { 
                    dr.Read();
                    MiniBarE = new MiniBar((int)dr["Id"],
                        (string)dr["Codigo"],
                        (string)dr["Nombre"],
                        (int)dr["Cantidad"]
                      //  (float)dr["Precio"]

                     );
                }
            }
            return MiniBarE;
        }        public int Insertar(MiniBar MiniBarE)
        {
            int n = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("InsertarMiniBar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo", MiniBarE.Codigo);
                cmd.Parameters.AddWithValue("@Nombre", MiniBarE.Nombre);
                cmd.Parameters.AddWithValue("@Cantidad", MiniBarE.Cantidad);
                cmd.Parameters.AddWithValue("@Precio", MiniBarE.Precio);
                n = cmd.ExecuteNonQuery();
            }
            return n;
        }
        public int Actualizar(MiniBar MiniBarE)
        {
            int n = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ActualizarMiniBar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", MiniBarE.Id);
                cmd.Parameters.AddWithValue("@Codigo", MiniBarE.Codigo);
                cmd.Parameters.AddWithValue("@Nombre", MiniBarE.Nombre);
                cmd.Parameters.AddWithValue("@Cantidad", MiniBarE.Cantidad);
                cmd.Parameters.AddWithValue("@Precio", MiniBarE.Precio);
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
                SqlCommand cmd = new SqlCommand("EliminarMiniBar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                n = cmd.ExecuteNonQuery();
            }
            return n;
        }







    }
}
