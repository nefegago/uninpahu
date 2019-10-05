using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Entidades.Habitaciones
{
    public class Habitacion
    {

        // Atributos de la clase Categoria
        int _id;
        string _codigo;
        decimal _precio;
        string _estado;
        int _categoria_IdCategoria;

        // Se definen los metodos get y set
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
        public decimal Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }
        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public int Categoria_IdCategoria
        {
            get { return _categoria_IdCategoria; }
            set { _categoria_IdCategoria = value; }
        }

        public Habitacion(int Id, string Codigo, decimal Precio, string Estado, int Categoria_IdCategoria)
        {
            this._id = Id;
            this._codigo = Codigo;
            this._precio = Precio;
            this._estado = Estado;
            this._categoria_IdCategoria = Categoria_IdCategoria;
        }
        public Habitacion(int Id, string Codigo, decimal Precio, string Estado) : this(Id,
        Codigo, Precio, "", 0)
        {
        }
        public Habitacion(int Id, string Codigo, decimal Precio) : this(Id, Codigo, Precio, "")
        {
        }
        public Habitacion() : this(0, "", 1, "")

        {
        }



    }
}
