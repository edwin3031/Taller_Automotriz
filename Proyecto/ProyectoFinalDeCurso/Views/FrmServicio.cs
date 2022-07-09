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
    public partial class FrmServicio : Form
    {

        private bool IsNuevo = false;
        private bool IsEditar = false;
        public FrmServicio()
        {
            InitializeComponent();
            this.cmbTipo.SelectedIndex = 0;
        }

        private void FrmServicio_Load(object sender, EventArgs e)
        {
            
            Mostrar();
            Botones();
            
        }

        public void Mostrar()
        {
            this.dtServico.DataSource = CServicio.Mostrar_Servicio();
            //this.dtServico.Columns[0].Visible = false;
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            this.dtServico.DataSource = CServicio.Buscar_Servicio(this.txtFiltro.Text);
            //this.dtServico.Columns[0].Visible = false;

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            IsNuevo = true;
            IsEditar = false;
            this.Botones();
            this.Habilitar(true);
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
        private void Habilitar(bool valor)
        {

            this.txtDescripcion.ReadOnly =!valor;
            this.txtPrecio.ReadOnly = !valor;
            this.cmbTipo.Enabled = valor;
           

        }

        private void Limpiar()
        {

            this.txtDescripcion.Text = string.Empty;
            this.txtPrecio.Text = string.Empty;
            this.cmbTipo.SelectedIndex = 0;


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            IsNuevo = false;
            IsEditar = false;
            this.Botones();
            this.Limpiar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtDescripcion.Text))
            {

                MessageBox.Show("Debe dar doble clic en la fila del registro a modificar", "Servicio de Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                this.IsNuevo = false;
                this.IsEditar = true;
                this.Botones();
                this.txtDescripcion.Focus();

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                if (this.IsNuevo)
                {
                    rpta = CServicio.Insertar_Servicio(this.txtDescripcion.Text,Convert.ToDecimal( this.txtPrecio), this.cmbTipo.Text);

                }
                else
                {
                    rpta = CServicio.Actualizar_Servicio(Convert.ToInt32(this.dtServico.CurrentRow.Cells["ID Servicio"].Value),
                      this.txtDescripcion.Text, Convert.ToDecimal(this.txtPrecio.Text), this.cmbTipo.Text);

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

        private void dtServico_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtDescripcion.Text = Convert.ToString(this.dtServico.CurrentRow.Cells["Descripción"].Value);
            this.txtPrecio.Text = Convert.ToString(this.dtServico.CurrentRow.Cells["Precio"].Value);
            this.cmbTipo.DropDownStyle = ComboBoxStyle.DropDown;
            this.cmbTipo.Text = Convert.ToString(this.dtServico.CurrentRow.Cells["Tipo de Mantenimiento"].Value);
            this.cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;




        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            if (this.dtServico.SelectedRows.Count == 1)
            {

                try
                {
                    string rpta = "";


                    rpta = CServicio.Actualizar_Estado(Convert.ToInt32(this.dtServico.CurrentRow.Cells["IdServicio"].Value));

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
    }
}
