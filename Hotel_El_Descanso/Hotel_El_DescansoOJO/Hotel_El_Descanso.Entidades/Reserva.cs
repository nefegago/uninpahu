using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_El_Descanso.Entidades
{
    public class Reserva
    {


        int _id;
        string _fechaInicio;
        string _fechaFin;
        string _estado;
        int _habitaciones_Categoria;
        int _habitaciones_IdHabitaciones;
        int _usuario_idUsuario;
        int _servicios_idServicios;
        int _huspedes_idHuesped;
        string _clientes_NoDocumento;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string FechaFin
        {
            get { return _fechaFin; }
            set { _fechaFin = value; }
        }
        public string FechaInicio
        {
            get { return _fechaInicio; }
            set { _fechaInicio = value; }
        }
        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
        public int Habitaciones_Categoria
        {
            get { return _habitaciones_Categoria; }
            set { _habitaciones_Categoria = value; }
        }
        public int Habitaciones_IdHabitaciones
        {
            get { return _habitaciones_IdHabitaciones; }
            set { _habitaciones_IdHabitaciones = value; }
        }


        public int Usuario_idUsuario
        {
            get { return _usuario_idUsuario; }
            set { _usuario_idUsuario = value; }
        }

        public int Huspedes_idHuesped
        {
            get { return _huspedes_idHuesped; }
            set { _huspedes_idHuesped = value; }
        }

        public int Servicios_idServicios
        {
            get { return _servicios_idServicios; }
            set { _servicios_idServicios = value; }
        }

        public string Clientes_NoDocumento
        {
            get { return _clientes_NoDocumento; }
            set { _clientes_NoDocumento = value; }
        }


        public Reserva(int Id, string FechaInicio, string FechaFin, string Estado, int Habitaciones_Categoria, int Habitaciones_IdHabitaciones, int Usuario_idUsuario, int Servicios_idServicios, int Huspedes_idHuesped, string Clientes_NoDocumento)
        {
            this._id = Id;
            this._fechaInicio = FechaInicio;
            this._fechaFin = FechaFin;
            this._estado = Estado;
            this._habitaciones_Categoria = Habitaciones_Categoria;
            this._habitaciones_IdHabitaciones = Habitaciones_IdHabitaciones;
            this._usuario_idUsuario = Usuario_idUsuario;
            this._servicios_idServicios = Servicios_idServicios;
            this._huspedes_idHuesped = Huspedes_idHuesped;
            this._clientes_NoDocumento = Clientes_NoDocumento;
        }




     //   public ClientesHotel(string Id, string PrimerApellido, string Nombre, string SegundoApellido, string TelefonoFijo, string Perfil, string FechaNacimiento, string NoTarjetaCredito) : this(Id, PrimerApellido, Nombre, SegundoApellido, TelefonoFijo, Perfil, FechaNacimiento, NoTarjetaCredito, "")
 

        //public Reserva(int Id,
        //    string FechaInicio,
        //    //string FechaFin,
        //    string Estado,
        //    int Habitaciones_Categoria,
        //    int Habitaciones_IdHabitaciones,
        //    string Clientes_NoDocumento,
        //    int Huspedes_idHuesped) : this(
        //        Id,
        //        FechaInicio,
        //      //  FechaFin,
        //        Estado,
        //        Habitaciones_Categoria,
        //        Habitaciones_IdHabitaciones, 
        //        Clientes_NoDocumento, 
        //        Huspedes_idHuesped)
        //{

        //}

   /*
        public Reserva(int Id, string FechaInicio, string FechaFin, string Estado, int Habitaciones_Categoria, int Usuario_idUsuario, int Huspedes_idHuesped) 
        : this(Id, FechaInicio, FechaFin, Estado, Habitaciones_Categoria, Usuario_idUsuario,0)
  {

  }
    */    

public Reserva() : this(0, "", "", "", 0, 0,0,0,0,"") {

}


      



    }
}
