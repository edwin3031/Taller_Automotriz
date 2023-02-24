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
using ProyectoFinalDeCurso.Reportes;

namespace ProyectoFinalDeCurso.Views
{
    public partial class Form2 : Form
    {
        public string rol;
        public string nombre;
        public int idEmpleado;
        public Form2()
        {
            InitializeComponent();
        }

        
        public Form2(string rol, string nombre)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.rol = rol;
            this.nombre = nombre;
            
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg,int wparam,int lparam);

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnRestaurar.Visible = true;
            btnMaximizar.Visible = false; 
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

     

        private void pnlBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle , 0x112, 0xf012,0);
        }

        private void pnlMenuVertical_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pnlContenedor_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        
        private void btnClientes_Click(object sender, EventArgs e)
        {
            pnlSubMenuCatalogo.Visible = false;
            AbrirHijo(new FrmCliente());
        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            pnlSubMenuCatalogo.Visible = false;
            AbrirHijo(new FrmServicio());
        }

        private void btnMecanico_Click(object sender, EventArgs e)
        {
            pnlSubMenuCatalogo.Visible = false;
            AbrirHijo(new FrmMecanico());
        }

        private void btnVehiculo_Click(object sender, EventArgs e)
        {
            pnlSubMenuCatalogo.Visible = false;
            AbrirHijo(new FrmVehiculo());
        }

        private void btnRepuesto_Click(object sender, EventArgs e)
        {
            pnlSubMenuCatalogo.Visible = false;
            AbrirHijo(new FrmRepuesto());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pnlSubMenuCatalogo.Visible==false)
            {
                pnlSubMenuCatalogo.Visible = true;
            }
            else{
                pnlSubMenuCatalogo.Visible = false;
            }
               

            
              
        }
        public void AbrirHijo(object FormHijo)
        {
            if (this.pnlSubMenuRecaudaciones.Controls.Count > 0)
            {
                this.pnlSubMenuRecaudaciones.Controls.RemoveAt(0);
            }
            Form fh = FormHijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.pnlSubMenuRecaudaciones.Controls.Add(fh);
            this.pnlSubMenuRecaudaciones.Tag = fh;
            fh.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.lblNombre.Text = this.nombre;
            this.lblRol.Text = this.rol;
            this.pnlSubMenuCatalogo.Visible = false;
            this.pnlSubMenuReportes.Visible = false;
            this.pnlSubMenuOperaciones.Visible = false;
            this.pnlSubMenuSeguridad.Visible = false;
            this.flReportesSubmenu.Visible = false;

            


           


            switch (this.rol)
            {

                case "Seguridad":
                   
                    break;

                case "Administrador":
                   
                    break;

                case "Mecánico":
                   
                    
                    break;
                case "Caja":
                   Habilitar(false);
                    break;

                default:
                    //this.flowLayoutPanel1.Visible = false;
                    break;
            }
        }

        private void Habilitar(bool valor)
        {

            this.btnAgregarUsuario.Visible = valor;
            this.btnCatalogos.Visible = !valor;
            this.btnReportes.Visible = valor;
            this.btnOperciones.Visible = !valor;
        }



        private void btnCerrarSecion_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmInicioSesion fc = new FrmInicioSesion();
            fc.ShowDialog();
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAsignarRepiuesto_Click(object sender, EventArgs e)
        {
            AbrirHijo(new FrmAsignarRepuestos());
















        }

        private void btnMantenimiento_Click(object sender, EventArgs e)
        {
            AbrirHijo(new FrmMantenimiento());


















        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            if (pnlSubMenuReportes.Visible == false)
            {
                pnlSubMenuReportes.Visible = true;
            }
            else
            {
                pnlSubMenuReportes.Visible = false;
            }

        }

        private void btnOperciones_Click(object sender, EventArgs e)
        {
            if (pnlSubMenuOperaciones.Visible == false)
            {
                pnlSubMenuOperaciones.Visible = true;
                //Botones que no funcionan
                this.btnAsignarRepiuesto.Visible = true;
            }
            else
            {
                pnlSubMenuOperaciones.Visible = false;
            }
        }

        private void btnSeguridad_Click(object sender, EventArgs e)
        {
            if (pnlSubMenuSeguridad.Visible == false)
            {
                pnlSubMenuSeguridad.Visible = true;
            }
            else
            {
                pnlSubMenuSeguridad.Visible = false;
            }

        }

        private void btnRecaudaciones_Click(object sender, EventArgs e)
        {

            if (flReportesSubmenu.Visible == false)
            {
                flReportesSubmenu.Visible = true;

                //Botones que no funcionan
                this.btnRecaudacionRepuesto.Visible = false;
                this.btnRecaudacionServicio.Visible = false;
            }
            else
            {
                flReportesSubmenu.Visible = false;
            }
           
          














        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            pnlSubMenuSeguridad.Visible = false;
            AbrirHijo(new FrmUsuario());

           













        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pnlBarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReporteRecaudacionMantenimiento_Click(object sender, EventArgs e)
        {

            AbrirHijo(new FrmReportMantenimiento());
        }

        private void btnRecaudacionRepuesto_Click(object sender, EventArgs e)
        {
            AbrirHijo(new FrmRecaudacionServicio());
        }

        private void btnRecaudacionServicio_Click(object sender, EventArgs e)
        {
            AbrirHijo(new FrmRecaudacionRepuesto());
        }
    }
}
