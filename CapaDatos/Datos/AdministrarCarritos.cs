using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CapaDatos.Datos
{
    public class AdministrarCarritos : DatosConexion
    {
        public int abmCarritos(string accion, Carrito objCarrito)
        {
            int resultado = -1;
            string orden = string.Empty;

            if (accion == "Alta")
            {
                orden = $"insert into Carrito (ID_Usuario, ID_Libro, Cantidad) " +
                        $"values ({objCarrito.IdUsuario}, {objCarrito.IdLibro}, {objCarrito.Cantidad});";
            }

            if (accion == "Modificar")
            {
                orden = $"update Carrito set ID_Usuario={objCarrito.IdUsuario}, ID_Libro={objCarrito.IdLibro}, " +
                        $"Cantidad={objCarrito.Cantidad} WHERE ID_Carrito={objCarrito.IdCarrito};";
            }

            if (accion == "Borrar")
            {
                orden = $"delete from Carrito where ID_Carrito={objCarrito.IdCarrito};";
            }

            SqlCommand cmd = new SqlCommand(orden, conexion);
            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception($"Error en la acción {accion} para Carrito", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }

            return resultado;
        }

        public DataSet listadoCarritos(string cual)
        {
            string orden = string.Empty;
            if (cual != "Todos")
                orden = $"select * from Carrito where ID_Carrito={int.Parse(cual)};";
            else
                orden = "select * from Carrito;";

            SqlCommand cmd = new SqlCommand(orden, conexion);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            try
            {
                Abrirconexion();
                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            catch (Exception e)
            {
                throw new Exception("Error al listar Carritos", e);
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
