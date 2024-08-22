namespace SeaBattle
{
    partial class SetShipForm
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
            this.pShip = new System.Windows.Forms.Panel();
            this.bRotate = new System.Windows.Forms.Button();
            this.pbShipTemplate = new System.Windows.Forms.PictureBox();
            this.ucMap1 = new SeaBattle.ucMap();
            this.pShip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbShipTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // pShip
            // 
            this.pShip.Controls.Add(this.pbShipTemplate);
            this.pShip.Controls.Add(this.bRotate);
            this.pShip.Location = new System.Drawing.Point(0, 0);
            this.pShip.Name = "pShip";
            this.pShip.Size = new System.Drawing.Size(345, 341);
            this.pShip.TabIndex = 0;
            // 
            // bRotate
            // 
            this.bRotate.Location = new System.Drawing.Point(135, 306);
            this.bRotate.Name = "bRotate";
            this.bRotate.Size = new System.Drawing.Size(75, 23);
            this.bRotate.TabIndex = 0;
            this.bRotate.Text = "Поворот";
            this.bRotate.UseVisualStyleBackColor = true;
            this.bRotate.Click += new System.EventHandler(this.bRotate_Click);
            // 
            // pbShipTemplate
            // 
            this.pbShipTemplate.Location = new System.Drawing.Point(219, 317);
            this.pbShipTemplate.Name = "pbShipTemplate";
            this.pbShipTemplate.Size = new System.Drawing.Size(100, 50);
            this.pbShipTemplate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbShipTemplate.TabIndex = 1;
            this.pbShipTemplate.TabStop = false;
            this.pbShipTemplate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbShipTemplate_MouseDown);
            this.pbShipTemplate.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbShipTemplate_MouseMove);
            this.pbShipTemplate.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbShipTemplate_MouseUp);
            // 
            // ucMap1
            // 
            this.ucMap1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ucMap1.Location = new System.Drawing.Point(350, 0);
            this.ucMap1.Name = "ucMap1";
            this.ucMap1.Size = new System.Drawing.Size(345, 341);
            this.ucMap1.TabIndex = 1;
            // 
            // SetShipForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 341);
            this.Controls.Add(this.ucMap1);
            this.Controls.Add(this.pShip);
            this.Name = "SetShipForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SetShipForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SetShipForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SetShipForm_FormClosed);
            this.Load += new System.EventHandler(this.SetShipForm_Load);
            this.Shown += new System.EventHandler(this.SetShipForm_Shown);
            this.pShip.ResumeLayout(false);
            this.pShip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbShipTemplate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pShip;
        private ucMap ucMap1;
        private System.Windows.Forms.Button bRotate;
        private System.Windows.Forms.PictureBox pbShipTemplate;
    }
}