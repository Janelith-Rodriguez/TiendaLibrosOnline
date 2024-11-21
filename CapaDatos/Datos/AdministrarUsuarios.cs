using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Datos
{
    public class AdministrarUsuarios : DatosConexion
    {
        public int abmUsuarios(string accion, Usuario objUsuario)
        {
            int resultado = -1;
            string orden = string.Empty;

            if (accion == "Alta")
            {
                orden = $"insert into Usuario (Nombre, Correo_Electronico, Direccion_Envio) " +
                        $"values ('{objUsuario.Nombre}', '{objUsuario.CorreoElectronico}', '{objUsuario.DireccionEnvio}');";
            }

            if (accion == "Modificar")
            {
                orden = $"update Usuario set Nombre='{objUsuario.Nombre}', Correo_Electronico='{objUsuario.CorreoElectronico}', " +
                        $"Direccion_Envio='{objUsuario.DireccionEnvio}' WHERE ID_Usuario={objUsuario.IdUsuario};";
            }

            if (accion == "Borrar")
            {
                orden = $"delete from Usuario where ID_Usuario={objUsuario.IdUsuario};";
            }

            OleDbCommand cmd = new OleDbCommand(orden, (OleDbConnection)conexion);
            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception($"Error en la acción {accion} para Usuario", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }

            return resultado;
        }

        public DataSet listadoUsuarios(string cual)
        {
            string orden = string.Empty;
            if (cual != "Todos")
                orden = $"select * from Usuario where ID_Usuario={int.Parse(cual)};";
            else
                orden = "select * from Usuario;";

            OleDbCommand cmd = new OleDbCommand(orden, (OleDbConnection)conexion);
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter();

            try
            {
                Abrirconexion();
                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            catch (Exception e)
            {
                throw new Exception("Error al listar Usuarios", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }

            return ds;
        }
    }
}
