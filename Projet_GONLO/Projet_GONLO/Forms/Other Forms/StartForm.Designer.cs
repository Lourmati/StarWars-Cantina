namespace Projet_GONLO
{
    partial class StartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnEllExit = new Projet_GONLO.ButtonEllipse();
            this.BtnEllStart = new Projet_GONLO.ButtonEllipse();
            this.BtnEllLoad = new Projet_GONLO.ButtonEllipse();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("SF Distant Galaxy Alternate", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(56, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(373, 65);
            this.label1.TabIndex = 0;
            this.label1.Text = "G.O.N.L.O\'S";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("SF Distant Galaxy Alternate", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(-1, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(502, 97);
            this.label2.TabIndex = 1;
            this.label2.Text = "CANTINA";
            // 
            // BtnEllExit
            // 
            this.BtnEllExit.BackColor = System.Drawing.Color.Transparent;
            this.BtnEllExit.BackgroundImage = global::Projet_GONLO.Properties.Resources.BlueSteelFaded2;
            this.BtnEllExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnEllExit.FlatAppearance.BorderSize = 0;
            this.BtnEllExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEllExit.Font = new System.Drawing.Font("SF Distant Galaxy Alternate", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEllExit.ForeColor = System.Drawing.Color.Gold;
            this.BtnEllExit.Location = new System.Drawing.Point(109, 526);
            this.BtnEllExit.Name = "BtnEllExit";
            this.BtnEllExit.Size = new System.Drawing.Size(275, 100);
            this.BtnEllExit.TabIndex = 3;
            this.BtnEllExit.Text = "exit";
            this.BtnEllExit.UseVisualStyleBackColor = false;
            this.BtnEllExit.Click += new System.EventHandler(this.BtnEllExit_Click);
            // 
            // BtnEllStart
            // 
            this.BtnEllStart.BackColor = System.Drawing.Color.Transparent;
            this.BtnEllStart.BackgroundImage = global::Projet_GONLO.Properties.Resources.BlueSteelFaded2;
            this.BtnEllStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnEllStart.FlatAppearance.BorderSize = 0;
            this.BtnEllStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEllStart.Font = new System.Drawing.Font("SF Distant Galaxy Alternate", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEllStart.ForeColor = System.Drawing.Color.Gold;
            this.BtnEllStart.Location = new System.Drawing.Point(109, 220);
            this.BtnEllStart.Name = "BtnEllStart";
            this.BtnEllStart.Size = new System.Drawing.Size(275, 100);
            this.BtnEllStart.TabIndex = 2;
            this.BtnEllStart.Text = "start";
            this.BtnEllStart.UseVisualStyleBackColor = false;
            this.BtnEllStart.Click += new System.EventHandler(this.BtnEllStart_Click);
            // 
            // BtnEllLoad
            // 
            this.BtnEllLoad.BackColor = System.Drawing.Color.Transparent;
            this.BtnEllLoad.BackgroundImage = global::Projet_GONLO.Properties.Resources.BlueSteelFaded2;
            this.BtnEllLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnEllLoad.FlatAppearance.BorderSize = 0;
            this.BtnEllLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEllLoad.Font = new System.Drawing.Font("SF Distant Galaxy Alternate", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEllLoad.ForeColor = System.Drawing.Color.Gold;
            this.BtnEllLoad.Location = new System.Drawing.Point(109, 372);
            this.BtnEllLoad.Name = "BtnEllLoad";
            this.BtnEllLoad.Size = new System.Drawing.Size(275, 100);
            this.BtnEllLoad.TabIndex = 4;
            this.BtnEllLoad.Text = "load";
            this.BtnEllLoad.UseVisualStyleBackColor = false;
            this.BtnEllLoad.Click += new System.EventHandler(this.BtnEllLoad_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Projet_GONLO.Properties.Resources.StarsBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(500, 674);
            this.Controls.Add(this.BtnEllLoad);
            this.Controls.Add(this.BtnEllExit);
            this.Controls.Add(this.BtnEllStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ButtonEllipse BtnEllStart;
        private ButtonEllipse BtnEllExit;
        private ButtonEllipse BtnEllLoad;
    }
}