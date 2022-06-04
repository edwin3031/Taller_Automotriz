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
    public partial class FrmSeleccionarCliente : Form
    {
        private FrmVehiculo frmVehiculo;
        public static int id;
        public static string nombre;
        public FrmSeleccionarCliente(FrmVehiculo frmVehiculo)
        {
            InitializeComponent();

            Mostrar();
            this.frmVehiculo = frmVehiculo;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Mostrar()
        {
            this.dtClientes.DataSource = CCliente.Mostrar_Clientes();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.dtClientes.DataSource = CCliente.Buscar_Clientes(this.textBox1.Text);

        }

        private void FrmSeleccionarCliente_Load(object sender, EventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void FrmSeleccionarCliente_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }



        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int r ;
            r = dtClientes.SelectedRows.Count;


            if (r>0 )
            {
                DataGridViewRow dr = dtClientes.SelectedRows[0];
                nombre = (dr.Cells[1].Value).ToString() + " " + (dr.Cells[2].Value).ToString() + " " + (dr.Cells[3].Value).ToString() + " " + (dr.Cells[4].Value).ToString();
                id = Convert.ToInt32((dr.Cells[0].Value));
                frmVehiculo.setTxTNombre(nombre,id);
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una Fila antes", "Servicio de mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }


        }
    }
}
