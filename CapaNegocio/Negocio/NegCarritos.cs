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
        AdministrarCarritos datosObjCarritos = new AdministrarCarritos();

        public int abmCarritos(string accion, Carrito objCarrito)
        {
            return datosObjCarritos.abmCarritos(accion, objCarrito);
        }

        public DataSet listadoCarritos(string cual)
        {
            return datosObjCarritos.listadoCarritos(cual);
        }

        public List<Carrito> ObtenerCarritos()
        {
            // Si es necesario, puedes implementar lógica adicional aquí.
            DataSet ds = datosObjCarritos.listadoCarritos("Todos");
            List<Carrito> carritos = new List<Carrito>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                carritos.Add(new Carrito
                {
                    IdCarrito = (int)row["ID_Carrito"],
                    IdUsuario = (int)row["ID_Usuario"],
                    IdLibro = (int)row["ID_Libro"],
                    Cantidad = (int)row["Cantidad"]
                });
            }

            return carritos;
        }
    }
}
