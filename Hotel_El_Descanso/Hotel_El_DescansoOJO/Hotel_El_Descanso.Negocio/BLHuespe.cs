using System;    
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_El_Descanso.Entidades;
using Hotel_El_Descanso.Datos;

namespace Hotel_El_Descanso.Negocio
{
    public class BLHuespe
    {


        public List<Huespe> Listar()
        {
            DAOHuespedes daHuesped = new DAOHuespedes();
            return daHuesped.Listar();
        }

        public Huespe TraerPorId(int Id)
        {
            DAOHuespedes daHuesped = new DAOHuespedes();
            return daHuesped.TraerPorId(Id);
        }
        public int Insertar(Huespe Huespe)
        {
            DAOHuespedes daHuesped = new DAOHuespedes();
            return daHuesped.Insertar(Huespe);
        }
        public int Actualizar(Huespe Huespe)
        {
            DAOHuespedes daHuesped = new DAOHuespedes();
            return daHuesped.Actualizar(Huespe);
        }
        public int Eliminar(string Id)
        {
            DAOHuespedes daHuesped = new DAOHuespedes();
            return daHuesped.Eliminar(Id);
        }


    }
}
