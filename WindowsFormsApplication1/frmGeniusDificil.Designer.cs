namespace WindowsFormsApplication1
{
    partial class frmGeniusDificil
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbImagem = new System.Windows.Forms.PictureBox();
            this.tmrDispara = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagem)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pbImagem);
            this.panel1.Location = new System.Drawing.Point(5, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(546, 546);
            this.panel1.TabIndex = 6;
            // 
            // pbImagem
            // 
            this.pbImagem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbImagem.ErrorImage = null;
            this.pbImagem.InitialImage = null;
            this.pbImagem.Location = new System.Drawing.Point(17, 18);
            this.pbImagem.Name = "pbImagem";
            this.pbImagem.Size = new System.Drawing.Size(500, 500);
            this.pbImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbImagem.TabIndex = 0;
            this.pbImagem.TabStop = false;
            this.pbImagem.Click += new System.EventHandler(this.pbImagem_Click);
            this.pbImagem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbImagem_MouseDown);
            this.pbImagem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbImagem_MouseUp);
            // 
            // tmrDispara
            // 
            this.tmrDispara.Interval = 500;
            this.tmrDispara.Tick += new System.EventHandler(this.tmrDispara_Tick);
            // 
            // frmGeniusDificil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 536);
            this.Controls.Add(this.panel1);
            this.Name = "frmGeniusDificil";
            this.Text = "Genius DIFICIL";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbImagem;
        private System.Windows.Forms.Timer tmrDispara;
    }
}

