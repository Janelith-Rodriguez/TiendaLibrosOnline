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
            CrearDGVUsuarios();
            CrearDGVLibros();
            LlenarDGVUsuarios();
            LlenarDGVLibros();
        }
        private void CargarDatos()
        {
            // Cargar datos iniciales en los DataGridView
            dgvUsuarios.DataSource = negUsuarios.ObtenerUsuarios();
            dgvLibros.DataSource = negLibros.ObtenerLibros();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

        private void CrearDGVUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvUsuarios.Columns.Add("0", "ID");
            dgvUsuarios.Columns.Add("1", "Nombre");
            dgvUsuarios.Columns.Add("2", "Correo Electrónico");
            dgvUsuarios.Columns.Add("3", "Dirección de Envío");

            dgvUsuarios.Columns[0].Width = 50;
            dgvUsuarios.Columns[1].Width = 150;
            dgvUsuarios.Columns[2].Width = 200;
            dgvUsuarios.Columns[3].Width = 250;
        }

        private void CrearDGVLibros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvLibros.Columns.Add("0", "ID");
            dgvLibros.Columns.Add("1", "Título");
            dgvLibros.Columns.Add("2", "Autor");
            dgvLibros.Columns.Add("3", "Género");
            dgvLibros.Columns.Add("4", "Precio");
            dgvLibros.Columns.Add("5", "Cantidad en Stock");

            dgvLibros.Columns[0].Width = 50;
            dgvLibros.Columns[1].Width = 150;
            dgvLibros.Columns[2].Width = 150;
            dgvLibros.Columns[3].Width = 100;
            dgvLibros.Columns[4].Width = 80;
            dgvLibros.Columns[5].Width = 80;
        }

        private void LlenarDGVUsuarios()
        {
            dgvUsuarios.Rows.Clear();
            DataSet ds = objNegUsuarios.listadoUsuarios("Todos");

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dgvUsuarios.Rows.Add(dr["ID_Usuario"], dr["Nombre"], dr["Correo_Electronico"], dr["Direccion_Envio"]);
                }
            }
            else
            {
                MessageBox.Show("No hay usuarios cargados en el sistema.");
            }
        }

        private void LlenarDGVLibros()
        {
            dgvLibros.Rows.Clear();
            DataSet ds = objNegLibros.listadoLibros("Todos");

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dgvLibros.Rows.Add(dr["ID_Libro"], dr["Titulo"], dr["Autor"], dr["Genero"], dr["Precio"], dr["Cantidad_Stock"]);
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
            if (!ValidarCampos(txtIdUsuario, txtIdLibro, txtCantidad))
            {
                Carrito nuevoCarrito = new Carrito
                {
                    IdUsuario = int.Parse(txtIdUsuario.Text),
                    IdLibro = int.Parse(txtIdLibro.Text),
                    Cantidad = int.Parse(txtCantidad.Text)
                };

                objNegCarritos.abmCarritos("Alta", nuevoCarrito);
                MessageBox.Show("Carrito agregado correctamente.");
                LimpiarCampos(txtIdUsuario, txtIdLibro, txtCantidad);
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
