using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public enum PermissionsEnum
    {
        //para cada uno debe existir un registro en BD
        PuedeHacerD,
        PuedeHacerE,
        PuedeHacerF,
        PuedeHacerG,
        //Las que necesito ahora
        Default,
        Patentes,
        MenuConfig,
        PatentesFamilias,
        PatentesUsuarios,
        Usuarios,
        //Especificas
        Todo,
        AprobarMaquina,
        Presupuestar,
        Reparar,
        IngresarMaquina,
        ModificarIdiomas,
        CrearUsuario,
        Asignacion
    }
}
