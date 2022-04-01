
namespace farmanager
{
    partial class Rename
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
            this.txtNewFileName = new System.Windows.Forms.TextBox();
            this.btnConfirmRename = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNewFileName
            // 
            this.txtNewFileName.Location = new System.Drawing.Point(29, 12);
            this.txtNewFileName.Name = "txtNewFileName";
            this.txtNewFileName.Size = new System.Drawing.Size(161, 20);
            this.txtNewFileName.TabIndex = 0;
            // 
            // btnConfirmRename
            // 
            this.btnConfirmRename.Location = new System.Drawing.Point(66, 38);
            this.btnConfirmRename.Name = "btnConfirmRename";
            this.btnConfirmRename.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmRename.TabIndex = 1;
            this.btnConfirmRename.Text = "OK";
            this.btnConfirmRename.UseVisualStyleBackColor = true;
            this.btnConfirmRename.Click += new System.EventHandler(this.btnConfirmRename_Click);
            // 
            // Rename
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 78);
            this.Controls.Add(this.btnConfirmRename);
            this.Controls.Add(this.txtNewFileName);
            this.Name = "Rename";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rename";
            this.Load += new System.EventHandler(this.Rename_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNewFileName;
        private System.Windows.Forms.Button btnConfirmRename;
    }
}