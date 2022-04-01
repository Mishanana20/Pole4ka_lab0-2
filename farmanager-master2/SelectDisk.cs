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
    public partial class SelectDisk : Form
    {

        private Form1 form;
        private TextBox txt;
        private ListView list;
        private static readonly functions.Path path = new functions.Path();
        public SelectDisk(Form1 _form, TextBox _txt, ListView _list)
        {
            InitializeComponent();
            form = _form;
            txt = _txt;
            list = _list;

            int top = 10;
            int left = 10;

            DriveInfo[] allDrives = DriveInfo.GetDrives();

            int i = 0;

            foreach (DriveInfo d in allDrives)
            {
                Console.WriteLine("Drive {0}", d.Name);


                Button button = new Button();
                button.Left = left;
                button.Top = top;
                button.Name = "btn" + i;
                button.Text = d.Name;

                button.Click += ButtonOnClick;

                this.Controls.Add(button);
                top += button.Height + 2;

                i++;
            }
        }

        private void ButtonOnClick(object sender, EventArgs eventArgs)
        {
            var button = (Button)sender;
            if (button != null)
            {
                path.changePathTopTextBox(txt, button.Text, list);
                this.Close();
            }
        }
    }
}
