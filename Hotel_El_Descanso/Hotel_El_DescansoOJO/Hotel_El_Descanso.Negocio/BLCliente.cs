using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_El_Descanso.Entidades;
using Hotel_El_Descanso.Datos;

namespace Hotel_El_Descanso.Negocio
{
    public class BLCliente
    {

        public List<ClientesHotel> Listar()
        {
            DAOClientes daUsuario = new DAOClientes();
            return daUsuario.Listar();
        }

        public ClientesHotel TraerPorId(string Id)
        {
            DAOClientes daUsuario = new DAOClientes();
            return daUsuario.TraerPorId(Id);
        }
        public int Insertar(ClientesHotel ClientesHotel)
        {
            DAOClientes daUsuario = new DAOClientes();
            return daUsuario.Insertar(ClientesHotel);
        }
        public int Actualizar(ClientesHotel ClientesHotel)
        {
            DAOClientes daUsuario = new DAOClientes();
            return daUsuario.Actualizar(ClientesHotel);
        }  
        public int Eliminar(string Id)
        {
            DAOClientes daUsuario = new DAOClientes();
            return daUsuario.Eliminar(Id);
        }

    }
}
