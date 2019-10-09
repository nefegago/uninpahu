using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_El_Descanso.Entidades

{  
    public class MiniBar   
    {

        int _id;
        string _codigo;
        string _nombre;
        int _cantidad;
        float  _precio;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        public float Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }
        

        public MiniBar(int Id, string Codigo, string Nombre, int Cantidad, float Precio)
        {
            this._id = Id;
            this._codigo = Codigo;
            this._nombre = Nombre;
            this._cantidad = Cantidad;
            this._precio = Precio;
        }

        public MiniBar(int Id, string Codigo, string Nombre,int Cantidad) : this(Id, Codigo, Nombre, Cantidad, 0)
        {

        }

        public MiniBar(int Id, string Nombre ) : this(Id, "", Nombre, 0)
        {

        }

        public MiniBar() : this(0, "", "", 0)
        {

        }






    }
}
