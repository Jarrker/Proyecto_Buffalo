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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Inicio form = new Inicio();

            form.Show();
            this.Hide();
            //   evento
            form.FormClosing += CerrarForm;
        }

        private void CerrarForm(object sender, FormClosingEventArgs e)
        {
            txtUsuario.Text = "";
            txtContra.Text = "";
            this.Show();
        }
    }
}
