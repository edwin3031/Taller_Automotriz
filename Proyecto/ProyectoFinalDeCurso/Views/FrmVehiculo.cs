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
    public partial class FrmVehiculo : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        public string nombre =  FrmSeleccionarCliente.nombre; 
        public int id1 =FrmSeleccionarCliente.id;
        
        public FrmVehiculo()
        {
            InitializeComponent();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            this.dtVehículos.DataSource = CVehiculo.Buscar_Vehiculo(this.txtFiltro.Text);
        }

        public void Mostrar()
        {
            this.dtVehículos.DataSource = CVehiculo.Mostrar_Vehiculo();
            //this.dtVehículos.Columns[0].Visible = false;
            //this.dtVehículos.Columns[1].Visible = false;
        }

        private void FrmVehiculo_Load(object sender, EventArgs e)
        {
            Mostrar();
            Botones();
            this.txtIdCliente.Text = nombre;
        }

       


        private void btnBuscarCLiente_Click(object sender, EventArgs e)
        {
            FrmSeleccionarCliente frmSeleccionar = new FrmSeleccionarCliente(this);
            frmSeleccionar.ShowDialog();
        }
        public void setTxTNombre(string nombre,int id)
        {
            txtIdCliente.Text = nombre;
            id1= id;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            IsNuevo = true;
            IsEditar = false;
            this.Botones();
            this.Habilitar(true);
            this.btnBuscarCLiente.Focus();
        }

        private void Habilitar(bool valor)
        {

            this.txtIdCliente.ReadOnly = true;
            this.txtMarca.ReadOnly = !valor;
            this.txtModelo.ReadOnly = !valor;
            this.txtAño.ReadOnly = !valor;
           
        }

        private void Limpiar()
        {

            this.txtIdCliente.Text = string.Empty;
            this.txtMarca.Text = string.Empty;
            this.txtModelo.Text = string.Empty;
            this.txtAño.Text = string.Empty;
           

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
                
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnActualizar.Enabled = true;
                this.btnCancelar.Enabled = false;
               
            }
        }
        

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                string rpta = "";

                if (this.IsNuevo)
                {
                    rpta = CVehiculo.Insertar_Vehiculo(id1, this.txtMarca.Text, this.txtModelo.Text,Convert.ToInt32( this.txtAño.Text));

                }
                else
                {
                    rpta = CVehiculo.Actualizar_Vehiculo(Convert.ToInt32(this.dtVehículos.CurrentRow.Cells["ID Vehículo"].Value),
                                           Convert.ToInt32(this.dtVehículos.CurrentRow.Cells["Nombre Cliente"].Value), this.txtMarca.Text, this.txtModelo.Text, Convert.ToInt32(this.txtAño.Text));
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

        private void dtVehículos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtIdCliente.Text = Convert.ToString(this.dtVehículos.CurrentRow.Cells["Nombre Cliente"].Value);
            this.txtMarca.Text = Convert.ToString(this.dtVehículos.CurrentRow.Cells["Marca"].Value);
            this.txtModelo.Text = Convert.ToString(this.dtVehículos.CurrentRow.Cells["Modelo"].Value);
            this.txtAño.Text = Convert.ToString(this.dtVehículos.CurrentRow.Cells["Año"].Value);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtIdCliente.Text))
            {

                MessageBox.Show("Debe dar doble clic en la fila del registro a modificar", "Servicio de Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                this.IsNuevo = false;
                this.IsEditar = true;
                this.Botones();
                this.txtIdCliente.Focus();

            }
        }

        private void btnEstado_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            IsNuevo = false;
            IsEditar = false;
            this.Botones();
            this.Limpiar();
        }
    }
}
