
namespace ProyectoFinalDeCurso.Reportes
{
    partial class FrmRecaudacionServicio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DSServicioMantenimiento = new ProyectoFinalDeCurso.Reportes.DSServicioMantenimiento();
            this.Recaudacion_ServiciosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Recaudacion_ServiciosTableAdapter = new ProyectoFinalDeCurso.Reportes.DSServicioMantenimientoTableAdapters.Recaudacion_ServiciosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DSServicioMantenimiento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Recaudacion_ServiciosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSServicio";
            reportDataSource1.Value = this.Recaudacion_ServiciosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ProyectoFinalDeCurso.Reportes.Servicio.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // DSServicioMantenimiento
            // 
            this.DSServicioMantenimiento.DataSetName = "DSServicioMantenimiento";
            this.DSServicioMantenimiento.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Recaudacion_ServiciosBindingSource
            // 
            this.Recaudacion_ServiciosBindingSource.DataMember = "Recaudacion_Servicios";
            this.Recaudacion_ServiciosBindingSource.DataSource = this.DSServicioMantenimiento;
            // 
            // Recaudacion_ServiciosTableAdapter
            // 
            this.Recaudacion_ServiciosTableAdapter.ClearBeforeFill = true;
            // 
            // FrmRecaudacionServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmRecaudacionServicio";
            this.Text = "FrmRecaudacionServicio";
            this.Load += new System.EventHandler(this.FrmRecaudacionServicio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DSServicioMantenimiento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Recaudacion_ServiciosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Recaudacion_ServiciosBindingSource;
        private DSServicioMantenimiento DSServicioMantenimiento;
        private DSServicioMantenimientoTableAdapters.Recaudacion_ServiciosTableAdapter Recaudacion_ServiciosTableAdapter;
    }
}