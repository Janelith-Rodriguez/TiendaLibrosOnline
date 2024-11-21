using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Datos
{
    public class AdministrarLibros : DatosConexion
    {
        public int abmLibros(string accion, Libro objLibro)
        {
            int resultado = -1;
            string orden = string.Empty;

            if (accion == "Alta")
            {
                orden = $"insert into Libro (Titulo, Autor, Genero, Precio, Cantidad_Stock) " +
                        $"values ('{objLibro.Titulo}', '{objLibro.Autor}', '{objLibro.Genero}', {objLibro.Precio}, {objLibro.CantidadStock});";
            }

            if (accion == "Modificar")
            {
                orden = $"update Libro set Titulo='{objLibro.Titulo}', Autor='{objLibro.Autor}', Genero='{objLibro.Genero}', " +
                        $"Precio={objLibro.Precio}, Cantidad_Stock={objLibro.CantidadStock} WHERE ID_Libro={objLibro.IdLibro};";
            }

            if (accion == "Borrar")
            {
                orden = $"delete from Libro where ID_Libro={objLibro.IdLibro};";
            }

            OleDbCommand cmd = new OleDbCommand(orden, (OleDbConnection)conexion);
            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception($"Error en la acción {accion} para Libro", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }

            return resultado;
        }

        public DataSet listadoLibros(string cual)
        {
            string orden = string.Empty;
            if (cual != "Todos")
                orden = $"select * from Libro where ID_Libro={int.Parse(cual)};";
            else
                orden = "select * from Libro;";

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
                throw new Exception("Error al listar Libros", e);
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
