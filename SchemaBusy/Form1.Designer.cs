
namespace SchemaBusy
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLoadTTs = new System.Windows.Forms.Button();
            this.txbJR = new System.Windows.Forms.TextBox();
            this.btnLoadSLs = new System.Windows.Forms.Button();
            this.txbSZ = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLoadTTs
            // 
            this.btnLoadTTs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadTTs.Location = new System.Drawing.Point(912, 12);
            this.btnLoadTTs.Name = "btnLoadTTs";
            this.btnLoadTTs.Size = new System.Drawing.Size(122, 23);
            this.btnLoadTTs.TabIndex = 0;
            this.btnLoadTTs.Text = "Jízdní řády";
            this.btnLoadTTs.UseVisualStyleBackColor = true;
            this.btnLoadTTs.Click += new System.EventHandler(this.btnLoadTTs_Click);
            // 
            // txbJR
            // 
            this.txbJR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txbJR.Location = new System.Drawing.Point(912, 41);
            this.txbJR.Multiline = true;
            this.txbJR.Name = "txbJR";
            this.txbJR.Size = new System.Drawing.Size(122, 83);
            this.txbJR.TabIndex = 1;
            this.txbJR.Text = "JR/805004-T.txt\r\nJR/805005-T.txt";
            // 
            // btnLoadSLs
            // 
            this.btnLoadSLs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadSLs.Location = new System.Drawing.Point(912, 131);
            this.btnLoadSLs.Name = "btnLoadSLs";
            this.btnLoadSLs.Size = new System.Drawing.Size(121, 23);
            this.btnLoadSLs.TabIndex = 2;
            this.btnLoadSLs.Text = "Seznamy zastávek";
            this.btnLoadSLs.UseVisualStyleBackColor = true;
            this.btnLoadSLs.Click += new System.EventHandler(this.btnLoadSLs_Click);
            // 
            // txbSZ
            // 
            this.txbSZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSZ.Location = new System.Drawing.Point(912, 161);
            this.txbSZ.Multiline = true;
            this.txbSZ.Name = "txbSZ";
            this.txbSZ.Size = new System.Drawing.Size(120, 106);
            this.txbSZ.TabIndex = 3;
            this.txbSZ.Text = "SZ/805004-T.txt\r\nSZ/805005-T.txt";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(912, 514);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(122, 73);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Smaž";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 599);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txbSZ);
            this.Controls.Add(this.btnLoadSLs);
            this.Controls.Add(this.txbJR);
            this.Controls.Add(this.btnLoadTTs);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadTTs;
        private System.Windows.Forms.TextBox txbJR;
        private System.Windows.Forms.Button btnLoadSLs;
        private System.Windows.Forms.TextBox txbSZ;
        private System.Windows.Forms.Button btnDelete;
    }
}

