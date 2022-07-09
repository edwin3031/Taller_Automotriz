using ProyectoFinalDeCurso.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalDeCurso.Views
{
    public partial class FrmCliente : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        public FrmCliente()
        {
            InitializeComponent();
            
        }

        public void Mostrar()
        {
            this.dtCliente.DataSource = CCliente.Mostrar_Clientes();
            //dtCliente.Columns[0].Visible = false;

        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
             this.Mostrar();
            this.Botones();
            
        }

        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar) //Alt + 124
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnActualizar.Enabled = false;
                this.btnCancelar.Enabled = true;
                this.btnEstado.Enabled = false;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnActualizar.Enabled = true;
                this.btnCancelar.Enabled = false;
                this.btnEstado.Enabled = true;
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            this.dtCliente.DataSource = CCliente.Buscar_Clientes(this.txtFiltro.Text);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            IsNuevo = true;
            IsEditar = false;
            this.Botones();
            this.Habilitar(true);
            this.txtNombreCliente.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                if (this.IsNuevo)
                {
                    rpta = CCliente.Insertar_Clientes(this.txtNombreCliente.Text, this.txtNombreCliente2.Text, this.txtApellidoCliente.Text, this.txtApellidoCliente2.Text, this.txtDireccion.Text, txtCorreo.Text, this.txtTelefono.Text);

                }
                else
                {
                    rpta = CCliente.Actualizar_Clientes(Convert.ToInt32(this.dtCliente.CurrentRow.Cells["ID Cliente"].Value),
                       this.txtNombreCliente.Text, this.txtNombreCliente2.Text, this.txtApellidoCliente.Text,
                        this.txtApellidoCliente2.Text, this.txtDireccion.Text, txtCorreo.Text, this.txtTelefono.Text);

                }

                if (rpta.Equals("OK"))
                {
                    if (this.IsNuevo)
                    {

                        MessageBox.Show("Datos Ingresados", "Servicio de Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Datos Actualizados", "Servicio de Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {

                    MessageBox.Show(rpta, "Servicio de Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.IsNuevo = false;
                this.IsEditar = false;
                this.Botones();
                this.Limpiar();
                this.Mostrar();


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtNombreCliente.Text))
            {

                MessageBox.Show("Debe dar doble clic en la fila del registro a modificar", "Servicio de Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                this.IsNuevo = false;
                this.IsEditar = true;
                this.Botones();
                this.txtNombreCliente.Focus();

            }
        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            if (this.dtCliente.SelectedRows.Count == 1)
            {

                try
                {
                    string rpta = "";


                    rpta = CCliente.Actualizar_Estado(Convert.ToInt32(this.dtCliente.CurrentRow.Cells["ID Cliente"].Value));

                    if (rpta.Equals("OK"))
                    {


                        MessageBox.Show("El Estado ha sido actualizado", "Servicio de Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                    else
                    {

                        MessageBox.Show(rpta, "Servicio de Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();


                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
                //this.IsNuevo = false;
                //this.IsEditar = true;
                //this.Botones();
                //this.txtPrimerNombre.Focus();

            }
            else
            {
                MessageBox.Show("Debe seleccionar una Fila antes de actualizar el estado", "Servicio de mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            IsNuevo = false;
            IsEditar = false;
            this.Botones();
            this.Limpiar();

        }


        private void Habilitar(bool valor)
        {

            this.txtNombreCliente.ReadOnly = !valor;
            this.txtNombreCliente2.ReadOnly = !valor;
            this.txtApellidoCliente.ReadOnly = !valor;
            this.txtApellidoCliente2.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.txtCorreo.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
        }

        private void Limpiar()
        {

            this.txtNombreCliente.Text = string.Empty;
            this.txtNombreCliente2.Text = string.Empty;
            this.txtApellidoCliente.Text = string.Empty;
            this.txtApellidoCliente2.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtCorreo.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;

        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

           
        }

        private void dtCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtNombreCliente.Text = Convert.ToString(this.dtCliente.CurrentRow.Cells["Primer Nombre"].Value);
            this.txtNombreCliente2.Text = Convert.ToString(this.dtCliente.CurrentRow.Cells["Segundo Nombre"].Value); 
            this.txtApellidoCliente.Text = Convert.ToString(this.dtCliente.CurrentRow.Cells["Primer Apellido"].Value); 
            this.txtApellidoCliente2.Text = Convert.ToString(this.dtCliente.CurrentRow.Cells["Segundo Apellido"].Value); 
            this.txtDireccion.Text = Convert.ToString(this.dtCliente.CurrentRow.Cells["Dirección"].Value); 
            this.txtCorreo.Text = Convert.ToString(this.dtCliente.CurrentRow.Cells["Correo"].Value);
            string telefono;
            telefono = Convert.ToString(this.dtCliente.CurrentRow.Cells["Teléfono"].Value);
            this.txtTelefono.Text = telefono;
            
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }



}
