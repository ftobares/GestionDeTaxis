using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDeFlotasDesktop
{
    class Roles
    {
        public int iId_Rol;
        public int iId_Usuario;
        public int iId_Funcionalidad;
        public string sNombre;
        public string sDescripcion;

        public Roles(int _iId_Rol, int _iId_Usuario, int _iId_Funcionalidad, string _sNombre, string _sDescripcion)
        {
            iId_Rol = _iId_Rol;
            iId_Usuario = _iId_Usuario;
            iId_Funcionalidad = _iId_Funcionalidad;
            sNombre = _sNombre;
            sDescripcion = _sDescripcion;
        }
    }
}
