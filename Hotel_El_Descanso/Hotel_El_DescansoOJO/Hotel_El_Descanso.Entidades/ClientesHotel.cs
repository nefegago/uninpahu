using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_El_Descanso.Entidades
{
    public class ClientesHotel
    {

        string _id;
        string _nombre;
        string _primerApellido;
        string _segundoApellido;
        string _telefonoFijo;
        string _celular;
        string _correo;
        string _fechaNacimiento;
        string _noTarjetaCredito;

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string PrimerApellido
        {
            get { return _primerApellido; }
            set { _primerApellido = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string SegundoApellido
        {
            get { return _segundoApellido; }
            set { _segundoApellido = value; }
        }
        public string TelefonoFijo
        {
            get { return _telefonoFijo; }
            set { _telefonoFijo = value; }
        }

        public string Celular
        {
            get { return _celular; }
            set { _celular = value; }
        }

        public string FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }

        public string Correo
        {
            get { return _correo; }
            set { _correo = value; }
        }

        public string NoTarjetaCredito
        {
            get { return _noTarjetaCredito; }
            set { _noTarjetaCredito = value; }
        }


        public ClientesHotel(string Id, string PrimerApellido, string Nombre, string SegundoApellido, string TelefonoFijo, string Celular, string Correo, string FechaNacimiento, string NoTarjetaCredito)
        {
            this._id = Id;
            this._primerApellido = PrimerApellido;
            this._nombre = Nombre;
            this._segundoApellido = SegundoApellido;
            this._telefonoFijo = TelefonoFijo;
            this._celular = Celular;
            this._correo = Correo;
            this._fechaNacimiento = FechaNacimiento;
            this._noTarjetaCredito = NoTarjetaCredito;
        }

        public ClientesHotel(string Id, string PrimerApellido, string Nombre, string SegundoApellido, string TelefonoFijo, string Perfil, string FechaNacimiento, string NoTarjetaCredito) : this(Id, PrimerApellido, Nombre, SegundoApellido, TelefonoFijo, Perfil, FechaNacimiento, NoTarjetaCredito, "")
        {

        }

        public ClientesHotel(string Id, string Nombre, string SegundoApellido, string TelefonoFijo, string Celular, string FechaNacimiento, string NoTarjetaCredito) : this(Id, Nombre, SegundoApellido, TelefonoFijo, Celular, NoTarjetaCredito, "", "")
        {

        }

        public ClientesHotel() : this("", "", "", "", "", "", "", "")
        {

        }





    }
}
