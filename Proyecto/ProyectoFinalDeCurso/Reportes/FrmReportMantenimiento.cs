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
    public partial class FrmReportMantenimiento : Form
    {
        public FrmReportMantenimiento()
        {
            InitializeComponent();
        }

        private void FrmReportMantenimiento_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DSTMantenimientoxsd.Recaudacion_Mantenimientos' Puede moverla o quitarla según sea necesario.
            this.Recaudacion_MantenimientosTableAdapter.Fill(this.DSTMantenimientoxsd.Recaudacion_Mantenimientos, 2020, 11);

            this.reportViewer1.RefreshReport();
        }

        private void calcularbtn_Click(object sender, EventArgs e)
        {
            if (this.Recaudacion_MantenimientosTableAdapter.Fill(this.DSTMantenimientoxsd.Recaudacion_Mantenimientos, Convert.ToInt32(aniotxt.Text), Convert.ToInt32(mestxt.Text))!= 1)
            {
                MessageBox.Show("No existe la fecha ingresada", "Reporte de Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.reportViewer1.RefreshReport();
        }
    }
}
