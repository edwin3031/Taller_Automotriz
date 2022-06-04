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

namespace ProyectoFinalDeCurso.Views
{
    public partial class FrmMostrarHistorial : Form
    {

        public int Id;
        public FrmMostrarHistorial(int id)
        {
            InitializeComponent();
            this.Id = id;
            Mostrar();
        }

        private void Mostrar()
        {
            this.dtHistorial.DataSource = CMantenimiento.Historial_De_Servicios(Id);
        }

        private void FrmMostrarHistorial_Load(object sender, EventArgs e)
        {
            Mostrar();
        }
    }
}
