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
    public partial class ConfirmDelete : Form
    {

        private Form1 form;
        public ConfirmDelete(Form1 _form)
        {
            InitializeComponent();
            form = _form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form.DeleteConfirmed();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
