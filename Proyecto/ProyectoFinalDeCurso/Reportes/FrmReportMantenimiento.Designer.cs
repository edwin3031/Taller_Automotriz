
namespace ProyectoFinalDeCurso.Reportes
{
    partial class FrmReportMantenimiento
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
            this.aiolbl = new System.Windows.Forms.Label();
            this.aniotxt = new System.Windows.Forms.TextBox();
            this.meslbl = new System.Windows.Forms.Label();
            this.mestxt = new System.Windows.Forms.TextBox();
            this.calcularbtn = new System.Windows.Forms.Button();
            this.Recaudacion_MantenimientosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DSTMantenimientoxsd = new ProyectoFinalDeCurso.Reportes.DSTMantenimientoxsd();
            this.Recaudacion_MantenimientosTableAdapter = new ProyectoFinalDeCurso.Reportes.DSTMantenimientoxsdTableAdapters.Recaudacion_MantenimientosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Recaudacion_MantenimientosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSTMantenimientoxsd)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Recaudacion_MantenimientosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ProyectoFinalDeCurso.Reportes.ReportMantenimiento.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 111);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(776, 327);
            this.reportViewer1.TabIndex = 0;
            // 
            // aiolbl
            // 
            this.aiolbl.AutoSize = true;
            this.aiolbl.Location = new System.Drawing.Point(50, 43);
            this.aiolbl.Name = "aiolbl";
            this.aiolbl.Size = new System.Drawing.Size(38, 17);
            this.aiolbl.TabIndex = 1;
            this.aiolbl.Text = "AÑO";
            this.aiolbl.Click += new System.EventHandler(this.FrmReportMantenimiento_Load);
            // 
            // aniotxt
            // 
            this.aniotxt.Location = new System.Drawing.Point(157, 40);
            this.aniotxt.Name = "aniotxt";
            this.aniotxt.Size = new System.Drawing.Size(100, 22);
            this.aniotxt.TabIndex = 2;
            // 
            // meslbl
            // 
            this.meslbl.AutoSize = true;
            this.meslbl.Location = new System.Drawing.Point(398, 43);
            this.meslbl.Name = "meslbl";
            this.meslbl.Size = new System.Drawing.Size(34, 17);
            this.meslbl.TabIndex = 3;
            this.meslbl.Text = "Mes";
            // 
            // mestxt
            // 
            this.mestxt.Location = new System.Drawing.Point(473, 43);
            this.mestxt.Name = "mestxt";
            this.mestxt.Size = new System.Drawing.Size(100, 22);
            this.mestxt.TabIndex = 4;
            // 
            // calcularbtn
            // 
            this.calcularbtn.Location = new System.Drawing.Point(646, 37);
            this.calcularbtn.Name = "calcularbtn";
            this.calcularbtn.Size = new System.Drawing.Size(75, 23);
            this.calcularbtn.TabIndex = 5;
            this.calcularbtn.Text = "Calcular";
            this.calcularbtn.UseVisualStyleBackColor = true;
            this.calcularbtn.Click += new System.EventHandler(this.calcularbtn_Click);
            // 
            // Recaudacion_MantenimientosBindingSource
            // 
            this.Recaudacion_MantenimientosBindingSource.DataMember = "Recaudacion_Mantenimientos";
            this.Recaudacion_MantenimientosBindingSource.DataSource = this.DSTMantenimientoxsd;
            // 
            // DSTMantenimientoxsd
            // 
            this.DSTMantenimientoxsd.DataSetName = "DSTMantenimientoxsd";
            this.DSTMantenimientoxsd.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Recaudacion_MantenimientosTableAdapter
            // 
            this.Recaudacion_MantenimientosTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReportMantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.calcularbtn);
            this.Controls.Add(this.mestxt);
            this.Controls.Add(this.meslbl);
            this.Controls.Add(this.aniotxt);
            this.Controls.Add(this.aiolbl);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmReportMantenimiento";
            this.Text = "FrmReportMantenimiento";
            this.Load += new System.EventHandler(this.FrmReportMantenimiento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Recaudacion_MantenimientosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSTMantenimientoxsd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label aiolbl;
        private System.Windows.Forms.TextBox aniotxt;
        private System.Windows.Forms.Label meslbl;
        private System.Windows.Forms.TextBox mestxt;
        private System.Windows.Forms.BindingSource Recaudacion_MantenimientosBindingSource;
        private DSTMantenimientoxsd DSTMantenimientoxsd;
        private DSTMantenimientoxsdTableAdapters.Recaudacion_MantenimientosTableAdapter Recaudacion_MantenimientosTableAdapter;
        private System.Windows.Forms.Button calcularbtn;
    }
}