
namespace farmanager
{
    partial class createFileDialog
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
            this.txtFileNameCreateFile = new System.Windows.Forms.TextBox();
            this.btnConfirmCreateFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtFileNameCreateFile
            // 
            this.txtFileNameCreateFile.Location = new System.Drawing.Point(12, 38);
            this.txtFileNameCreateFile.Name = "txtFileNameCreateFile";
            this.txtFileNameCreateFile.Size = new System.Drawing.Size(194, 20);
            this.txtFileNameCreateFile.TabIndex = 1;
            // 
            // btnConfirmCreateFile
            // 
            this.btnConfirmCreateFile.Location = new System.Drawing.Point(73, 76);
            this.btnConfirmCreateFile.Name = "btnConfirmCreateFile";
            this.btnConfirmCreateFile.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmCreateFile.TabIndex = 2;
            this.btnConfirmCreateFile.Text = "ОК";
            this.btnConfirmCreateFile.UseVisualStyleBackColor = true;
            this.btnConfirmCreateFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Введите имя файла";
            // 
            // createFileDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 122);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnConfirmCreateFile);
            this.Controls.Add(this.txtFileNameCreateFile);
            this.Name = "createFileDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "createFileDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtFileNameCreateFile;
        private System.Windows.Forms.Button btnConfirmCreateFile;
        private System.Windows.Forms.Label label2;
    }
}