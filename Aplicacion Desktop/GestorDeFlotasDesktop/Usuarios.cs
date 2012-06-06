using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDeFlotasDesktop
{
    class Usuarios
    {
        public int iId_Usuario;
        public int iId_Rol;
        public string sUsuario;
        public string sPassword;

        public Usuarios(int _iId_Usuario, int _iId_Rol, string _sUsuario, string _sPassword)
        {
            iId_Usuario = _iId_Usuario;
            iId_Rol = _iId_Rol;
            sUsuario = _sUsuario;
            sPassword = _sPassword;
        }
    }
}
