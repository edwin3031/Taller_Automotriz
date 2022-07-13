using ProyectoFinalDeCurso.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalDeCurso.Views
{
    public partial class FrmMantenimiento : Form
    {

        private bool IsNuevo = false;
        private bool IsEditar = false;
        
        public static int idVehiculo;
        public  int idMantenimiento;

        public string nombreCliente = FrmSeleccionarVehiculo.nombreCliente;
        public int id1 = FrmSeleccionarVehiculo.idVehiculo;
        public string marca = FrmSeleccionarVehiculo.marca;
        public string modelo = FrmSeleccionarVehiculo.modelo;

        //Servicio

        public int idS = FrmSelecionarServicio.idServicio;
        public string descripcionS = FrmSelecionarServicio.descripcion;
        public string tipoS = FrmSelecionarServicio.Tipo;
        public decimal precioS = FrmSelecionarServicio.precio;

        //mecanico
        public int idM = FrmSeleccionarMecanico.idMecanico;
        public string nombreM = FrmSeleccionarMecanico.nombre;
        public string especialidad = FrmSeleccionarMecanico.especialidad;
        public string telefono = FrmSeleccionarMecanico.telefono;

        public FrmMantenimiento()
        {
            InitializeComponent();
            
        }


        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar) //Alt + 124
            {
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnCancelar.Enabled = false;
                
            }
        }

        private void Habilitar(bool valor)
        {

            this.txtCliente.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
            this.txtEspecialidad.ReadOnly = !valor;
            this.txtMarca.ReadOnly = !valor;
            this.txtModelo.ReadOnly = !valor;
            this.txtPrecio.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtNombreMecanico.ReadOnly = !valor;
            this.txtTipoMantenimiento.ReadOnly = !valor;
            
        }

        private void Limpiar()
        {
            this.txtCliente.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtEspecialidad.Text = string.Empty;
            this.txtMarca.Text = string.Empty;
            this.txtModelo.Text = string.Empty;
            this.txtPrecio.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtNombreMecanico.Text = string.Empty;
            this.txtTipoMantenimiento.Text = string.Empty;


        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void FrmMantenimiento_Load(object sender, EventArgs e)
        {
            Mostrar();
            Botones();
            Habilitar(false);
        }

        public void Mostrar()
        {
            this.dgvMantenimientos.DataSource = CMantenimiento.Mostrar_Mantenimiento();
            this.dgvMantenimientos.Columns[0].Visible = false;
            this.dgvMantenimientos.Columns[1].Visible = false;
        }

        public void ValidadAsignacionDeServicio()
        {
           
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscarVehiculo_Click(object sender, EventArgs e)
        {
            FrmSeleccionarVehiculo frmSeleccionarVehiculo = new FrmSeleccionarVehiculo(this);
            frmSeleccionarVehiculo.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmSelecionarServicio frmSelecionarServicio = new FrmSelecionarServicio(this);
            frmSelecionarServicio.ShowDialog();
        }

        public void obtenerDatosVehiculos(int idVehiculo,string nombreCliente,string marca,string modelo)
        {
            this.id1 = idVehiculo;
            this.txtCliente.Text = nombreCliente;
            this.txtMarca.Text = marca;
            this.txtModelo.Text = modelo;
        }

       

        public void obtenerDatosServicio(int idServicio,string descripcion,decimal precio,string tipo)
        {
            this.idS = idServicio;
            this.txtDescripcion.Text = descripcion;
            this.txtPrecio.Text =Convert.ToString( precio);
            this.txtTipoMantenimiento.Text = tipo;

        }

        public void obtenerDatosMecanico(int idMecanico,string nombre,string especialidad,string telefono)
        {
            this.idM = idMecanico;
            this.txtNombreMecanico.Text = nombre;
            this.txtTelefono.Text = telefono;
            this.txtEspecialidad.Text = especialidad;

        }

        private void btnBuscarMecanico_Click(object sender, EventArgs e)
        {
            FrmSeleccionarMecanico frmSeleccionarMecanico = new FrmSeleccionarMecanico(this);
            frmSeleccionarMecanico.ShowDialog();
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            IsNuevo = true;
            IsEditar = false;
            this.Botones();
            
            this.btnBuscarVehiculo.Focus();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            IsNuevo = false;
            IsEditar = false;
            Botones();
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                if (this.IsNuevo)
                {
                    rpta = CMantenimiento.Insertar_Mantenimiento(this.id1,this.idM,this.idS,this.dtpFechaIngreso.Value.Date.ToShortDateString(), this.dtpFechaSalida.Value.Date.ToShortDateString());

                }
                else
                {
                    if (String.IsNullOrEmpty(this.txtDescripcion.Text) || (String.IsNullOrEmpty(this.txtNombreMecanico.Text)))
                    {

                        MessageBox.Show("Debe Buscar un sevicio y un mecánico antes de guardar", "Servicio de Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                   
                     this.IsNuevo = false;
                     this.IsEditar = true;
                     this.Botones();
                     rpta = CMantenimiento.Aignar_Servicio(this.idMantenimiento, this.idM, this.idS);

                    

                }



                if (rpta.Equals("OK"))
                {
                    if (this.IsNuevo)
                    {

                        MessageBox.Show("Datos Ingresados", "Servicio de Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Servicio Asignado Exitosamente", "Servicio de Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtCliente.Text))
            {

                MessageBox.Show("Debe dar doble clic en la fila del registro a modificar", "Servicio de Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                this.IsNuevo = false;
                this.IsEditar = true;
                this.Botones();
                this.btnBuscarVehiculo.Enabled=false;

            }
        }



        private void dgvMantenimientos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.idMantenimiento = Convert.ToInt32(this.dgvMantenimientos.CurrentRow.Cells["IdMantenimiento"].Value);
            this.txtCliente.Text= Convert.ToString(this.dgvMantenimientos.CurrentRow.Cells["Cliente"].Value);
            this.txtMarca.Text = Convert.ToString(this.dgvMantenimientos.CurrentRow.Cells["Marca"].Value);
            this.txtModelo.Text = Convert.ToString(this.dgvMantenimientos.CurrentRow.Cells["Modelo"].Value);
            this.dtpFechaIngreso.Value = Convert.ToDateTime(Convert.ToString(this.dgvMantenimientos.CurrentRow.Cells["Fecha de Ingreso"].Value));
            this.dtpFechaSalida.Value= Convert.ToDateTime(Convert.ToString(this.dgvMantenimientos.CurrentRow.Cells["Fecha de Salida"].Value));
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            int r;
            r = dgvMantenimientos.SelectedRows.Count;


            if (r > 0)
            {
                DataGridViewRow dr = dgvMantenimientos.SelectedRows[0];
                idVehiculo = (Convert.ToInt32((dr.Cells[1].Value)));

                FrmMostrarHistorial fr = new FrmMostrarHistorial(idVehiculo);
                fr.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("Debe seleccionar una Fila antes", "Servicio de mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void txtBuscarMantenimiento_TextChanged(object sender, EventArgs e)
        {
            this.dgvMantenimientos.DataSource = CMantenimiento.Buscar_Mantenimientos(this.txtBuscarMantenimiento.Text);
            this.dgvMantenimientos.Columns[0].Visible = false;
            this.dgvMantenimientos.Columns[1].Visible = false;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
