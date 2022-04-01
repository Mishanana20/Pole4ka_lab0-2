using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using MyImgClassNameSpace;

namespace farmanager
{

    public partial class Form1 : Form
    {

        //Костыль
        bool LeftListFocused = false;
        bool RightListFocused = false;
        //Конец костыля

        public string createFileName = "";

        public string fileNameLast = "";

        public string selectItem = "";

        public static List<string> copyFilePath = new List<string>();

        public string new_filepath = @"C:\";
        public string new_filepath_2 = @"C:\";

        public bool delete = false;

        public bool text_changed_1 = false;
        public bool text_changed_1_enter = false;
        string textPath = "";
        //Подключение файлов с функцияи
        private static readonly functions.Path path = new functions.Path();
        private static functions.CreateItemListWithCheckBox CreateItemListWithCheckBox = new functions.CreateItemListWithCheckBox();
        private static functions.goToDir goToDir = new functions.goToDir();
        private static functions.copy_F5 copy_F5 = new functions.copy_F5();
        private static functions.delete_file delete_file = new functions.delete_file();
        private static functions.move_F6 move_F6 = new functions.move_F6();
        private static functions.getText getText = new functions.getText();
        private static functions.comboBoxChangeValue comboBoxChangeValue = new functions.comboBoxChangeValue();
        
        
        public Form1()
        {

            InitializeComponent();

            UpdateScreen();


            this.Controls.Add(txtL);
            txtL.KeyPress += new KeyPressEventHandler(keypressed1);

            this.Controls.Add(txtR);
            txtR.KeyPress += new KeyPressEventHandler(keypressed2);


            listView1.KeyDown += KeyPressWatch;
            listView2.KeyDown += KeyPressWatch;
            btnCopy.KeyDown += KeyPressWatch;
            btnCopy.Click += BtnCopy_Click;
            btnRename.KeyDown += KeyPressWatch;


            //////////////////////////////
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D; //запрещаем менять размер окна
            this.Text = "Far Manager BlueViolet-style Version"; //
            this.BackColor = Color.BlueViolet;//цвет фона  
            listView1.BackgroundImage = new MyImgClass("img/alians2.png", 400, 385).img; //Alians2.img;
            listView2.BackgroundImage = new MyImgClass("img/Орда2.jpg", 400, 385).img;
            MyImgClass img3 = new MyImgClass("img/alians2.png", 400, 450);
            //////////////////////////////


            //listView1.Focus();
        }


        public void UpdateScreen()
        {
            path.changePathTopTextBox(txtL, new_filepath, listView1);
            path.changePathTopTextBox(txtR, new_filepath_2, listView2);
        }

        private void BtnCopy_Click(object sender, EventArgs e)
        {

            if (listView1.Focused)
            { CreateItemListWithCheckBox.CreateList(listView1, txtL); 
            }

            if (listView2.Focused) CreateItemListWithCheckBox.CreateList(listView2, txtR);

        }

