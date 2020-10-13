namespace Projet_GONLO
{
    partial class LoadForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadForm));
            this.label1 = new System.Windows.Forms.Label();
            this.TBoxName = new Projet_GONLO.textBox();
            this.BtnEllLoad = new Projet_GONLO.ButtonEllipse();
            this.BtnEllBack = new Projet_GONLO.ButtonEllipse();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnEllDelete = new Projet_GONLO.ButtonEllipse();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("SF Distant Galaxy Alternate", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(663, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "Write down your character\'s name";
            // 
            // TBoxName
            // 
            this.TBoxName.Font = new System.Drawing.Font("SF Distant Galaxy Alternate", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBoxName.Location = new System.Drawing.Point(188, 140);
            this.TBoxName.Name = "TBoxName";
            this.TBoxName.Size = new System.Drawing.Size(300, 28);
            this.TBoxName.TabIndex = 3;
            this.TBoxName.TextChanged += new System.EventHandler(this.TBoxName_TextChanged);
            // 
            // BtnEllLoad
            // 
            this.BtnEllLoad.BackColor = System.Drawing.Color.Transparent;
            this.BtnEllLoad.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnEllLoad.BackgroundImage")));
            this.BtnEllLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnEllLoad.FlatAppearance.BorderSize = 0;
            this.BtnEllLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEllLoad.Font = new System.Drawing.Font("SF Distant Galaxy Alternate", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEllLoad.ForeColor = System.Drawing.Color.Gold;
            this.BtnEllLoad.Location = new System.Drawing.Point(460, 220);
            this.BtnEllLoad.Name = "BtnEllLoad";
            this.BtnEllLoad.Size = new System.Drawing.Size(175, 75);
            this.BtnEllLoad.TabIndex = 4;
            this.BtnEllLoad.Text = "Load";
            this.BtnEllLoad.UseVisualStyleBackColor = false;
            this.BtnEllLoad.Click += new System.EventHandler(this.BtnEllLoad_Click);
            // 
            // BtnEllBack
            // 
            this.BtnEllBack.BackColor = System.Drawing.Color.Transparent;
            this.BtnEllBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnEllBack.BackgroundImage")));
            this.BtnEllBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnEllBack.FlatAppearance.BorderSize = 0;
            this.BtnEllBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEllBack.Font = new System.Drawing.Font("SF Distant Galaxy Alternate", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEllBack.ForeColor = System.Drawing.Color.Gold;
            this.BtnEllBack.Location = new System.Drawing.Point(50, 220);
            this.BtnEllBack.Name = "BtnEllBack";
            this.BtnEllBack.Size = new System.Drawing.Size(175, 75);
            this.BtnEllBack.TabIndex = 5;
            this.BtnEllBack.Text = "Back";
            this.BtnEllBack.UseVisualStyleBackColor = false;
            this.BtnEllBack.Click += new System.EventHandler(this.BtnEllBack_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("SF Distant Galaxy Alternate", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(160, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(357, 30);
            this.label2.TabIndex = 6;
            this.label2.Text = "to load your game";
            // 
            // BtnEllDelete
            // 
            this.BtnEllDelete.BackColor = System.Drawing.Color.Transparent;
            this.BtnEllDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnEllDelete.BackgroundImage")));
            this.BtnEllDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnEllDelete.FlatAppearance.BorderSize = 0;
            this.BtnEllDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEllDelete.Font = new System.Drawing.Font("SF Distant Galaxy Alternate", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEllDelete.ForeColor = System.Drawing.Color.Gold;
            this.BtnEllDelete.Location = new System.Drawing.Point(253, 220);
            this.BtnEllDelete.Name = "BtnEllDelete";
            this.BtnEllDelete.Size = new System.Drawing.Size(175, 75);
            this.BtnEllDelete.TabIndex = 7;
            this.BtnEllDelete.Text = "delete";
            this.BtnEllDelete.UseVisualStyleBackColor = false;
            this.BtnEllDelete.Click += new System.EventHandler(this.BtnEllDelete_Click);
            // 
            // LoadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Projet_GONLO.Properties.Resources.StarsBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(687, 344);
            this.Controls.Add(this.BtnEllDelete);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnEllBack);
            this.Controls.Add(this.BtnEllLoad);
            this.Controls.Add(this.TBoxName);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoadForm";
            this.Load += new System.EventHandler(this.LoadForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private textBox TBoxName;
        private ButtonEllipse BtnEllLoad;
        private ButtonEllipse BtnEllBack;
        private System.Windows.Forms.Label label2;
        private ButtonEllipse BtnEllDelete;
    }
}