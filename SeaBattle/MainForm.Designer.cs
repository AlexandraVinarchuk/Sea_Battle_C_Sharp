namespace SeaBattle
{
    partial class frmSeaBattle
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.играToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStatistics = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ucMapMy = new SeaBattle.ucMap();
            this.ucMapEnemy = new SeaBattle.ucMap();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.играToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(719, 32);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStripMain";
            // 
            // играToolStripMenuItem
            // 
            this.играToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNew,
            this.tsmiStatistics,
            this.tsmiExit});
            this.играToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.играToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.играToolStripMenuItem.Name = "играToolStripMenuItem";
            this.играToolStripMenuItem.Size = new System.Drawing.Size(74, 28);
            this.играToolStripMenuItem.Text = "Меню";
            // 
            // tsmiNew
            // 
            this.tsmiNew.Name = "tsmiNew";
            this.tsmiNew.Size = new System.Drawing.Size(247, 28);
            this.tsmiNew.Text = "Новая игра";
            this.tsmiNew.Click += new System.EventHandler(this.tsmiNew_Click);
            // 
            // tsmiStatistics
            // 
            this.tsmiStatistics.Name = "tsmiStatistics";
            this.tsmiStatistics.Size = new System.Drawing.Size(247, 28);
            this.tsmiStatistics.Text = "Таблица рекордов";
            this.tsmiStatistics.Click += new System.EventHandler(this.tsmiStatistics_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(247, 28);
            this.tsmiExit.Text = "Выход";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // ucMapMy
            // 
            this.ucMapMy.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ucMapMy.Location = new System.Drawing.Point(363, 37);
            this.ucMapMy.Name = "ucMapMy";
            this.ucMapMy.Size = new System.Drawing.Size(345, 400);
            this.ucMapMy.TabIndex = 1;
            // 
            // ucMapEnemy
            // 
            this.ucMapEnemy.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ucMapEnemy.Location = new System.Drawing.Point(13, 37);
            this.ucMapEnemy.Name = "ucMapEnemy";
            this.ucMapEnemy.Size = new System.Drawing.Size(345, 400);
            this.ucMapEnemy.TabIndex = 0;
            this.ucMapEnemy.Click += new System.EventHandler(this.ucMap1_Click);
            // 
            // frmSeaBattle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 448);
            this.Controls.Add(this.ucMapMy);
            this.Controls.Add(this.ucMapEnemy);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmSeaBattle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Морской бой";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucMap ucMapEnemy;
        private ucMap ucMapMy;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem играToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiNew;
        private System.Windows.Forms.ToolStripMenuItem tsmiStatistics;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
    }
}

