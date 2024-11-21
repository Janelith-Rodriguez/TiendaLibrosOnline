using CapaDatos.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Negocio
{
    public class NegUsuarios
    {
        AdministrarUsuarios datosObjUsuarios = new AdministrarUsuarios();

        public int abmUsuarios(string accion, Usuario objUsuario)
        {
            return datosObjUsuarios.abmUsuarios(accion, objUsuario);
        }

        public DataSet listadoUsuarios(string cual)
        {
            return datosObjUsuarios.listadoUsuarios(cual);
        }

        public List<Usuario> ObtenerUsuarios()
        {
            // Si es necesario, puedes implementar lógica adicional aquí.
            DataSet ds = datosObjUsuarios.listadoUsuarios("Todos");
            List<Usuario> usuarios = new List<Usuario>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                usuarios.Add(new Usuario
                {
                    IdUsuario = (int)row["ID_Usuario"],
                    Nombre = row["Nombre"].ToString(),
                    CorreoElectronico = row["Correo_Electronico"].ToString(),
                    DireccionEnvio = row["Direccion_Envio"].ToString()
                });
            }

            return usuarios;
        }
    }
}
