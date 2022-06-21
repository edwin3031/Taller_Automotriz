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
using System.Runtime.InteropServices;

namespace ProyectoFinalDeCurso.Views
{
    public partial class FrmInicioSesion : Form
    {

        public static int idEmpleado;
        public static string nombre;
        public static string rol;
        public FrmInicioSesion()
        {
            InitializeComponent();
           
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        private void acceder()
        {
            DataTable dato;
            dato = CUsuario.Validar_Acceso(this.txtUsuario.Text, this.txtContraseña.Text);

            if (dato != null)
            {

                if (dato.Rows.Count > 0)
                {
                    DataRow dr;
                    dr = dato.Rows[0];

                    if (dr[0].ToString() == "Acceso Exitoso")
                    {

                        rol = dato.Rows[0][2].ToString();
                        nombre = dato.Rows[0][1].ToString();
                  



                        MessageBox.Show($"Bienvenido al Sistema\n{nombre} ", "Servicio de Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Form2 fc = new Form2(rol, nombre);
                        fc.Show();
                        fc.FormClosed += logout;
                        this.Hide();
                        
                   
                        
                    }
                    else
                    {
                        MessageBox.Show("Acceso Denegado al Sistema de Reservaciones", "Sistema de Reservas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtUsuario.Text = string.Empty;
                        this.txtContraseña.Text = string.Empty;
                        this.txtUsuario.Focus();
                    }
                }
            }
            else
                MessageBox.Show("No hay conexión al servidor", "Servicio de Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }



        private void btnAcceder_Click(object sender, EventArgs e)
        {
            acceder();
         }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmInicioSesion_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

       

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text=="USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray;
            }

        }



        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.DimGray;
            }

        }
        
        private void ptExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "CONTRASEÑA")
            {
                txtContraseña.Text = "";
                txtContraseña.ForeColor = Color.LightGray; 
                txtContraseña.UseSystemPasswordChar = true;

            }
           
        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "")
            {
                txtContraseña.Text = "CONTRASEÑA";
                txtContraseña.ForeColor = Color.DimGray;
                txtContraseña.UseSystemPasswordChar =false;

            }
        }

        private void ptMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FrmInicioSesion_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmInicioSesion_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                acceder();
            }
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void logout(object sennder, FormClosedEventArgs e)
        {
            txtContraseña.Clear();
            txtUsuario.Clear();
            this.Show();
            txtUsuario.Focus();


        }
    }
        
    
}
