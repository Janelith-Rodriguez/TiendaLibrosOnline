using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Datos
{
    public class Carrito
    {
        #region Atributos

        private int idCarrito;
        private int idUsuario;
        private int idLibro;
        private int cantidad;

        #endregion

        #region Constructores

        public Carrito()
        { }

        public Carrito(int IdCarrito, int IdUsuario, int IdLibro, int Cantidad)
        {
            this.idCarrito = IdCarrito;
            this.idUsuario = IdUsuario;
            this.idLibro = IdLibro;
            this.cantidad = Cantidad;
        }

        public Carrito(int IdUsuario, int IdLibro, int Cantidad)
        {
            this.idUsuario = IdUsuario;
            this.idLibro = IdLibro;
            this.cantidad = Cantidad;
        }

        #endregion

        #region Métodos

        public void Cargar()
        {
            // Método para cargar datos adicionales si es necesario
        }

        #endregion

        #region Propiedades

        public int IdCarrito { get { return idCarrito; } set { idCarrito = value; } }
        public int IdUsuario { get { return idUsuario; } set { idUsuario = value; } }
        public int IdLibro { get { return idLibro; } set { idLibro = value; } }
        public int Cantidad { get { return cantidad; } set { cantidad = value; } }

        #endregion
    }
}
