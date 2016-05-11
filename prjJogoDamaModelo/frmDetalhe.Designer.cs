namespace prjJogoDamaModelo
{
    partial class frmDetalhe
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
            this.lstBranco = new System.Windows.Forms.ListBox();
            this.lstPreto = new System.Windows.Forms.ListBox();
            this.lstTabuleiro = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstBranco
            // 
            this.lstBranco.FormattingEnabled = true;
            this.lstBranco.ItemHeight = 16;
            this.lstBranco.Location = new System.Drawing.Point(37, 52);
            this.lstBranco.Name = "lstBranco";
            this.lstBranco.Size = new System.Drawing.Size(120, 484);
            this.lstBranco.TabIndex = 0;
            // 
            // lstPreto
            // 
            this.lstPreto.FormattingEnabled = true;
            this.lstPreto.ItemHeight = 16;
            this.lstPreto.Location = new System.Drawing.Point(178, 52);
            this.lstPreto.Name = "lstPreto";
            this.lstPreto.Size = new System.Drawing.Size(120, 484);
            this.lstPreto.TabIndex = 1;
            // 
            // lstTabuleiro
            // 
            this.lstTabuleiro.FormattingEnabled = true;
            this.lstTabuleiro.ItemHeight = 16;
            this.lstTabuleiro.Location = new System.Drawing.Point(330, 52);
            this.lstTabuleiro.Name = "lstTabuleiro";
            this.lstTabuleiro.Size = new System.Drawing.Size(120, 484);
            this.lstTabuleiro.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Lista Branco";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Lista Preto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(327, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Lista Tabuleiro";
            // 
            // frmDetalhe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 580);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstTabuleiro);
            this.Controls.Add(this.lstPreto);
            this.Controls.Add(this.lstBranco);
            this.Name = "frmDetalhe";
            this.Text = "frmDetalhe";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ListBox lstBranco;
        public System.Windows.Forms.ListBox lstPreto;
        public System.Windows.Forms.ListBox lstTabuleiro;
    }
}