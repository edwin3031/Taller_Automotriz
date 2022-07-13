
namespace ProyectoFinalDeCurso.Reportes
{
    partial class FrmRecaudacionMantenimiento
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
            this.Recaudacion_Año_MesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DSMantenimientos = new ProyectoFinalDeCurso.Reportes.DSMantenimientos();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rpMantenimiento = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Recaudacion_MantenimientosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSServicioMantenimiento = new ProyectoFinalDeCurso.Reportes.DSServicioMantenimiento();
            this.Recaudacion_MantenimientosTableAdapter = new ProyectoFinalDeCurso.Reportes.DSServicioMantenimientoTableAdapters.Recaudacion_MantenimientosTableAdapter();
            this.Recaudacion_Año_MesTableAdapter = new ProyectoFinalDeCurso.Reportes.DSMantenimientosTableAdapters.Recaudacion_Año_MesTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.Mes = new System.Windows.Forms.Label();
            this.txtAño = new System.Windows.Forms.TextBox();
            this.txtMes = new System.Windows.Forms.TextBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Recaudacion_Año_MesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSMantenimientos)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Recaudacion_MantenimientosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSServicioMantenimiento)).BeginInit();
            this.SuspendLayout();
            // 
            // Recaudacion_Año_MesBindingSource
            // 
            this.Recaudacion_Año_MesBindingSource.DataMember = "Recaudacion_Año_Mes";
            this.Recaudacion_Año_MesBindingSource.DataSource = this.DSMantenimientos;
            // 
            // DSMantenimientos
            // 
            this.DSMantenimientos.DataSetName = "DSMantenimientos";
            this.DSMantenimientos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnImprimir);
            this.panel1.Controls.Add(this.txtMes);
            this.panel1.Controls.Add(this.txtAño);
            this.panel1.Controls.Add(this.Mes);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 112);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rpMantenimiento);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 112);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1200, 580);
            this.panel2.TabIndex = 1;
            // 
            // rpMantenimiento
            // 
            this.rpMantenimiento.AutoSize = true;
            this.rpMantenimiento.BackColor = System.Drawing.Color.Gainsboro;
            this.rpMantenimiento.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Recaudacion_Año_MesBindingSource;
            this.rpMantenimiento.LocalReport.DataSources.Add(reportDataSource1);
            this.rpMantenimiento.LocalReport.ReportEmbeddedResource = "ProyectoFinalDeCurso.Reportes.ReportMantenimientos.rdlc";
            this.rpMantenimiento.Location = new System.Drawing.Point(0, 0);
            this.rpMantenimiento.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rpMantenimiento.Name = "rpMantenimiento";
            this.rpMantenimiento.ServerReport.BearerToken = null;
            this.rpMantenimiento.Size = new System.Drawing.Size(1200, 580);
            this.rpMantenimiento.TabIndex = 0;
            // 
            // Recaudacion_MantenimientosBindingSource
            // 
            this.Recaudacion_MantenimientosBindingSource.DataMember = "Recaudacion_Mantenimientos";
            this.Recaudacion_MantenimientosBindingSource.DataSource = this.dSServicioMantenimiento;
            // 
            // dSServicioMantenimiento
            // 
            this.dSServicioMantenimiento.DataSetName = "DSServicioMantenimiento";
            this.dSServicioMantenimiento.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Recaudacion_MantenimientosTableAdapter
            // 
            this.Recaudacion_MantenimientosTableAdapter.ClearBeforeFill = true;
            // 
            // Recaudacion_Año_MesTableAdapter
            // 
            this.Recaudacion_Año_MesTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Año:";
            // 
            // Mes
            // 
            this.Mes.AutoSize = true;
            this.Mes.Font = new System.Drawing.Font("Segoe UI Black", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mes.Location = new System.Drawing.Point(551, 27);
            this.Mes.Name = "Mes";
            this.Mes.Size = new System.Drawing.Size(84, 38);
            this.Mes.TabIndex = 1;
            this.Mes.Text = "Mes:";
            // 
            // txtAño
            // 
            this.txtAño.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAño.Location = new System.Drawing.Point(154, 27);
            this.txtAño.Name = "txtAño";
            this.txtAño.Size = new System.Drawing.Size(175, 35);
            this.txtAño.TabIndex = 2;
            // 
            // txtMes
            // 
            this.txtMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMes.Location = new System.Drawing.Point(674, 27);
            this.txtMes.Name = "txtMes";
            this.txtMes.Size = new System.Drawing.Size(175, 35);
            this.txtMes.TabIndex = 3;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnImprimir.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnImprimir.FlatAppearance.BorderSize = 2;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Location = new System.Drawing.Point(952, 18);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(172, 50);
            this.btnImprimir.TabIndex = 4;
            this.btnImprimir.Text = "Calcular";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // FrmRecaudacionMantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmRecaudacionMantenimiento";
            this.Text = "FrmRecaudacionMantenimiento";
            this.Load += new System.EventHandler(this.FrmRecaudacionMantenimiento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Recaudacion_Año_MesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSMantenimientos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Recaudacion_MantenimientosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSServicioMantenimiento)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Microsoft.Reporting.WinForms.ReportViewer rpMantenimiento;
        private DSServicioMantenimiento dSServicioMantenimiento;
        private System.Windows.Forms.BindingSource Recaudacion_MantenimientosBindingSource;
        private DSServicioMantenimientoTableAdapters.Recaudacion_MantenimientosTableAdapter Recaudacion_MantenimientosTableAdapter;
        private System.Windows.Forms.BindingSource Recaudacion_Año_MesBindingSource;
        private DSMantenimientos DSMantenimientos;
        private DSMantenimientosTableAdapters.Recaudacion_Año_MesTableAdapter Recaudacion_Año_MesTableAdapter;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.TextBox txtMes;
        private System.Windows.Forms.TextBox txtAño;
        private System.Windows.Forms.Label Mes;
        private System.Windows.Forms.Label label1;
    }
}