using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace farmanager
{
    public partial class Read : Form
    {

        private string path;
        public Read(string _path, bool _ReadOnly)
        {

            path = _path;
            InitializeComponent();
            richTextBox1.ReadOnly = _ReadOnly;
            richTextBox1.KeyDown += KeyPressWatch;
            if (_ReadOnly)
            {
                this.Text = "Read";
            }
            else {
                this.Text = "Write";
            }
            try
            {
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    string temp = "";
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        temp += line;
                        temp += '\n';
                    }
                    richTextBox1.Text = temp;
                }
            }
            catch {
                this.Close();
            }
            

        }

        private void Read_Load(object sender, EventArgs e)
        {

        }

        private void KeyPressWatch(object sender, KeyEventArgs e)
        {
            //поменять диск в левом окне
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if (e.KeyCode == Keys.S && e.Control) 
            {
                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(richTextBox1.Text);
                }
            }
        }
    }
}
