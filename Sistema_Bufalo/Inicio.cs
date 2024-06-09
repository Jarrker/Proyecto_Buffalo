using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Bufalo
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private static IconMenuItem MenuActivo = null;
        private static Form FormularioActivo = null;

        private void AbrirFormulario(IconMenuItem menu, Form formulario)
        {
            if (MenuActivo != null)
            {
                MenuActivo.BackColor = Color.White;
            }
            menu.BackColor = Color.Silver;
            MenuActivo = menu;

            if (FormularioActivo != null)
            {
                FormularioActivo.Close();
            }
            //Configurar el formulario
            FormularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.BackColor = Color.RosyBrown;
            //Agregar el formulario al contenedor
            contenedor.Controls.Add(formulario);
            formulario.Show();
        }

        private void menuEmpleados_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmEmpleados());
        }

        private void menuCategoria_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuMantenedor, new frmCategoria());
        }

        private void subMenuGestionProducto_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuMantenedor, new frmGestionProducto());
        }

        private void subMenuRegistrarMenu_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuMenu, new frmRegistrarMenu());
        }

        private void subMenuRegistrarVenta_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario(menuMenu, new frmRegistrarVenta());
        }

        private void subMenuReporteVentas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuReportes, new frmReporteVentas());
        }

        private void menuClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuClientes, new frmClientes());
        }

        private void subMenuDetalleMenu_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuMenu, new frmDetalleMenu());
        }

        private void menuProveedores_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuProveedores, new frmProveedores());
        }
    }
}
