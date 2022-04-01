
namespace farmanager
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listView1 = new System.Windows.Forms.ListView();
            this.listView2 = new System.Windows.Forms.ListView();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.btnCut = new System.Windows.Forms.Button();
            this.btnPut = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.txtL = new System.Windows.Forms.TextBox();
            this.txtR = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Help = new System.Windows.Forms.Button();
            this.Quit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.HideSelection = false;
            this.listView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.listView1.Location = new System.Drawing.Point(12, 53);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(400, 385);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // listView2
            // 
            this.listView2.CheckBoxes = true;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(418, 53);
            this.listView2.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(400, 385);
            this.listView2.TabIndex = 1;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.List;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(111, 503);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(93, 37);
            this.btnCopy.TabIndex = 2;
            this.btnCopy.TabStop = false;
            this.btnCopy.Text = "Копировать(F4)";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click_1);
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(309, 503);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(93, 37);
            this.btnRename.TabIndex = 3;
            this.btnRename.TabStop = false;
            this.btnRename.Text = "Rename (F6)";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnCut
            // 
            this.btnCut.Location = new System.Drawing.Point(210, 503);
            this.btnCut.Name = "btnCut";
            this.btnCut.Size = new System.Drawing.Size(93, 37);
            this.btnCut.TabIndex = 4;
            this.btnCut.TabStop = false;
            this.btnCut.Text = "Вырезать(F5)";
            this.btnCut.UseVisualStyleBackColor = true;
            this.btnCut.Click += new System.EventHandler(this.btnCut_Click);
            // 
            // btnPut
            // 
            this.btnPut.Location = new System.Drawing.Point(624, 503);
            this.btnPut.Name = "btnPut";
            this.btnPut.Size = new System.Drawing.Size(93, 37);
            this.btnPut.TabIndex = 5;
            this.btnPut.TabStop = false;
            this.btnPut.Text = "Вставить(F9)";
            this.btnPut.UseVisualStyleBackColor = true;
            this.btnPut.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(525, 503);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(93, 37);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "Удалить(F8)";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(430, 503);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(89, 37);
            this.btnCreate.TabIndex = 7;
            this.btnCreate.TabStop = false;
            this.btnCreate.Text = "Создать(F7)";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // txtL
            // 
            this.txtL.Enabled = false;
            this.txtL.Location = new System.Drawing.Point(12, 12);
            this.txtL.Name = "txtL";
            this.txtL.ReadOnly = true;
            this.txtL.Size = new System.Drawing.Size(400, 20);
            this.txtL.TabIndex = 0;
            this.txtL.TabStop = false;
            this.txtL.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtR
            // 
            this.txtR.Enabled = false;
            this.txtR.Location = new System.Drawing.Point(418, 12);
            this.txtR.Name = "txtR";
            this.txtR.ReadOnly = true;
            this.txtR.Size = new System.Drawing.Size(400, 20);
            this.txtR.TabIndex = 0;
            this.txtR.TabStop = false;
            this.txtR.TextChanged += new System.EventHandler(this.txtR_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 460);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(806, 20);
            this.textBox1.TabIndex = 8;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // Help
            // 
            this.Help.Location = new System.Drawing.Point(12, 503);
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(93, 37);
            this.Help.TabIndex = 9;
            this.Help.Text = "Help (F1)";
            this.Help.UseVisualStyleBackColor = true;
            this.Help.Click += new System.EventHandler(this.Help_Click);
            // 
            // Quit
            // 
            this.Quit.Location = new System.Drawing.Point(725, 503);
            this.Quit.Name = "Quit";
            this.Quit.Size = new System.Drawing.Size(93, 37);
            this.Quit.TabIndex = 10;
            this.Quit.Text = "Quit";
            this.Quit.UseVisualStyleBackColor = true;
            this.Quit.Click += new System.EventHandler(this.Quit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 552);
            this.Controls.Add(this.Quit);
            this.Controls.Add(this.Help);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtR);
            this.Controls.Add(this.txtL);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnPut);
            this.Controls.Add(this.btnCut);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.listView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FarManager 2077";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.Button btnCut;
        private System.Windows.Forms.Button btnPut;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox txtL;
        private System.Windows.Forms.TextBox txtR;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Help;
        private System.Windows.Forms.Button Quit;
    }
}


