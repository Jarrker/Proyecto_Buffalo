using CapaEntidad;
using CapaNegocio;
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
    public partial class frmEmpleados : Form
    {
        public frmEmpleados()
        {
            InitializeComponent();
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            for (int i = 1; i < dgvData.Columns.Count; i++)
            {
                dgvData.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void limpiar()
        {
            txtIndice.Text = "-1";
            txtId.Text = "0";
            txtDocumento.Text = "";
            txtNombreCompleto.Text = "";
            txtCorreo.Text = "";
            txtClave.Text = "";
            txtConfirmarClave.Text = "";
            cboEstado.SelectedIndex = 0;
            cboRol.SelectedIndex = 0;

            txtDocumento.Select();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;

            CE_Empleado objempleado = new CE_Empleado()
            {
                IdUsuario = Convert.ToInt32(txtId.Text),
                Documento = txtDocumento.Text,
                Nombre = txtNombreCompleto.Text,
                Correo = txtCorreo.Text,
                Clave = txtClave.Text,
                oRol = new CE_Rol() { IdRol = Convert.ToInt32(((OpCombo)cboRol.SelectedItem).Valor) },
                Estado = Convert.ToInt32(((OpCombo)cboEstado.SelectedItem).Valor) == 1 ? true : false
            };

            if (objempleado.IdUsuario == 0)
            {
                int idgenerado = new CN_Empleado().Registrar(objempleado, out Mensaje);

                if (idgenerado != 0)
                {
                    dgvData.Rows.Add(new object[] {"",idgenerado,txtDocumento.Text,txtNombreCompleto.Text,txtCorreo.Text,txtClave.Text,
                    ((OpCombo)cboRol.SelectedItem).Valor.ToString(),
                    ((OpCombo)cboRol.SelectedItem).Texto.ToString(),
                    ((OpCombo)cboEstado.SelectedItem).Valor.ToString(),
                    ((OpCombo)cboEstado.SelectedItem).Texto.ToString(),
                    objempleado.IsLoggedIn ? 1 : 0,
                    objempleado.IsLoggedIn == true ? "Conectado" : "Desconectado"

                    });

                    limpiar();
                }
                else
                {
                    MessageBox.Show(Mensaje);
                }
            }
            else
            {
                bool resultado = new CN_Empleado().Editar(objempleado, out Mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dgvData.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["Id"].Value = txtId.Text;
                    row.Cells["Documento"].Value = txtDocumento.Text;
                    row.Cells["Nombre"].Value = txtNombreCompleto.Text;
                    row.Cells["Correo"].Value = txtCorreo.Text;
                    row.Cells["Clave"].Value = txtClave.Text;
                    row.Cells["IdRol"].Value = ((OpCombo)cboRol.SelectedItem).Valor.ToString();
                    row.Cells["Rol"].Value = ((OpCombo)cboRol.SelectedItem).Texto.ToString();
                    row.Cells["EstadoValor"].Value = ((OpCombo)cboEstado.SelectedItem).Valor.ToString();
                    row.Cells["Estado"].Value = ((OpCombo)cboEstado.SelectedItem).Texto.ToString();

                    limpiar();
                }
                else
                {
                    MessageBox.Show(Mensaje);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtId.Text) != 0)
            {
                if (MessageBox.Show("¿Quiere eliminar al empleado?", "Adventencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    CE_Empleado objusuario = new CE_Empleado()
                    {
                        IdUsuario = Convert.ToInt32(txtId.Text),

                    };

                    bool respuesta = new CN_Empleado().Eliminar(objusuario, out mensaje);

                    if (respuesta)
                    {
                        dgvData.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
                        limpiar();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpCombo)cboBusqueda.SelectedItem).Valor.ToString();

            if (dgvData.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBuscar.Text.Trim().ToUpper()))
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
        }

        private void btnLimpiarBuscador_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                row.Visible = true;
            }
        }

        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            cboEstado.Items.Add(new OpCombo() { Valor = 1, Texto = "Activo" });
            cboEstado.Items.Add(new OpCombo() { Valor = 0, Texto = "No Activo" });
            cboEstado.DisplayMember = "Texto";
            cboEstado.ValueMember = "Valor";
            cboEstado.SelectedIndex = 0;

            List<CE_Rol> listarol = new CN_Rol().Listar();

            foreach (CE_Rol item in listarol)
            {

                cboRol.Items.Add(new OpCombo() { Valor = item.IdRol, Texto = item.Descripcion });

            }
            cboRol.DisplayMember = "Texto";
            cboRol.ValueMember = "Valor";
            cboRol.SelectedIndex = 0;

            foreach (DataGridViewColumn columna in dgvData.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar")
                {
                    cboBusqueda.Items.Add(new OpCombo { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cboBusqueda.DisplayMember = "Texto";
            cboBusqueda.ValueMember = "Valor";
            cboBusqueda.SelectedIndex = 0;

            List<CE_Empleado> listausuario = new CN_Empleado().Listar();

            foreach (CE_Empleado item in listausuario)
            {
                dgvData.Rows.Add(new object[] {"",item.IdUsuario,item.Documento,item.Nombre,item.Correo,item.Clave,
                item.oRol.IdRol,
                item.oRol.Descripcion,
                item.Estado == true ? 1:0,
                item.Estado == true ? "Activo" : "No activo",
                item.IsLoggedIn ? 1 : 0,
                item.IsLoggedIn == true ? "Conectado" : "Desconectado"
                });
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvData.Rows[indice].Cells["Id"].Value.ToString();
                    txtDocumento.Text = dgvData.Rows[indice].Cells["Documento"].Value.ToString();
                    txtNombreCompleto.Text = dgvData.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtCorreo.Text = dgvData.Rows[indice].Cells["Correo"].Value.ToString();
                    txtClave.Text = dgvData.Rows[indice].Cells["Clave"].Value.ToString();
                    txtConfirmarClave.Text = dgvData.Rows[indice].Cells["Clave"].Value.ToString();

                    foreach (OpCombo oc in cboRol.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvData.Rows[indice].Cells["IdRol"].Value))
                        {
                            int indicecombo = cboRol.Items.IndexOf(oc);
                            cboRol.SelectedIndex = indicecombo;
                            break;
                        }
                    }

                    foreach (OpCombo oc in cboEstado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvData.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indicecombo = cboEstado.Items.IndexOf(oc);
                            cboEstado.SelectedIndex = indicecombo;
                            break;
                        }
                    }
                }
            }
        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (e.KeyChar == ' ' && textBox.Text.Length == 0)
            {
                e.Handled = true;
                return;
            }

            if (char.IsControl(e.KeyChar))
            {
                return;
            }
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            if (textBox.Text.Length >= 8)
            {
                e.Handled = true;
            }
        }

        private void txtNombreCompleto_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (e.KeyChar == ' ' && textBox.Text.Length == 0)
            {
                e.Handled = true;
                return;
            }

            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (e.KeyChar == ' ' && textBox.Text.Length == 0)
            {
                e.Handled = true;
                return;
            }

            if (!char.IsControl(e.KeyChar) &&
                !char.IsLetterOrDigit(e.KeyChar) &&
                e.KeyChar != '.' &&
                e.KeyChar != '@' &&
                e.KeyChar != '-' &&
                e.KeyChar != '_' && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
    }
}
