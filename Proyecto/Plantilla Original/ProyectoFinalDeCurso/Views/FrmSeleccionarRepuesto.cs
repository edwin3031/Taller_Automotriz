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
    public partial class FrmSeleccionarRepuesto : Form
    {
        private FrmAsignarRepuestos frmAsignarRepuestos;
        public static int idRespuesto;
        public static string descripcion;
        public static string Marca;
        public static string Modelo;
        public static decimal precio;


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        
        public FrmSeleccionarRepuesto(FrmAsignarRepuestos frmAsignarRepuestos)
        {
            InitializeComponent();
            this.frmAsignarRepuestos = frmAsignarRepuestos;
            Mostrar();
        }



        public void Mostrar()
        {
            this.dtServicio.DataSource = CRepuesto.Mostrar_Repuesto();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int r;
            r = dtServicio.SelectedRows.Count;


            if (r > 0)
            {
                DataGridViewRow dr = dtServicio.SelectedRows[0];
                idRespuesto = (Convert.ToInt32((dr.Cells[0].Value)));
                descripcion = (dr.Cells[1].Value.ToString());
                Marca = dr.Cells[2].Value.ToString();
                Modelo = dr.Cells[3].Value.ToString();
                precio = Convert.ToDecimal((dr.Cells[4].Value.ToString()));
                frmAsignarRepuestos.getDatos(idRespuesto, descripcion, Marca, Modelo,precio);
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
            this.dtServicio.DataSource = CRepuesto.Buscar_Repuesto(this.textBox1.Text);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
