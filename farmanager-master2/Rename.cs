using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace farmanager
{
    public partial class Rename : Form
    {

        private string fileName = "";
        private string path = "";

        private Form1 form1;
        public Rename(string _fileName, string _path, Form1 form)
        {
            InitializeComponent();

            form1 = form;

            path = _path;
            fileName = _fileName;
            btnConfirmRename.KeyDown += KeyPressWatch;
        }

        private void KeyPressWatch(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter) 
            {
                RenameFile();
            }

        }

        private void RenameFile() {

            System.IO.File.Move(System.IO.Path.Combine(path, fileName), System.IO.Path.Combine(path, txtNewFileName.Text));
            form1.UpdateScreen();
            this.Close();
        }

        private void Rename_Load(object sender, EventArgs e)
        {

        }

        private void btnConfirmRename_Click(object sender, EventArgs e)
        {
            RenameFile();
        }
    }
}
