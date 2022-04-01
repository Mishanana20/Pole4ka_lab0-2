using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace farmanager.functions
{

    //Работа с путями для двух верхних ComboBox
    class Path
    {
        private static getText getText = new getText();
        private static comboBoxChangeValue comboBoxChangeValue = new comboBoxChangeValue();
        public void changePathTopTextBox(TextBox box, string path, ListView listView)
        {

            try
            {
                listView.Clear();
                
                box.Text = path;

                IEnumerable<string> filePaths = Directory.GetDirectories(path);
                addItemsToList(listView, filePaths);
                filePaths = Directory.EnumerateFiles(box.Text);
                addItemsToList(listView, filePaths);

            }
            catch {

                MessageBox.Show("неверный путь");

            }

            
        }


        private void addItemsToList(ListView listView, IEnumerable<string> filePaths) {
            foreach (string fileName in filePaths)
            {
                var listViewItem = new ListViewItem();
                var qwe = fileName.Split('\\');
                listViewItem.Text = qwe.Last();
                listView.Items.Add(listViewItem);
            }
        }
    }
}
