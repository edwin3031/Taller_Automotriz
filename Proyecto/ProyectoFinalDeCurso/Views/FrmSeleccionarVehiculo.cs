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
    public partial class FrmSeleccionarVehiculo : Form
    {

        private FrmMantenimiento frmMantenimiento;
        public static int idVehiculo;
        public static string nombreCliente;
        public static string marca;
        public static string modelo;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public FrmSeleccionarVehiculo(FrmMantenimiento frmMantenimiento)
        {
            InitializeComponent();
            this.frmMantenimiento = frmMantenimiento;
            Mostrar();
        }
        public FrmSeleccionarVehiculo()
        {
            InitializeComponent();
           
            Mostrar();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int r;
            r = dtVehiculos.SelectedRows.Count;


            if (r > 0)
            {
                DataGridViewRow dr = dtVehiculos.SelectedRows[0];
                idVehiculo = (Convert.ToInt32((dr.Cells[0].Value)));
                Console.WriteLine(idVehiculo);
                nombreCliente = (dr.Cells[1].Value.ToString());
                marca= (dr.Cells[2].Value.ToString());
                modelo = (dr.Cells[3].Value.ToString());
                frmMantenimiento.obtenerDatosVehiculos(idVehiculo,nombreCliente,marca,modelo);
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una Fila antes", "Servicio de mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        public void Mostrar()
        {
            this.dtVehiculos.DataSource = CVehiculo.Mostrar_Vehiculo();
            this.dtVehiculos.Columns[0].Visible = false;
            this.dtVehiculos.Columns[1].Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.dtVehiculos.DataSource = CVehiculo.Buscar_Vehiculo(this.textBox1.Text);

        }

        private void FrmSeleccionarVehiculo_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