        private void KeyPressWatch(object sender, KeyEventArgs e)
        {

            //поменять диск в левом окне
            if (e.KeyCode == Keys.F1 && e.Alt)
            {
                var notify = new SelectDisk(this, txtL, listView1);
                notify.Show();
            }

            //поменять диск в правом окне
            if (e.KeyCode == Keys.F2 && e.Alt)
            {
                var notify = new SelectDisk(this, txtR, listView2);
                notify.Show();
            }

            

            //посмотреть
            if (e.KeyCode == Keys.F2) 
            {
                    if (File.Exists(txtL.Text + selectItem) && listView1.Focused)
                    {
                        var reader = new Read(txtL.Text + selectItem, true);
                        reader.Show();
                    }
                    if (File.Exists(txtR.Text + selectItem) && listView2.Focused)
                    {
                        var reader = new Read(txtR.Text + selectItem, true);
                        reader.Show();
                    }

            }

            //редактировать содержимое
            if (e.KeyCode == Keys.F3)
            {
                if (File.Exists(txtL.Text + selectItem) && listView1.Focused)
                {
                    var reader = new Read(txtL.Text + selectItem, false);
                    reader.Show();
                }
                if (File.Exists(txtR.Text + selectItem) && listView2.Focused)
                {
                    var reader = new Read(txtR.Text + selectItem, false);
                    reader.Show();
                }
            }

            // копировать
            if (e.KeyCode == Keys.F4)
            {
                Copy();
            }

            // вырезать
            if (e.KeyCode == Keys.F5)
            {
                Cut();
            }

            // вставить после копировать\вырезания
            if (e.KeyCode == Keys.F9)
            {
                Put();
            }

            //ренейм
            if (e.KeyCode == Keys.F6)
            {
                Rename();
            }

            // удалить
            if (e.KeyCode == Keys.F8)
            {
                //Delete();
                DeleteConfirmed();
            }

            // создать
            if (e.KeyCode == Keys.F7) 
            {
                Create();
            }
            // выход
            if (e.KeyCode == Keys.F10)
            {
                this.Close();
            }


            ///тест форкуса
            /**
            if (e.KeyCode == Keys.F)
            {
             
                if (listView1.Focused)
                {
                    
                    MessageBox.Show("list1 focusded");
                }
                if (listView2.Focused)
                {
                  
                    MessageBox.Show("list2 focusded");
                }
            }**/

            // открыть
            if (e.KeyCode == Keys.Return)
            {
                if (listView1.Focused) goToDir.openDir(txtL.Text + selectItem, txtL, listView1, true);
                if (listView2.Focused) goToDir.openDir(txtR.Text + selectItem, txtR, listView2, true);
            }


           


            // назад
            if (e.KeyCode == Keys.Back)
            {
                if (listView1.Focused)
                {

                    try
                    {
                        var splitPath = txtL.Text.Split('\\');
                        var path = "";
                        for (int i = 0; i < splitPath.Length - 2; i++)
                        {
                            path += splitPath[i];
                            if (i < splitPath.Length - 2) path += '\\';
                        }

                        goToDir.openDir(path, txtL, listView1, false);
                    }
                    catch
                    {
                        MessageBox.Show("Некуда возвращаться");
                    }

                }
                if (listView2.Focused)
                {
                    try
                    {
                        var splitPath = txtR.Text.Split('\\');
                        var path = "";
                        for (int i = 0; i < splitPath.Length - 2; i++)
                        {
                            path += splitPath[i];
                            if (i < splitPath.Length - 2) path += '\\';
                        }

                        goToDir.openDir(path, txtR, listView2, false);
                    }
                    catch
                    {
                        MessageBox.Show("Некуда возвращаться");
                    }
                }
            }



        }

        public void Copy()
        {
            if (listView1.Focused) CreateItemListWithCheckBox.CreateList(listView1, txtL);
            if (listView2.Focused) CreateItemListWithCheckBox.CreateList(listView2, txtR);
            delete = false;
        }
        public void Cut()
        {
            if (listView1.Focused) CreateItemListWithCheckBox.CreateList(listView1, txtL);
            if (listView2.Focused) CreateItemListWithCheckBox.CreateList(listView2, txtR);
            delete = true;
        }
        public void Put() {

            if (delete == false)
            {
                if (listView1.Focused)
                {

                    foreach (var item in Form1.copyFilePath) copy_F5.copy_file(item.Split('\\').Last(), item.Substring(0, item.LastIndexOf('\\')), txtL.Text);
                    new_filepath = txtL.Text;
                    path.changePathTopTextBox(txtL, new_filepath, listView1);

                }
                if (listView2.Focused)
                {
                    foreach (var item in Form1.copyFilePath) copy_F5.copy_file(item.Split('\\').Last(), item.Substring(0, item.LastIndexOf('\\')), txtR.Text);
                    new_filepath_2 = txtR.Text;
                    path.changePathTopTextBox(txtR, new_filepath_2, listView2);
                }
            }
            else
            {
                if (listView1.Focused)
                {

                    foreach (var item in Form1.copyFilePath) move_F6.move_file(item, txtL.Text + item.Split('\\').Last());
                    new_filepath = txtL.Text;
                    path.changePathTopTextBox(txtL, new_filepath, listView1);


                }
                if (listView2.Focused)
                {
                    foreach (var item in Form1.copyFilePath) move_F6.move_file(item, txtR.Text + item.Split('\\').Last());
                    new_filepath_2 = txtR.Text;
                    path.changePathTopTextBox(txtR, new_filepath_2, listView2);

                }
            }
            delete = false;
        }

        public void Rename() {

            var changed_path = "";
            if (listView1.Focused)
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                    if (listView1.Items[i].Focused == true) fileNameLast = listView1.Items[i].Text;
                new_filepath = txtL.Text;
                changed_path = new_filepath;
                
            }
            if(listView2.Focused)
            {
                for (int i = 0; i < listView2.Items.Count; i++)
                    if (listView2.Items[i].Focused == true) fileNameLast = listView2.Items[i].Text;
                new_filepath_2 = txtR.Text;
                changed_path = new_filepath_2;
            }

