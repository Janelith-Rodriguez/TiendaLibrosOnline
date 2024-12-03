using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;

namespace CapaDatos.Datos
{
    public class DatosConexion
    {
        public SqlConnection conexion;
        //protected DbConnection conexion;

        protected string cadenaConexion = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Usuario\TiendaLibrosOnline.mdf;Integrated Security = True; Connect Timeout = 30";
        //protected string cadenaConexion = @"Server=(localdb)\MSSQLLocalDB;Database=TiendaLibrosOnline.Integrated Security=True";
        //protected string cadenaConexion = @"Data Source=(localdb)\MSSQLLocalDB;Database=TiendaLibrosOnline.Integrated Security=True;Connet Timeout=30;Encrypt=False";

        public DatosConexion()
        {
            conexion = new SqlConnection(cadenaConexion);
        }
        public void Abrirconexion()
        {
            try
            {
                if (conexion.State == ConnectionState.Broken || conexion.State ==
                ConnectionState.Closed)
                    conexion.Open();
            }
            catch (Exception e)
            {
                throw new Exception("Error al tratar de abrir la conexión", e);
            }
        }

        public void Cerrarconexion()
        {
            try
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Error al tratar de cerrar la conexión", e);
            }
        }
    }


}
