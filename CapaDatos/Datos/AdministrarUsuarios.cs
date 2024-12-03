using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

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

            SqlCommand cmd = new SqlCommand(orden,conexion);
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

            SqlCommand cmd = new SqlCommand(orden,conexion);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            try
            {
                Abrirconexion();
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
