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
    public partial class FrmSelecionarServicio : Form
    {

        private FrmMantenimiento frmMantenimiento;
        public static int idServicio;
        public static string Tipo;
        public static string descripcion;
        public static decimal precio;


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        public FrmSelecionarServicio(FrmMantenimiento frmMantenimiento)
        {
            InitializeComponent();
            this.frmMantenimiento = frmMantenimiento;
            Mostrar();
        }

      

        public void Mostrar()
        {
            this.dtServicio.DataSource = CServicio.Mostrar_Servicio();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int r;
            r = dtServicio.SelectedRows.Count;


            if (r > 0)
            {
                DataGridViewRow dr = dtServicio.SelectedRows[0];
                idServicio = (Convert.ToInt32((dr.Cells[0].Value)));
                descripcion = (dr.Cells[1].Value.ToString());
                precio = Convert.ToDecimal((dr.Cells[2].Value.ToString()));
                Tipo = (dr.Cells[3].Value.ToString());
                frmMantenimiento.obtenerDatosServicio(idServicio, descripcion,precio,Tipo);
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una Fila antes", "Servicio de mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.dtServicio.DataSource = CServicio.Buscar_Servicio(this.textBox1.Text);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
