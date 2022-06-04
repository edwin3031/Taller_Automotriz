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
    public partial class FrmRecaudacionMantenimiento : Form
    {
        public FrmRecaudacionMantenimiento()
        {
            InitializeComponent();
        }

        private void FrmRecaudacionMantenimiento_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DSMantenimientos.Recaudacion_Año_Mes' Puede moverla o quitarla según sea necesario.
            this.Recaudacion_Año_MesTableAdapter.Fill(this.DSMantenimientos.Recaudacion_Año_Mes,2020,12);
            // TODO: esta línea de código carga datos en la tabla 'dSServicioMantenimiento.Recaudacion_Mantenimientos' Puede moverla o quitarla según sea necesario.
            this.rpMantenimiento.RefreshReport();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (this.Recaudacion_Año_MesTableAdapter.Fill(this.DSMantenimientos.Recaudacion_Año_Mes, Convert.ToInt32(txtAño.Text), Convert.ToInt32(txtMes.Text)) != 1)
            {
                MessageBox.Show("No existe la fecha ingresada","Reporte de Mantenimiento",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.rpMantenimiento.RefreshReport();
        }
    }
}
