using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.MiniBar.Datos;
using Hotel.MiniBar.Entidades;



namespace Hotel.MiniBar.Negocio
{
   public class BLMiniBar
    {
                public List<MiniBarE> Listar()
        {
            DaoMiniBar daMiniBar = new DaoMiniBar();
            return daMiniBar.Listar();
        }
        public MiniBarE TraerPorId(int Id)
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
