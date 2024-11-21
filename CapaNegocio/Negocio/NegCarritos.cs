using CapaDatos.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Negocio
{
    public class NegCarritos
    {
        AdministrarLibros datosObjLibros = new AdministrarLibros();

        public int abmLibros(string accion, Libro objLibro)
        {
            return datosObjLibros.abmLibros(accion, objLibro);
        }

        public DataSet listadoLibros(string cual)
        {
            return datosObjLibros.listadoLibros(cual);
        }

        public List<Libro> ObtenerLibros()
        {
            // Si es necesario, puedes implementar lógica adicional aquí.
            DataSet ds = datosObjLibros.listadoLibros("Todos");
            List<Libro> libros = new List<Libro>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                libros.Add(new Libro
                {
                    IdLibro = (int)row["ID_Libro"],
                    Titulo = row["Titulo"].ToString(),
                    Autor = row["Autor"].ToString(),
                    Genero = row["Genero"].ToString(),
                    Precio = (decimal)row["Precio"],
                    CantidadStock = (int)row["Cantidad_Stock"]
                });
            }

            return libros;
        }
    }
}
