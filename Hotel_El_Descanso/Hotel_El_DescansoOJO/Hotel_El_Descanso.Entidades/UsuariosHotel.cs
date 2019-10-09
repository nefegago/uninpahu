using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
       
namespace Hotel_El_Descanso.Entidades
{
     public class UsuariosHotel
    {

            int _id;
            string _identificacion;
            string _nombre;
            string _usuarios;
            string _clave;
            string _perfil;
            string _estado;
            string _correo;

            public int Id
            {
                get { return _id; }
                set { _id = value; }
            }

            public string Identificacion
            {
                get { return _identificacion; }
                set { _identificacion = value; }
            }
            public string Nombre
            {
                get { return _nombre; }
                set { _nombre = value; }
            }
            public string Usuarios
            {
                get { return _usuarios; }
                set { _usuarios = value; }
            }
            public string Clave
            {
                get { return _clave; }
                set { _clave = value; }
            }

            public string Perfil
            {
                get { return _perfil; }
                set { _perfil = value; }
            }

            public string Estado
            {
                get { return _estado; }
                set { _estado = value; }
            }

            public string Correo
            {
                get { return _correo; }
                set { _correo = value; }
            }

            public UsuariosHotel(int Id, string Identificacion, string Nombre, string Usuarios, string Clave, string Perfil, string Estado, string Correo)
            {
                this._id = Id;
                this._identificacion = Identificacion;
                this._nombre = Nombre;
                this._usuarios = Usuarios;
                this._clave = Clave;
                this._perfil = Perfil;
                this._estado = Estado;
                this._correo = Correo;

            }

            public UsuariosHotel(int Id, string Identificacion, string Nombre, string Usuarios, string Clave, string Perfil, string Estado) : this(Id, Identificacion, Nombre, Usuarios, Clave, Perfil, Estado, "")
            {

            }

            public UsuariosHotel(int Id, string Nombre, string Usuarios, string Clave, string Perfil, string Estado) : this(Id, Nombre, Usuarios, Clave, Perfil, "", "")
            {

            }

            public UsuariosHotel() : this(0, "", "", "", "", "", "", "")
            {

            }




        }
}
