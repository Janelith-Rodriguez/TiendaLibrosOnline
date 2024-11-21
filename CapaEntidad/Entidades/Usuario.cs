using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Datos
{
    public class Usuario
    {
        #region Atributos

        private int idUsuario;
        private string nombre;
        private string correoElectronico;
        private string direccionEnvio;

        #endregion

        #region Constructores

        public Usuario()
        { }

        public Usuario(int IdUsuario, string Nombre, string CorreoElectronico, string DireccionEnvio)
        {
            this.idUsuario = IdUsuario;
            this.nombre = Nombre;
            this.correoElectronico = CorreoElectronico;
            this.direccionEnvio = DireccionEnvio;
        }

        public Usuario(string Nombre, string CorreoElectronico, string DireccionEnvio)
        {
            this.nombre = Nombre;
            this.correoElectronico = CorreoElectronico;
            this.direccionEnvio = DireccionEnvio;
        }

        #endregion

        #region Métodos

        public void Cargar()
        {
            // Método para cargar datos adicionales si es necesario
        }

        #endregion

        #region Propiedades

        public int IdUsuario { get { return idUsuario; } set { idUsuario = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public string CorreoElectronico { get { return correoElectronico; } set { correoElectronico = value; } }
        public string DireccionEnvio { get { return direccionEnvio; } set { direccionEnvio = value; } }

        #endregion
    }
}
