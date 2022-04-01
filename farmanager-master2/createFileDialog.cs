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
    public partial class createFileDialog : Form
    {
        private string path = "";

        private static functions.createFile createFile = new functions.createFile();

        private Form1 form1;
        public createFileDialog(string _path, Form1 _form)
        {
            path = _path;
            InitializeComponent();
            form1 = _form;
            txtFileNameCreateFile.KeyPress += TxtFileNameCreateFile_KeyPress;
        }

        private void TxtFileNameCreateFile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return) {
                createFile.createNewFile(path, txtFileNameCreateFile.Text);
                form1.UpdateScreen();
                this.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            createFile.createNewFile(path, txtFileNameCreateFile.Text);
            form1.UpdateScreen();
            this.Close();
        }

    }
}
