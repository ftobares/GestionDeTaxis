using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDeFlotasDesktop
{
    class Rol
    {
        public string sRolID;
        public string sDescripcion;
        public char cAnulado;

        public Rol(string _sRolID, string _sDescripcion, char _cAnulado)
        {
            sRolID = _sRolID;
            sDescripcion = _sDescripcion;
            cAnulado = _cAnulado;
        }
    }
}