            var notify = new Rename(fileNameLast, changed_path, this);
            notify.Show();
        }
        public void Delete() {
            var notify = new ConfirmDelete(this);
            notify.Show();
        }

        public void DeleteConfirmed() {
           
            if (listView1.Focused) CreateItemListWithCheckBox.CreateList(listView1, txtL);
            if (listView2.Focused) CreateItemListWithCheckBox.CreateList(listView2, txtR);

            if (listView1.Focused)
            {

                foreach (var item in Form1.copyFilePath) delete_file.delete_file_by_filepath(item);

                new_filepath = txtL.Text;
                path.changePathTopTextBox(txtL, new_filepath, listView1);
            }
            if (listView2.Focused)
            {
                foreach (var item in Form1.copyFilePath) delete_file.delete_file_by_filepath(item);

                new_filepath_2 = txtR.Text;
                path.changePathTopTextBox(txtR, new_filepath_2, listView2);
            }
        }

        public void Create() {

            if (listView1.Focused)
            {
                var create = new createFileDialog(txtL.Text, this);
                create.Show();
                new_filepath = txtL.Text;
                //path.changePathTopTextBox(path1, new_filepath, listView1);
            }
            if (listView2.Focused)
            {
                var create = new createFileDialog(txtR.Text, this);
                create.Show();
                new_filepath_2 = txtR.Text;
                //path.changePathTopTextBox(path2, new_filepath_2, listView2);
            }
        }


        ///////
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                MessageBox.Show(
         "Да поможет мне физика...",
         "HELP -FAR",
         MessageBoxButtons.YesNo,
         MessageBoxIcon.Information,
         MessageBoxDefaultButton.Button1,
         MessageBoxOptions.DefaultDesktopOnly); return true;
            }
            if (keyData == Keys.Enter)
            {
                if (text_changed_1 == true)
                { text_changed_1_enter = true;  goToDir.openDir(txtL.Text + textPath, txtL, listView1, true); }
            }

            return base.ProcessCmdKey(ref msg, keyData);

        }

        //////



        private void keypressed1(Object o, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Return)
            {
                new_filepath = txtL.Text;
                path.changePathTopTextBox(txtL, new_filepath, listView1);
            }
        }
        private void keypressed2(Object o, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Return)
            {
                new_filepath_2 = txtR.Text;
                path.changePathTopTextBox(txtR, new_filepath_2, listView2);
            }
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count == 0) return;
            ListViewItem item = listView1.SelectedItems[0];

            selectItem = item.Text;
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listView2.SelectedItems.Count == 0) return;
            ListViewItem item = listView2.SelectedItems[0];

            selectItem = item.Text;
        }

        private void path1_TextChanged(object sender, EventArgs e)
        {

        }

        private void path2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void newFileName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Rename();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Put();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Create();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void btnCopy_Click_1(object sender, EventArgs e)
        {
            Copy();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void path2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Path2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //path.changePathTopTextBox(path2, path2.SelectedItem.ToString(), listView2);
        }

        private void Path1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //path.changePathTopTextBox(path1, path1.SelectedItem.ToString(), listView1);
        }

        private void path1_DropDownClosed(Object sender, EventArgs e)
        {

        }
        private void path2_DropDownClosed(Object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            text_changed_1 = true;
            
               if (textBox1.Text.Contains("cd \\"))
               {
                
                    textPath = textBox1.Text;
                    //textBox1.Text = textPath;
                    textPath = textBox1.Text.Substring(4);
                if (text_changed_1_enter == true)
                {
                    //textPath = textBox1.Text.Substring(3);
                    text_changed_1 = false;
                    text_changed_1_enter = false;
                }
  
               }
            
        }

        //////////////
        private void Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
         "Да поможет мне физика...",
         "HELP -FAR",
         MessageBoxButtons.YesNo,
         MessageBoxIcon.Information,
         MessageBoxDefaultButton.Button1,
         MessageBoxOptions.DefaultDesktopOnly); 
            
        }
        private void Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtR_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public static class Globals
    {
        public static DriveInfo[] allDrives = DriveInfo.GetDrives();
    }

    public class ComboboxItem
    {
        public string Text { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}


