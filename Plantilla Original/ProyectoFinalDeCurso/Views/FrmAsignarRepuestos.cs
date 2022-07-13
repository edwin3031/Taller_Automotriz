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
    public partial class FrmAsignarRepuestos : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        public static int idDetalleMantenimiento;
        public static int idMantenimiento;
        public string Descipcion = FrmSeleccionarRepuesto.descripcion;
        public int id1 = FrmSeleccionarRepuesto.idRespuesto;
        public string marca = FrmSeleccionarRepuesto.Marca;
        public string modelo = FrmSeleccionarRepuesto.Modelo;
        public decimal precio = FrmSeleccionarRepuesto.precio;

        public FrmAsignarRepuestos()
        {
            InitializeComponent();
        }

        private void FrmRepuestos_Load(object sender, EventArgs e)
        {
            dgvMantenimientos.DataSource = CAsignarRepuesto.Mostrar_Mantenimiento_Mecanico();
            Mostrar();
            Botones();
        }

        private void Mostrar()
        {
            dgvMantenimientos.DataSource = CAsignarRepuesto.Mostrar_Mantenimiento_Mecanico();
            this.dgvMantenimientos.Columns[0].Visible = false;
            this.dgvMantenimientos.Columns[1].Visible = false;
            //dgvRepuestos.DataSource = CAsignarRepuesto.Mostrar_Servicios_Repuestos(idDetalleMantenimiento);
            
        }

       

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtDescripcion.Text))
            {

                MessageBox.Show("Debe buscar un repuesto" +
                    " para asignar", "Servicio de Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                this.IsNuevo = false;
                this.IsEditar = true;
                this.Botones();
                

            }
        }
        public void getDatos(int idRepuesto,string descripcion,string marca,string modelo,decimal precio)
        {
            this.id1 = idRepuesto;
            this.txtDescripcion.Text = descripcion;
            this.txtMarca.Text = marca;
            this.txtModelo.Text = modelo;
            this.txtPrecio.Text = Convert.ToString(precio);
            

        }

       
        private void button5_Click(object sender, EventArgs e)
        {
            FrmSeleccionarRepuesto frmSeleccionarRepuesto = new FrmSeleccionarRepuesto(this);
            frmSeleccionarRepuesto.ShowDialog();
        }

        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar) //Alt + 124
            {
                Habilitar(true);
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                Habilitar(false);
                this.btnGuardar.Enabled = false;
                this.btnCancelar.Enabled = false;

            }
        }

        private void Habilitar(bool valor)
        {

            this.txtDescripcion.ReadOnly = !valor;
            this.txtMarca.ReadOnly = !valor;
            this.txtModelo.ReadOnly = !valor;
            this.txtPrecio.ReadOnly = !valor;
     
        }

        private void Limpiar()
        {
            this.txtCantidad.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtMarca.Text = string.Empty;
            this.txtModelo.Text = string.Empty;
            this.txtPrecio.Text = string.Empty;
        


        }

        private void dgvServicios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r;
            r = dgvServicios.SelectedRows.Count;


            if (r > 0)
            {
                DataGridViewRow dr = dgvServicios.SelectedRows[0];
                idDetalleMantenimiento = (Convert.ToInt32((dr.Cells[0].Value)));

            }
            dgvRepuestos.DataSource = CAsignarRepuesto.Mostrar_Servicios_Repuestos(idDetalleMantenimiento);
            Mostrar();

        }

        private void dgvServicios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int r;
            r = dgvServicios.SelectedRows.Count;


            if (r > 0)
            {
                DataGridViewRow dr = dgvServicios.SelectedRows[0];
                idDetalleMantenimiento = (Convert.ToInt32((dr.Cells[0].Value)));

            }
            dgvRepuestos.DataSource = CAsignarRepuesto.Mostrar_Servicios_Repuestos(idDetalleMantenimiento);
            Mostrar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                int id=0;
               
                id= Convert.ToInt32(this.dgvMantenimientos.CurrentRow.Cells["IdDetalleMantenimiento"].Value);
                if (id == 0)
                {
                    MessageBox.Show("Debe buscar un repuesto" +
                   " para asignar", "Servicio de Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    rpta = CAsignarRepuesto.Aignar_Repuesto(id, this.id1, Convert.ToInt32(this.txtCantidad.Text));
                }


                if (rpta.Equals("OK"))
                {
                    
                    

                        MessageBox.Show("Datos Ingresados", "Servicio de Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dgvMantenimientos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int r;
            r = dgvMantenimientos.SelectedRows.Count;


            if (r == 0)
            {
                return;

            }
            DataGridViewRow dr = dgvMantenimientos.SelectedRows[0];
            idMantenimiento = (Convert.ToInt32((dr.Cells[0].Value)));
            dgvServicios.DataSource = CAsignarRepuesto.Mostrar_Mantenimientos_Servicios(idMantenimiento);
            this.dgvServicios.Columns[0].Visible = false;
        }

        private void dgvMantenimientos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r;
            r = dgvMantenimientos.SelectedRows.Count;


            if (r == 0)
            {
                return;

            }
            DataGridViewRow dr = dgvMantenimientos.SelectedRows[0];
            idMantenimiento = (Convert.ToInt32((dr.Cells[0].Value)));
            dgvServicios.DataSource = CAsignarRepuesto.Mostrar_Mantenimientos_Servicios(idMantenimiento);
            this.dgvServicios.Columns[0].Visible = false;
        }
    }
}
