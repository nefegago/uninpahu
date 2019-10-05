using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Entidades.Habitaciones;
using Hotel.Habitaciones.Datos;


namespace Hotel.Negocio.Habitaciones
{
    public class BlHabitacion
    {


        public List<Habitacion> Listar()
        {
            DAOHabitaciones daHabitaciones = new DAOHabitaciones();
            return daHabitaciones.Listar();
        }

        public Habitacion TraerPorId(int Id)
        {
            DAOHabitaciones daHabitaciones = new DAOHabitaciones();
            return daHabitaciones.TraerPorId(Id);
        }
        public int Insertar(Habitacion Habitacion)
        {
            DAOHabitaciones daHabitaciones = new DAOHabitaciones();
            return daHabitaciones.Insertar(Habitacion);
        }
        public int Actualizar(Habitacion Habitacion)
        {
            DAOHabitaciones daHabitaciones = new DAOHabitaciones();
            return daHabitaciones.Actualizar(Habitacion);
        }
        public int Eliminar(int Id)
        {
            DAOHabitaciones daHabitaciones = new DAOHabitaciones();
            return daHabitaciones.Eliminar(Id);
        }




    }
}
