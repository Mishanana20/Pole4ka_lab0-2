using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace farmanager.functions
{
    class getText
    {
        public string getTextFromComboBox(ComboBox box)
        {
            ComboboxItem cbi = (ComboboxItem)box.SelectedItem;
            string res = cbi.Text;
            return res;
        }
    }
}
