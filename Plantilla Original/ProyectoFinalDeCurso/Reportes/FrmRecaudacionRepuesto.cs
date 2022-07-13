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
    public partial class FrmRecaudacionRepuesto : Form
    {
        public FrmRecaudacionRepuesto()
        {
            InitializeComponent();
        }

        private void FrmRecaudacionRepuesto_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DSServicioMantenimiento.Recaudacion_Repuesto' Puede moverla o quitarla según sea necesario.
            this.Recaudacion_RepuestoTableAdapter.Fill(this.DSServicioMantenimiento.Recaudacion_Repuesto);

            this.reportViewer1.RefreshReport();
        }
    }
}
