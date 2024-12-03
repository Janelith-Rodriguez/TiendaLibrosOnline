using CapaDatos.Datos;
using CapaNegocio.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        // Instancias de las clases de negocio
        public NegUsuarios objNegUsuarios = new NegUsuarios();
        public NegLibros objNegLibros = new NegLibros();
        public NegCarritos objNegCarritos = new NegCarritos();
        public Form1()
        {
            InitializeComponent();
           // CrearDGVUsuarios();
           // CrearDGVLibros();
            //LlenarDGVUsuarios();
            //LlenarDGVLibros();
        }
        private void CargarDatos()
        {
            // Cargar datos iniciales en los DataGridView
            CrearDGVUsuarios.DataSource = objNegUsuarios.ObtenerUsuarios();
            CrearDGVLibros.DataSource = objNegLibros.ObtenerLibros();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LlenarDGVUsuarios();
            LlenarDGVLibros();
        }

        

        private void CrearDGVUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CrearDGVUsuarios.Columns.Add("0", "ID");
            CrearDGVUsuarios.Columns.Add("1", "Nombre");
            CrearDGVUsuarios.Columns.Add("2", "Correo Electrónico");
            CrearDGVUsuarios.Columns.Add("3", "Dirección de Envío");

            CrearDGVUsuarios.Columns[0].Width = 50;
            CrearDGVUsuarios.Columns[1].Width = 150;
            CrearDGVUsuarios.Columns[2].Width = 200;
            CrearDGVUsuarios.Columns[3].Width = 250;
        }

        private void CrearDGVLibros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CrearDGVLibros.Columns.Add("0", "ID");
            CrearDGVLibros.Columns.Add("1", "Título");
            CrearDGVLibros.Columns.Add("2", "Autor");
            CrearDGVLibros.Columns.Add("3", "Género");
            CrearDGVLibros.Columns.Add("4", "Precio");
            CrearDGVLibros.Columns.Add("5", "Cantidad en Stock");

            CrearDGVLibros.Columns[0].Width = 50;
            CrearDGVLibros.Columns[1].Width = 150;
            CrearDGVLibros.Columns[2].Width = 150;
            CrearDGVLibros.Columns[3].Width = 100;
            CrearDGVLibros.Columns[4].Width = 80;
            CrearDGVLibros.Columns[5].Width = 80;
        }

        private void LlenarDGVUsuarios()
        {
            CrearDGVUsuarios.Rows.Clear();
            DataSet ds = objNegUsuarios.listadoUsuarios("Todos");

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    CrearDGVUsuarios.Rows.Add(dr["ID_Usuario"], dr["Nombre"], dr["Correo_Electronico"], dr["Direccion_Envio"]);
                }
            }
            else
            {
                MessageBox.Show("No hay usuarios cargados en el sistema.");
            }
        }

        private void LlenarDGVLibros()
        {
            CrearDGVLibros.Rows.Clear();
            DataSet ds = objNegLibros.listadoLibros("Todos");

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    CrearDGVLibros.Rows.Add(dr["ID_Libro"], dr["Titulo"], dr["Autor"], dr["Genero"], dr["Precio"], dr["Cantidad_Stock"]);
                }
            }
            else
            {
                MessageBox.Show("No hay libros cargados en el sistema.");
            }
        }
        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos(txtNombre, txtCorreoElectronico, txtDireccionEnvio))
            {
                Usuario nuevoUsuario = new Usuario
                {
                    Nombre = txtNombre.Text,
                    CorreoElectronico = txtCorreoElectronico.Text,
                    DireccionEnvio = txtDireccionEnvio.Text
                };

                objNegUsuarios.abmUsuarios("Alta", nuevoUsuario);
                MessageBox.Show("Usuario agregado correctamente.");
                LlenarDGVUsuarios();
                LimpiarCampos(txtNombre, txtCorreoElectronico, txtDireccionEnvio);
            }
        }

        private void btnAgregarLibro_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos(txtTitulo, txtAutor, txtGenero, txtPrecio, txtCantidadStock))
            {
                Libro nuevoLibro = new Libro
                {
                    Titulo = txtTitulo.Text,
                    Autor = txtAutor.Text,
                    Genero = txtGenero.Text,
                    Precio = decimal.Parse(txtPrecio.Text),
                    CantidadStock = int.Parse(txtCantidadStock.Text)
                };

                objNegLibros.abmLibros("Alta", nuevoLibro);
                MessageBox.Show("Libro agregado correctamente.");
                LlenarDGVLibros();
                LimpiarCampos(txtTitulo, txtAutor, txtGenero, txtPrecio, txtCantidadStock);
            }
        }

        private void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            if (ValidarCampos(txtIdUsuario, txtIdLibro, txtCantidad))
            {
                Carrito nuevoCarrito = new Carrito
                {
                    IdUsuario = int.Parse(txtIdUsuario.Text),
                    IdLibro = int.Parse(txtIdLibro.Text),
                    Cantidad = int.Parse(txtCantidad.Text)
                };

                int resultado = objNegCarritos.abmCarritos("Alta", nuevoCarrito);

                if (resultado > 0)
                {
                    MessageBox.Show("Carrito agregado correctamente.");
                    LimpiarCampos(txtIdUsuario, txtIdLibro, txtCantidad);
                }
                else
                {
                    MessageBox.Show("Error al agregar el carrito.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos.");
            }
        }
        private bool ValidarCampos(params TextBox[] campos)
        {
            foreach (TextBox campo in campos)
            {
                if (string.IsNullOrWhiteSpace(campo.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }
            return false;
        }

        private void LimpiarCampos(params TextBox[] campos)
        {
            foreach (TextBox campo in campos)
            {
                campo.Text = string.Empty;
            }
        }
    }
}
