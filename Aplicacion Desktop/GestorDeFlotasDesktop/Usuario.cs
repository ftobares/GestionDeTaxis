using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDeFlotasDesktop
{
    class Usuario
    {
        public string sUsuarioID;
        public string sNombre;
        public string sApellido;
        public string sEmail;
        public string sPassword;
        public int iCantIntentosFallo;
        public int iCantMaxiIntentos;
        public char cAnulado;

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
