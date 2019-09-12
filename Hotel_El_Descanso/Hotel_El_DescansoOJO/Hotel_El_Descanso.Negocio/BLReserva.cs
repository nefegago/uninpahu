using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_El_Descanso.Entidades;
using Hotel_El_Descanso.Datos;

namespace Hotel_El_Descanso.Negocio
{
    public class BLReserva
    {


        public List<Reserva> Listar()
        {
            DAOReserva daUsuario = new DAOReserva();
            return daUsuario.Listar();
        }
        
        public Reserva TraerPorId(int Id)
        {
            DAOReserva daUsuario = new DAOReserva();
           return daUsuario.TraerPorId(Id);
        }
        
        public int Insertar(Reserva Reserva)
        {
            DAOReserva daUsuario = new DAOReserva();
            return daUsuario.Insertar(Reserva);
        }
        public int Actualizar(Reserva Reserva)
        {
            DAOReserva daUsuario = new DAOReserva();
            return daUsuario.Actualizar(Reserva);
        }
        public int Eliminar(int Id)
        {
            DAOReserva daUsuario = new DAOReserva();
            return daUsuario.Eliminar(Id);
        }


    }
}
