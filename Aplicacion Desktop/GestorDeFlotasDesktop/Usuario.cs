using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDeFlotasDesktop
{
    class Usuario
    {
        public string sUsuarioID { get; set; }
        public string sNombre { get; set; }
        public string sApellido { get; set; }
        public string sEmail { get; set; }
        public string sPassword { get; set; }
        public int iCantIntentosFallo { get; set; }
        public int iCantMaxiIntentos { get; set; }
        public char cAnulado { get; set; }

        public Usuario()
        {
            return;
        }
        public Usuario(string _sUsuarioID, string _sNombre, string _sApellido, string _sEmail, string _sPassword, int _iCantIntentosFallo, int _iCantMaxiIntentos, char _cAnulado)
        {
            sUsuarioID = _sUsuarioID;
            sNombre = _sNombre;
            sApellido = _sApellido;
            sEmail = _sEmail;
            sPassword = _sPassword;
            iCantIntentosFallo = _iCantIntentosFallo;
            iCantMaxiIntentos = _iCantMaxiIntentos;
            cAnulado = _cAnulado;
        }
    }
}
