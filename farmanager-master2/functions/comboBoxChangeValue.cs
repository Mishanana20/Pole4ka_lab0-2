using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace farmanager.functions
{
    class comboBoxChangeValue
    {

        public void ValueChange(ComboBox box, string newValue){

            box.Items.Clear();
            bool addNew = false;
            
            foreach (var d in Globals.allDrives) {
                if (newValue != "") { addNew = true;}
            }

            if (addNew) {
                ComboboxItem item = new ComboboxItem();
                item.Text = newValue;

                Console.WriteLine("new! " + newValue);

                box.Items.Add(item);
            }

            foreach (var d in Globals.allDrives)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = d.Name;

                box.Items.Add(item);
            }

            box.SelectedIndex = 0;
        }

    }
}
