using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace farmanager.functions
{
    class CreateItemListWithCheckBox
    {

        private static getText getText = new getText();
        public void CreateList(ListView listView, TextBox box)
        {
            var path = box.Text;
            Form1.copyFilePath.Clear();

            for (int i = 0; i < listView.Items.Count; i++) {
                if (listView.Items[i].Checked)
                {
                    Form1.copyFilePath.Add(path + listView.Items[i].Text);
                }
            }




            foreach (var item in Form1.copyFilePath) Console.WriteLine(item);
        }
    }
}
