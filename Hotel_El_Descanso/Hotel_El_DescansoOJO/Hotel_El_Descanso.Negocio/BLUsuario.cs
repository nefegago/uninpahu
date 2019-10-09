using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hotel_El_Descanso.Entidades;
using Hotel_El_Descanso.Datos;

namespace Hotel_El_Descanso.Negocio
{  
    public class BLUsuario
    {
        
        public List<UsuariosHotel> Listar()
        {
            DAOUsuario daUsuario = new DAOUsuario();
            return daUsuario.Listar();
        }

        public UsuariosHotel TraerPorId(int Id)
        {
            DAOUsuario daUsuario = new DAOUsuario();
            return daUsuario.TraerPorId(Id);
        }
        public int Insertar(UsuariosHotel UsuariosHotel)
        {
            DAOUsuario daUsuario = new DAOUsuario();
            return daUsuario.Insertar(UsuariosHotel);
        }
        public int Actualizar(UsuariosHotel UsuariosHotel)
        {
            DAOUsuario daUsuario = new DAOUsuario();
            return daUsuario.Actualizar(UsuariosHotel);
        }
        public int Eliminar(int Id)
        {
            DAOUsuario daUsuario = new DAOUsuario();
            return daUsuario.Eliminar(Id);
        }



    }
}
