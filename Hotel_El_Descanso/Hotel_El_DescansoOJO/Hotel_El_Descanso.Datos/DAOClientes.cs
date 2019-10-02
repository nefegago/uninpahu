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
    public class DAOClientes
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

        public List<ClientesHotel> Listar()
        {
            List<ClientesHotel> lista = new List<ClientesHotel>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ListarClientes", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null && dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ClientesHotel c = new ClientesHotel((string)dr["Id"],
                        (string)dr["Nombre"],
                        (string)dr["PrimerApellido"],
                        (string)dr["SegundoApellido"],
                        (string)dr["TelefonoFijo"],
                        (string)dr["Celular"],
                        (string)dr["Correo"],
                        (string)dr["FechaNacimiento"],// Convert.ToString()
                        (string)dr["NoTarjetaCredito"]
                        );
                        lista.Add(c);
                    }
                }
            }
            return lista;
        }

        public ClientesHotel TraerPorId(string Id)
        {
            ClientesHotel Cliente = new ClientesHotel();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("TraerClientesPorId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", Id);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null && dr.HasRows)
                {
                    dr.Read();
                    Cliente = new ClientesHotel((string)dr["Id"],
                        (string)dr["Nombre"],
                        (string)dr["PrimerApellido"],
                        (string)dr["SegundoApellido"],
                        (string)dr["TelefonoFijo"],
                        (string)dr["Celular"],
                        (string)dr["Correo"],
                        (string)dr["FechaNacimiento"],// Convert.ToString()
                        (string)dr["NoTarjetaCredito"]


                     );
                }
            }

            return Cliente;
        }

        public int Insertar(ClientesHotel Cliente)
        {
            int n = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("InsertarClientes", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NoDocumento", Cliente.Celular);
                cmd.Parameters.AddWithValue("@Nombre", Cliente.Nombre);
                cmd.Parameters.AddWithValue("@PrimerApellido", Cliente.PrimerApellido);
                cmd.Parameters.AddWithValue("@SegundoApellido", Cliente.SegundoApellido);
                cmd.Parameters.AddWithValue("@TelefonoFijo", Cliente.TelefonoFijo);
                cmd.Parameters.AddWithValue("@Celular", Cliente.Celular);
                cmd.Parameters.AddWithValue("@Correo", Cliente.Correo);
                cmd.Parameters.AddWithValue("@FechaNacimiento", Cliente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@NoTarjetaCredito", Cliente.NoTarjetaCredito);
                n = cmd.ExecuteNonQuery();    
            }
            return n;
        }

        public int Actualizar(ClientesHotel Cliente)
        {
            int n = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ActualizarClientes", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Cliente.Id);
                cmd.Parameters.AddWithValue("@Nombre", Cliente.Nombre);
                cmd.Parameters.AddWithValue("@PrimerApellido", Cliente.PrimerApellido);
                cmd.Parameters.AddWithValue("@SegundoApellido", Cliente.SegundoApellido);
                cmd.Parameters.AddWithValue("@TelefonoFijo", Cliente.TelefonoFijo);
                cmd.Parameters.AddWithValue("@Celular", Cliente.Celular);
                cmd.Parameters.AddWithValue("@Correo", Cliente.Correo);
                cmd.Parameters.AddWithValue("@FechaNacimiento", Cliente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@NoTarjetaCredito", Cliente.NoTarjetaCredito);
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
                SqlCommand cmd = new SqlCommand("EliminarClientes", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                n = cmd.ExecuteNonQuery();
            }
            return n;
        }



    }
}
