using ProyectoFinalDeCurso.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalDeCurso.Views
{
    public partial class FrmRepuesto : Form
    {

        private bool IsNuevo = false;
        private bool IsEditar = false;
        public FrmRepuesto()
        {
            InitializeComponent();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            this.dtRepuesto.DataSource = CRepuesto.Buscar_Repuesto(this.txtFiltro.Text);
            //this.dtRepuesto.Columns[0].Visible = false;
        }

        public void Mostrar()
        {
            this.dtRepuesto.DataSource = CRepuesto.Mostrar_Repuesto();
             //this.dtRepuesto.Columns[0].Visible = false;

        }

        private void FrmRepuesto_Load(object sender, EventArgs e)
        {
            Mostrar();
            Botones();
        }

       

       

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
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
                this.btnEstado.Enabled = false;
            }
        }
        private void Habilitar(bool valor)
        {

          
            this.txtMarca.ReadOnly = !valor;
            this.txtModelo.ReadOnly= !valor;
            this.txtDescripcion.ReadOnly = !valor;
            this.txtCantidad.ReadOnly= !valor;
            this.txtPrecio.ReadOnly=!valor;
         


        }

        private void Limpiar()
        {
            this.txtMarca.Text = string.Empty;
            this.txtModelo.Text = string.Empty;
            this.txtCantidad.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtPrecio.Text = string.Empty;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            IsNuevo = false;
            IsEditar = false;
            this.Botones();
            this.Limpiar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            IsNuevo = true;
            IsEditar = false;
            this.Botones();
            this.Habilitar(true);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtMarca.Text))
            {

                MessageBox.Show("Debe dar doble clic en la fila del registro a modificar", "Servicio de Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                this.IsNuevo = false;
                this.IsEditar = true;
                this.Botones();
                this.txtMarca.Focus();

            }
        }

        private void dtRepuesto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtMarca.Text = Convert.ToString(this.dtRepuesto.CurrentRow.Cells["Marca"].Value);
            this.txtModelo.Text = Convert.ToString(this.dtRepuesto.CurrentRow.Cells["Modelo"].Value);
            this.txtCantidad.Text = Convert.ToString(this.dtRepuesto.CurrentRow.Cells["Cantidad"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dtRepuesto.CurrentRow.Cells["Descripción"].Value);
            this.txtPrecio.Text = Convert.ToString(this.dtRepuesto.CurrentRow.Cells["Precio"].Value);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                if (this.IsNuevo)
                {
                    rpta = CRepuesto.Insertar_Repuesto(this.txtMarca.Text,this.txtModelo.Text,Convert.ToInt32(this.txtCantidad.Text),this.txtDescripcion.Text,Convert.ToDecimal(this.txtPrecio.Text));

                }
                else
                {
                    rpta = CRepuesto.Actualizar_Repuesto(Convert.ToInt32(this.dtRepuesto.CurrentRow.Cells["ID Repuesto"].Value),
                        this.txtMarca.Text, this.txtModelo.Text, Convert.ToInt32(this.txtCantidad.Text), this.txtDescripcion.Text, Convert.ToDecimal(this.txtPrecio.Text));

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

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            if (this.dtRepuesto.SelectedRows.Count == 1)
            {

                try
                {
                    string rpta = "";


                    rpta = CRepuesto.Actualizar_Estado(Convert.ToInt32(this.dtRepuesto.CurrentRow.Cells["IdRepuesto"].Value));

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
    }
}
