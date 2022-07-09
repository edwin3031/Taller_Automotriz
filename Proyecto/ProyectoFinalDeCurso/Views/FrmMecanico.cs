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
    public partial class FrmMecanico : Form
    {
        public FrmMecanico()
        {
            InitializeComponent();
        }

        private bool IsNuevo = false;
        private bool IsEditar = false;
   


        public void Mostrar()
        {
            this.dtMecanico.DataSource = CMecanico.Mostrar_Mecanico();
            dtMecanico.Columns[0].Visible = false;
            this.cmbEspecialidad.SelectedIndex = 1;
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
           
            this.txtNombreMecanico.ReadOnly = !valor;
            this.txtNombreMecanico2.ReadOnly = !valor;
            this.txtApellidoMecanico.ReadOnly = !valor;
            this.txtApellidoMecanico2.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.txtCorreo.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtSalario.ReadOnly=!valor;
        }

        private void Limpiar()
        {
            
            this.txtNombreMecanico.Text = string.Empty;
            this.txtNombreMecanico2.Text = string.Empty;
            this.txtApellidoMecanico.Text = string.Empty;
            this.txtApellidoMecanico2.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtCorreo.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtSalario.Text=string.Empty;

        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            this.dtMecanico.DataSource = CMecanico.Buscar_Mecanico(this.txtFiltro.Text);
        }

        private void FrmMecanico_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            this.Botones();
            
        }

        private void dtMecanico_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            IsNuevo = true;
            IsEditar = false;
            this.Botones();
            this.Habilitar(true);
            this.txtNombreMecanico.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                if (this.IsNuevo)
                {
                    rpta = CMecanico.Insertar_Mecanico(this.txtNombreMecanico.Text, this.txtNombreMecanico2.Text, this.txtApellidoMecanico.Text, this.txtApellidoMecanico2.Text, this.cmbEspecialidad.Text, this.txtDireccion.Text, txtCorreo.Text, this.txtTelefono.Text, Convert.ToDecimal(this.txtSalario.Text));

                }
                else
                {
                    rpta = rpta = CMecanico.Actualizar_Mecanico(Convert.ToInt32(this.dtMecanico.CurrentRow.Cells["ID Mecanico"].Value),
                       this.txtNombreMecanico.Text, this.txtNombreMecanico2.Text, this.txtApellidoMecanico.Text, this.txtApellidoMecanico2.Text, this.cmbEspecialidad.Text, this.txtDireccion.Text, txtCorreo.Text, this.txtTelefono.Text, Convert.ToDecimal(this.txtSalario.Text));
                   

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
            if (String.IsNullOrEmpty(this.txtNombreMecanico.Text))
            {

                MessageBox.Show("Debe dar doble clic en la fila del registro a modificar", "Servicio de Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                this.IsNuevo = false;
                this.IsEditar = true;
                this.Botones();
                this.txtNombreMecanico.Focus();

            }
        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            if (this.dtMecanico.SelectedRows.Count == 1)
            {

                try
                {
                    string rpta = "";


                    rpta = CMecanico.Actualizar_Estado(Convert.ToInt32(this.dtMecanico.CurrentRow.Cells["IdMecanico"].Value));

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

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            IsNuevo = false;
            IsEditar = false;
            this.Botones();
            this.Limpiar();
        }

        private void dtMecanico_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtNombreMecanico.Text = Convert.ToString(this.dtMecanico.CurrentRow.Cells["Primer Nombre"].Value);
            this.txtNombreMecanico2.Text = Convert.ToString(this.dtMecanico.CurrentRow.Cells["Segundo Nombre"].Value); ;
            this.txtApellidoMecanico.Text = Convert.ToString(this.dtMecanico.CurrentRow.Cells["Primer Apellido"].Value); ;
            this.txtApellidoMecanico2.Text = Convert.ToString(this.dtMecanico.CurrentRow.Cells["Segundo Apellido"].Value); ;
            this.txtDireccion.Text = Convert.ToString(this.dtMecanico.CurrentRow.Cells["Dirección"].Value); ;
            this.txtCorreo.Text = Convert.ToString(this.dtMecanico.CurrentRow.Cells["Correo"].Value); ;
            this.txtTelefono.Text = this.dtMecanico.CurrentRow.Cells["Teléfono"].Value.ToString();
            this.txtSalario.Text = this.dtMecanico.CurrentRow.Cells["Salario"].Value.ToString();

            this.cmbEspecialidad.DropDownStyle = ComboBoxStyle.DropDown;
            this.cmbEspecialidad.Text = this.dtMecanico.CurrentRow.Cells["Especialidad"].Value.ToString();
            this.cmbEspecialidad.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void cmbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    } 
            
}
