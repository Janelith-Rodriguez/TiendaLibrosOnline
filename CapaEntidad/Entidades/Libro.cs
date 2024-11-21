using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Datos  
{
    public class Libro
    {
        #region Atributos

        private int idLibro;
        private string titulo;
        private string autor;
        private string genero;
        private decimal precio;
        private int cantidadStock;

        #endregion

        #region Constructores

        public Libro()
        { }

        public Libro(int IdLibro, string Titulo, string Autor, string Genero, decimal Precio, int CantidadStock)
        {
            this.idLibro = IdLibro;
            this.titulo = Titulo;
            this.autor = Autor;
            this.genero = Genero;
            this.precio = Precio;
            this.cantidadStock = CantidadStock;
        }

        #endregion

        #region Métodos

        public void Cargar()
        {
            // Método para cargar datos adicionales si es necesario
        }

        #endregion

        #region Propiedades

        public int IdLibro { get { return idLibro; } set { idLibro = value; } }
        public string Titulo { get { return titulo; } set { titulo = value; } }
        public string Autor { get { return autor; } set { autor = value; } }
        public string Genero { get { return genero; } set { genero = value; } }
        public decimal Precio { get { return precio; } set { precio = value; } }
        public int CantidadStock { get { return cantidadStock; } set { cantidadStock = value; } }

        #endregion
    }
}
