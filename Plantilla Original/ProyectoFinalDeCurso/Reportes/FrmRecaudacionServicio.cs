using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalDeCurso.Reportes
{
    public partial class FrmRecaudacionServicio : Form
    {
        public FrmRecaudacionServicio()
        {
            InitializeComponent();
        }

        private void FrmRecaudacionServicio_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DSServicioMantenimiento.Recaudacion_Servicios' Puede moverla o quitarla según sea necesario.
            this.Recaudacion_ServiciosTableAdapter.Fill(this.DSServicioMantenimiento.Recaudacion_Servicios);

            this.reportViewer1.RefreshReport();
        }
    }
}
