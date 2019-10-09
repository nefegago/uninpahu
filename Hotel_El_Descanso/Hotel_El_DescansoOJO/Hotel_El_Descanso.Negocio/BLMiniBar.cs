using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_El_Descanso.Datos;
using Hotel_El_Descanso.Entidades;


namespace Hotel_El_Descanso.Negocio
{
   public class BLMiniBar
    {
       public List<MiniBar> Listar()
        {
            DaoMiniBar daMiniBar = new DaoMiniBar();
            return daMiniBar.Listar();
        }
        public MiniBar TraerPorId(int Id)
        {
            DaoMiniBar daMiniBar = new DaoMiniBar();
            return daMiniBar.TraerPorId(Id);
        }
        public int Insertar(MiniBar MiniBar)
        {
            DaoMiniBar daMiniBar = new DaoMiniBar();
            return daMiniBar.Insertar(MiniBar);
        }
        public int Actualizar(MiniBar MiniBar)
        {
            DaoMiniBar daMiniBar = new DaoMiniBar();
            return daMiniBar.Actualizar(MiniBar);
        }
        public int Eliminar(int Id)
        {
            DaoMiniBar daMiniBar = new DaoMiniBar();
            return daMiniBar.Eliminar(Id);
        }






    }
}
