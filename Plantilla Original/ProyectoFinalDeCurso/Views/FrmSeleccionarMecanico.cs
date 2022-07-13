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
    public partial class FrmSeleccionarMecanico : Form
    {
        private FrmMantenimiento frmMantenimiento;
        public static int idMecanico;
        public static string nombre;
        public static string especialidad;
        public static string telefono;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        public FrmSeleccionarMecanico(FrmMantenimiento frmMantenimiento)
        {
            InitializeComponent();
            this.frmMantenimiento = frmMantenimiento;
            Mostrar();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private  void Mostrar()
        {
            this.dtMecanico.DataSource = CMecanico.Mostrar_Mecanico();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int r;
            r = dtMecanico.SelectedRows.Count;


            if (r > 0)
            {
                DataGridViewRow dr = dtMecanico.SelectedRows[0];
                idMecanico = (Convert.ToInt32((dr.Cells[0].Value)));
                nombre = (dr.Cells[1].Value.ToString()+" "+ dr.Cells[2].Value.ToString() + " " +
                    dr.Cells[3].Value.ToString() + " " + dr.Cells[4].Value.ToString());
                especialidad = (dr.Cells[5].Value.ToString());
                telefono = (dr.Cells[6].Value.ToString());
                frmMantenimiento.obtenerDatosMecanico(idMecanico, nombre, especialidad, telefono);
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una Fila antes", "Servicio de mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.dtMecanico.DataSource = CMecanico.Buscar_Mecanico(this.textBox1.Text);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
