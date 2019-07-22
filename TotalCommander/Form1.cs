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
using System.Diagnostics;
using System.Web;


namespace TotalCommander
{
    public partial class Form1 : Form
    {
        public string default_editor = "notepad.exe";           /// DECLARE VARIABLES
        private bool Hidden = true;
        private DriveInfo[] drives;
        private DirectoryInfo currentLeft;
        private DirectoryInfo currentRight;
        private ListViewItem[] copyItems = new ListViewItem[20];
        private bool isCut = false;

        private void Load_Image(ListViewItem item)         //GET THE ICON OF EACH ITEM IN THE LIST VIEW
        {
            FileInfo temp = (FileInfo)item.Tag;
            if (!Detail_Icon.Images.ContainsKey(temp.Extension))
            {
                Icon ico = Icon.ExtractAssociatedIcon(temp.FullName);
                Detail_Icon.Images.Add(temp.Extension, ico);
                Large_Icon.Images.Add(temp.Extension, ico);
            }
            item.ImageKey = temp.Extension;
        }

        private void Load_Directory(DirectoryInfo dirs, ListView listView, TextBox tb, bool Hidden)   //LOAD THE DIRECTORY INTO LISTVIEW
        {
            listView.Items.Clear();
            var dirList = dirs.GetDirectories();
            var fileList = dirs.GetFiles();
            ListViewItem list1 = new ListViewItem();
            list1.Text = "..";
            list1.Tag = true;
            listView.Items.Add(list1);

            foreach (var dir in dirList)
            {
                if (Hidden == true)
                {
                    if (dir.Attributes.ToString().Contains("Hidden"))
                        continue;
                }

                ListViewItem list = new ListViewItem();
                list.Text = dir.Name;
                list.SubItems.Add("Folder");
                list.SubItems.Add(dir.CreationTime.ToString());
                list.SubItems.Add("");
                list.Tag = dir;
                list.ImageIndex = 0;
                listView.Items.Add(list);
            }

            foreach (var file in fileList)
            {
                if (Hidden == true)
                {
                    if (file.Attributes.ToString().Contains("Hidden"))
                        continue;
                }

                ListViewItem list = new ListViewItem();
                list.Text = file.Name;
                list.SubItems.Add("File");
                list.SubItems.Add(file.CreationTime.ToString());
                list.SubItems.Add($"{(float)(file.Length / 1024)} KB");
                list.Tag = file;
                Load_Image(list);
                listView.Items.Add(list);
            }
            tb.Text = dirs.FullName;
        }

        private void Change_View(ListView list, int index) //CHANGE THE VIEW OF LISTVIEW 
        {
            switch (index)
            {
                default: case 0: list.View = View.LargeIcon; break;
                case 1: list.View = View.Details; break;
                case 2: list.View = View.SmallIcon; break;

            }
        }

        private void Delete_files(DirectoryInfo dirs, ListView list, TextBox tb) // DELETE FILE OR FOLDER OUT OF FILE EXPLORER AND LISTVIEW
        {
            foreach (ListViewItem listtemp in list.SelectedItems)
            {
                if (listtemp.Tag is true)
                    MessageBox.Show("Directory not exist !!", "ERRORS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (listtemp.Tag is DirectoryInfo)
                    {
                        DirectoryInfo temp = (DirectoryInfo)listtemp.Tag;
                        if (temp.Exists)
                        {
                            if (temp.GetDirectories() != null || temp.GetFiles() != null)
                            {
                                DialogResult answer = MessageBox.Show($"{temp.Name} has subdirectories or sub-files. Are you sure you want to delete", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (answer == DialogResult.Yes)
                                    temp.Delete(true);
                                else
                                    continue;
                            }
                            else
                            {
                                temp.Delete(true);
                            }
                        }
                    }
                    else
                    {
                        FileInfo temp = (FileInfo)listtemp.Tag;
                        if (temp.Exists)
                            temp.Delete();
                    }
                }
            }
            Load_Directory(dirs, list, tb, Hidden);
        }

        private void View_File(ListView list) // VIEW FILE THAT SELECTED IN LISTVIEW USING FORM
        {
            if (list.SelectedItems.Count == 1)
            {
                foreach (ListViewItem file in list.SelectedItems)
                {
                    if (file.Text == "..") continue;
                    if (file.Tag is FileInfo)
                    {
                        FileInfo temp = (FileInfo)file.Tag;
                        if (temp.Exists)
                        {
                            Form3 form3 = new Form3();
                            form3.Text = temp.Name;
                            string extend = temp.Name + Environment.NewLine + temp.FullName + Environment.NewLine + temp.LastAccessTime + Environment.NewLine + temp.Attributes + Environment.NewLine + Environment.NewLine;

                            FileStream f = File.Open(temp.FullName, FileMode.Open, FileAccess.Read);


                            form3.textBox1.Text += extend;
                            StreamReader rdr = new StreamReader(f);

                            double count = temp.Length / byte.MaxValue + 1;
                            for(double i = 0; i < count;i++)
                            {
                                form3.textBox1.Text += rdr.ReadToEnd();
                            }
           
                            rdr.Close();
                            f.Close();

                            form3.ShowDialog();
                        }
                        else MessageBox.Show("File don't exist !", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        DirectoryInfo temp = (DirectoryInfo)file.Tag;
                        if (temp.Exists)
                        {
                            Form3 form3 = new Form3();
                            form3.Text = temp.Name;
                            string extend = temp.Name + "\n" + temp.FullName + "\n" + temp.LastAccessTime + "\n" + temp.Attributes + "\n\n\n";
                            form3.data.Text += extend;
                            form3.ShowDialog();
                        }
                    }
                }
            }
        }

        private void Edit_file(ListView list)// OPEN A FILE TO EDIT USING EDITOR 
        {
            if (list.SelectedItems.Count > 0)
            {
                foreach (ListViewItem var in list.SelectedItems)
                {
                    if (var.Tag is FileInfo)
                    {
                        FileInfo temp = (FileInfo)var.Tag;
                        if (System.Diagnostics.Process.Start(default_editor, temp.FullName) == null)
                            MessageBox.Show("Editor not exist !!");
                    }
                    else
                    {
                        MessageBox.Show("Not a file !!", "Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }
            }

        }

        private void Copy_file(string src, string dst) // COPY FILE TO A SPECIFIC DESTINATION
        {
            if (src != dst)
                if (File.Exists(dst))
                {
                    File.Copy(src, dst, true);
                }
                else
                {
                    FileStream s = new FileStream(dst, FileMode.Create);
                    s.Close();
                    File.Copy(src, dst, true);
                }
            else MessageBox.Show("Invalid path", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Copy_Folder(DirectoryInfo source, DirectoryInfo target) // COPY FOLDER TO THE OTHER FOLDER
        {
            if (Directory.Exists(target.FullName))
            {
                CopyFilesRecursively(source, target);
            }
            else
            {
                target = Directory.CreateDirectory(target.FullName);
                CopyFilesRecursively(source, target);
            }
        }

        private void CopyFilesRecursively(DirectoryInfo source, DirectoryInfo target) // COPY THE CONTENTS OF THE COPIED FOLDER TO ANOTHER FOLDER 
        {
            foreach (DirectoryInfo dir in source.GetDirectories())
                CopyFilesRecursively(dir, target.CreateSubdirectory(dir.Name));
            foreach (FileInfo file in source.GetFiles())
                file.CopyTo(Path.Combine(target.FullName, file.Name), true);
        }

        private void Move_file(ListViewItem src, DirectoryInfo dst) // MOVE A FILE OR FOLDER TO A SPECIFIC DESTINATION
        {
            if (src.Tag is DirectoryInfo)
            {
                DirectoryInfo temp = (DirectoryInfo)src.Tag;
                DirectoryInfo copy = new DirectoryInfo(dst.FullName + "\\" + temp.Name);
                if (temp.FullName != copy.FullName)
                {
                    Copy_Folder(temp, copy);
                    Directory.Delete(temp.FullName, true);
                }
                else
                {
                    src.BeginEdit();
                }
            }
            if (src.Tag is FileInfo)
            {
                FileInfo temp = (FileInfo)src.Tag;
                if (temp.FullName != dst.FullName + "\\" + temp.Name)
                {
                    Copy_file(temp.FullName, dst.FullName + "\\" + temp.Name);
                    File.Delete(temp.FullName);
                }
                else
                {
                    src.BeginEdit();
                }
            }
        }
        //-----------------------------------------------------------------------------------------------------------------------------------

        public Form1()
        {
            InitializeComponent();
            for (int i  = 0; i < copyItems.Length;i++)
            {
                copyItems.SetValue(null, i);
            }
        }

        private void Form1_Load(object sender, EventArgs s)
        {
            listViewLeft.LargeImageList = Large_Icon;
            listViewLeft.SmallImageList = Detail_Icon;
            listViewRight.LargeImageList = Large_Icon;
            listViewRight.SmallImageList = Detail_Icon;
            drives = DriveInfo.GetDrives();
            if (copyItems == null)
            {
                pasteToolStripMenuItem.Enabled = false;
                pasteToolStripMenuItem1.Enabled = false;
            }
            foreach (var drive in drives)
            {
                cbleft.Items.Add(drive);
                cbright.Items.Add(drive);
            }
           

        }       //LOAD FORM

        private void cbleft_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbleft.SelectedIndex >= 0)
            {
                Load_Directory((DirectoryInfo)drives[cbleft.SelectedIndex].RootDirectory, listViewLeft, tbleft, Hidden);
                currentLeft = (DirectoryInfo)drives[cbleft.SelectedIndex].RootDirectory;
            }
        }  //CHANGE DRIVE LEFT WINDOW

        private void listViewLeft_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            foreach (ListViewItem list in listViewLeft.SelectedItems)
            {
                if (list.Tag is true)
                {
                    if (currentLeft != null && currentLeft.Parent != null)
                    {
                        Load_Directory((DirectoryInfo)currentLeft.Parent, listViewLeft, tbleft, Hidden);
                        currentLeft = (DirectoryInfo)currentLeft.Parent;
                    }
                }
                if (list.Tag is DirectoryInfo)
                {
                    Load_Directory((DirectoryInfo)list.Tag, listViewLeft, tbleft, Hidden);
                    currentLeft = (DirectoryInfo)list.Tag;
                }
            }
        } //DOUBLE CLICK ON ITEM OF WINDOW LEFT

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Developed by : Le Dang Hoang An \nVersion: TotalCommander 0.0.1", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }   //ABOUT BUTTON TO VIEW INFORMATION OF DEVELOPER


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (ChooseList.SelectedIndex >= 0)
            {
                if (ChooseList.SelectedIndex == 0)
                {
                    Change_View(listViewLeft, 0);
                }
                else
                {
                    Change_View(listViewRight, 0);
                }
            }
        } //CHANGE VIEW BUTTON

        private void DetailIconButton_Click(object sender, EventArgs e)
        {
            if (ChooseList.SelectedIndex >= 0)
            {
                if (ChooseList.SelectedIndex == 0)
                {
                    Change_View(listViewLeft, 1);
                }
                else
                {
                    Change_View(listViewRight, 1);
                }
            }
        } //CHANGE VIEW INTO DETAIL BUTTON

        private void SmallIconButton_Click(object sender, EventArgs e)
        {
            if (ChooseList.SelectedIndex >= 0)
            {
                if (ChooseList.SelectedIndex == 0)
                {
                    Change_View(listViewLeft, 2);
                }
                else
                {
                    Change_View(listViewRight, 2);
                }
            }
        } //CHANGE VIEW INTO SMALL_ICON BUTTON

        private void cbright_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbright.SelectedIndex >= 0)
            {
                Load_Directory((DirectoryInfo)drives[cbright.SelectedIndex].RootDirectory, listViewRight, tbright, Hidden);
                currentRight = (DirectoryInfo)drives[cbright.SelectedIndex].RootDirectory;
            }
        } //CHANGE DRIVE RIGHT WINDOW

        private void listViewRight_MouseDoubleClick(object sender, MouseEventArgs e) //DOUBLE CLICK ON ITEM OF WINDOW LEFT
        {
            foreach (ListViewItem list in listViewRight.SelectedItems)
            {
                if (list.Tag is true)
                {
                    if (currentRight != null && currentRight.Parent != null)
                    {
                        Load_Directory((DirectoryInfo)currentRight.Parent, listViewRight, tbright, Hidden);
                        currentRight = (DirectoryInfo)currentRight.Parent;
                    }
                }
                if (list.Tag is DirectoryInfo)
                {
                    Load_Directory((DirectoryInfo)list.Tag, listViewRight, tbright, Hidden);
                    currentRight = (DirectoryInfo)list.Tag;
                }
            }
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)  //REFRESH BUTTON CLICK
        {
            if (ChooseList.SelectedIndex >= 0)
            {
                if (ChooseList.SelectedIndex == 0)
                {
                    if (currentLeft != null)
                        Load_Directory((DirectoryInfo)currentLeft, listViewLeft, tbleft, Hidden);
                }
                else
                {
                    if (currentRight != null)
                        Load_Directory((DirectoryInfo)currentRight, listViewRight, tbright, Hidden);
                }
            }
        }

        private void tbleft_KeyPress(object sender, KeyPressEventArgs e)    //ENTER AN PATH IN A TEXTBOX LEFT 
        {
            if (e.KeyChar == 13)
            {
                string path = tbleft.Text;
                DirectoryInfo temp = new DirectoryInfo(path);
                if (temp.Exists == true)
                {
                    currentLeft = temp;
                    Load_Directory(currentLeft, listViewLeft, tbright, Hidden);
                }
                else
                    MessageBox.Show("Directory not exist !!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbright_KeyPress(object sender, KeyPressEventArgs e) //ENTER AN PATH IN A TEXTBOX RIGHT
        {

            if (e.KeyChar == 13)
            {
                string path = tbright.Text;
                DirectoryInfo temp = new DirectoryInfo(path);
                if (temp.Exists == true)
                {
                    currentRight = temp;
                    Load_Directory(currentRight, listViewRight, tbright, Hidden);
                }
                else
                    MessageBox.Show("Directory not exist !!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)  //DELETE TOOLSTRIP LEFT
        {
            if (listViewLeft.SelectedItems.Count != 0)
            {
                DialogResult answer = MessageBox.Show("Do you want to delete !!!", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (answer == DialogResult.Yes)
                {
                    Delete_files(currentLeft, listViewLeft, tbleft);
                }
            }

        }

        private void showHiddenFilesToolStripMenuItem_Click(object sender, EventArgs e) //SHOW HIDDEN FILE TOOLSTRIP
        {
            if (Hidden)
            {
                Hidden = false;
            }
            else
            {
                Hidden = true;
            }
        }

        private void defaultEditorToolStripMenuItem_Click(object sender, EventArgs e)  //DEFAULT EDITOR TOOLSTRIP
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            if (!form2.Visible)
            {
                default_editor = form2.tbform2.Text ;
            }

        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e) //DELETE TOOLSTRIP RIGHT
        {
            if (listViewRight.SelectedItems.Count != 0)
            {
                DialogResult answer = MessageBox.Show("Do you want to delete !!!", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (answer == DialogResult.Yes)
                {
                    Delete_files(currentRight, listViewRight, tbright);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) //EXIT TOOLSTRIP
        {
            Application.Exit();

        }

        private void listViewLeft_KeyUp(object sender, KeyEventArgs e) //HOT KEYS FOR LISTVIEW LEFT
        {
            if (listViewLeft.SelectedItems.Count != 0)
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        {
                            foreach (ListViewItem list in listViewLeft.SelectedItems)
                            {
                                if (list.Tag is true)
                                {
                                    if (currentLeft != null && currentLeft.Parent != null)
                                    {
                                        Load_Directory((DirectoryInfo)currentLeft.Parent, listViewLeft, tbleft, Hidden);
                                        currentLeft = (DirectoryInfo)currentLeft.Parent;
                                    }
                                }
                                if (list.Tag is DirectoryInfo)
                                {
                                    Load_Directory((DirectoryInfo)list.Tag, listViewLeft, tbleft, Hidden);
                                    currentLeft = (DirectoryInfo)list.Tag;
                                }
                            }
                        }
                        break;
                    case Keys.F8:
                        {
                            DialogResult answer = MessageBox.Show("Do you want to delete !!!", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (answer == DialogResult.Yes)
                            {
                                Delete_files(currentLeft, listViewLeft, tbleft);
                            }; break;
                        }
                    case Keys.F3:
                        {
                            View_File(listViewLeft);
                            break;
                        }
                    case Keys.F4:
                        {
                            Edit_file(listViewLeft);
                            break;
                        }
                    case Keys.F7:
                        {

                            string name = "New Folder";
                            int pos = 1;
                            while (listViewLeft.FindItemWithText(name) != null)
                            {
                                name = "New Folder " + $"({pos})";
                                pos++;
                            }
                            currentLeft.CreateSubdirectory(name);
                            Load_Directory(currentLeft, listViewLeft, tbleft, Hidden);

                            break;
                        }
                    case Keys.F5:
                        {
                            if (listViewLeft.SelectedItems.Count != 0)
                            {
                                Form4 form4 = new Form4();
                                form4.ShowDialog();

                                if (form4.button1.Tag is false)
                                {
                                    int count = 0;
                                    foreach (ListViewItem file in listViewLeft.SelectedItems)
                                    {
                                        if (file.Tag is FileInfo)
                                        {
                                            FileInfo temp = (FileInfo)file.Tag;
                                            if (listViewRight.FindItemWithText(file.Text) != null && count == 0)
                                            {
                                                Copy_file(temp.FullName, currentRight.FullName + '\\' + temp.Name);
                                                count++;
                                            }
                                            if (listViewRight.FindItemWithText(file.Text) != null && count != 0)
                                            {
                                                continue;
                                            }
                                            if (listViewRight.FindItemWithText(file.Text) == null)
                                            {
                                                Copy_file(temp.FullName, currentRight.FullName + '\\' + temp.Name);
                                            }
                                        }
                                        if (file.Tag is DirectoryInfo)
                                        {
                                            DirectoryInfo temp = (DirectoryInfo)file.Tag;
                                            if (listViewRight.FindItemWithText(file.Text) != null && count == 0)
                                            {

                                                DirectoryInfo copy = new DirectoryInfo(currentRight.FullName + "\\" + temp.Name);
                                                Copy_Folder(temp, copy);

                                                count++;
                                            }
                                            if (listViewRight.FindItemWithText(file.Text) != null && count != 0)
                                            {
                                                continue;
                                            }
                                            if (listViewRight.FindItemWithText(file.Text) == null)
                                            {

                                                DirectoryInfo copy = new DirectoryInfo(currentRight.FullName + "\\" + temp.Name);
                                                Copy_Folder(temp, copy);

                                            }
                                        }
                                    }
                                    form4.button1.Tag = true;

                                }

                                if (form4.button2.Tag is false)
                                {
                                    foreach (ListViewItem file in listViewLeft.SelectedItems)
                                    {
                                        if (file.Tag is FileInfo)
                                        {
                                            FileInfo temp = (FileInfo)file.Tag;
                                            Copy_file(temp.FullName, currentRight.FullName + '\\' + temp.Name);
                                        }
                                        if (file.Tag is DirectoryInfo)
                                        {
                                            DirectoryInfo temp = (DirectoryInfo)file.Tag;
                                            DirectoryInfo copy = new DirectoryInfo(currentRight.FullName + "\\" + temp.Name);
                                            Copy_Folder(temp, copy);

                                        }

                                    }
                                    form4.button2.Tag = true;
                                }

                                if (form4.button3.Tag is false)
                                {

                                    int count = 0;
                                    foreach (ListViewItem file in listViewLeft.SelectedItems)
                                    {
                                        if (file.Tag is FileInfo)
                                        {
                                            FileInfo temp = (FileInfo)file.Tag;
                                            if (listViewRight.FindItemWithText(file.Text) != null && count != 0)
                                            {
                                                Copy_file(temp.FullName, currentRight.FullName + '\\' + temp.Name);

                                            }
                                            if (listViewRight.FindItemWithText(file.Text) != null && count == 0)
                                            {
                                                count++;
                                                continue;

                                            }
                                            if (listViewRight.FindItemWithText(file.Text) == null)
                                            {
                                                Copy_file(temp.FullName, currentRight.FullName + '\\' + temp.Name);
                                            }
                                        }
                                        if (file.Tag is DirectoryInfo)
                                        {
                                            DirectoryInfo temp = (DirectoryInfo)file.Tag;

                                            if (listViewRight.FindItemWithText(file.Text) != null && count != 0)
                                            {
                                                DirectoryInfo copy = new DirectoryInfo(currentRight.FullName + "\\" + temp.Name);
                                                Copy_Folder(temp, copy);


                                            }
                                            if (listViewRight.FindItemWithText(file.Text) != null && count == 0)
                                            {
                                                count++;
                                                continue;

                                            }
                                            if (listViewRight.FindItemWithText(file.Text) == null)
                                            {
                                                DirectoryInfo copy = new DirectoryInfo(currentRight.FullName + "\\" + temp.Name);
                                                Copy_Folder(temp, copy);

                                            }
                                        }

                                    }

                                    form4.button3.Tag = true;
                                }

                                if (form4.button4.Tag is false)
                                {
                                    foreach (ListViewItem file in listViewLeft.SelectedItems)
                                    {
                                        if (file.Tag is FileInfo)
                                        {
                                            FileInfo temp = (FileInfo)file.Tag;
                                            if (listViewRight.FindItemWithText(file.Text) == null)
                                            {
                                                Copy_file(temp.FullName, currentRight.FullName + '\\' + temp.Name);
                                            }
                                        }
                                        if (file.Tag is DirectoryInfo)
                                        {
                                            DirectoryInfo temp = (DirectoryInfo)file.Tag;
                                            if (listViewRight.FindItemWithText(file.Text) == null)
                                            {
                                                DirectoryInfo copy = new DirectoryInfo(currentRight.FullName + "\\" + temp.Name);
                                                Copy_Folder(temp, copy);

                                            }
                                        }

                                    }
                                    form4.button4.Tag = true;
                                }

                                if (form4.button5.Tag is false)
                                {
                                    form4.button5.Tag = true;
                                    //
                                }
                            }
                            Load_Directory(currentLeft, listViewLeft, tbleft, Hidden);
                            Load_Directory(currentRight, listViewRight, tbright, Hidden);
                            break;
                        }

                    case Keys.F6:
                        if (listViewLeft.SelectedItems.Count != 0)
                        {
                            Form4 form4 = new Form4();
                            form4.ShowDialog();

                            if (form4.button1.Tag is false)
                            {
                                int count = 0;
                                foreach (ListViewItem es in listViewLeft.SelectedItems)
                                {
                                    if (listViewRight.FindItemWithText(es.Text) == null)
                                    {
                                        Move_file(es, currentRight);
                                    }
                                    if (listViewRight.FindItemWithText(es.Text) != null && count == 0)
                                    {
                                        count++;
                                        Move_file(es, currentRight);
                                    }
                                }
                                form4.button1.Tag = true;
                                //
                            }

                            if (form4.button3.Tag is false)
                            {
                                int count = 0;
                                foreach (ListViewItem es in listViewLeft.SelectedItems)
                                {
                                    if (listViewRight.FindItemWithText(es.Text) != null && count == 0)
                                    {
                                        count++;
                                    }
                                    else Move_file(es, currentRight);
                                }
                                form4.button3.Tag = true;
                                //
                            }

                            if (form4.button5.Tag is false)
                            {
                                form4.button5.Tag = true;
                                //
                            }

                            if (form4.button4.Tag is false)
                            {
                                foreach (ListViewItem es in listViewLeft.SelectedItems)
                                {
                                    if (listViewRight.FindItemWithText(es.Text) == null)
                                    {
                                        Move_file(es, currentRight);
                                    }
                                }
                                form4.button4.Tag = true;
                                //
                            }

                            if (form4.button2.Tag is false)
                            {
                                foreach (ListViewItem es in listViewLeft.SelectedItems)
                                {
                                    Move_file(es, currentRight);
                                }
                                form4.Tag = true;

                            }
                        }
                        Load_Directory(currentLeft, listViewLeft, tbleft, Hidden);
                        Load_Directory(currentRight, listViewRight, tbright, Hidden);
                        break;
                }
            }
        }

        private void listViewRight_KeyUp(object sender, KeyEventArgs e) //HOT KEYS FOR LISTVIEW RIGHT
        {
            if (listViewRight.SelectedItems.Count != 0)
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        foreach (ListViewItem list in listViewRight.SelectedItems)
                        {
                            if (list.Tag is true)
                            {
                                if (currentRight != null && currentRight.Parent != null)
                                {
                                    Load_Directory((DirectoryInfo)currentRight.Parent, listViewRight, tbright, Hidden);
                                    currentRight = (DirectoryInfo)currentRight.Parent;
                                }
                            }
                            if (list.Tag is DirectoryInfo)
                            {
                                Load_Directory((DirectoryInfo)list.Tag, listViewRight, tbright, Hidden);
                                currentRight = (DirectoryInfo)list.Tag;
                            }
                        }
                        break;
                    case Keys.F8:
                        {
                            DialogResult answer = MessageBox.Show("Do you want to delete !!!", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (answer == DialogResult.Yes)
                            {
                                Delete_files(currentRight, listViewRight, tbright);
                            }; break;
                        }
                    case Keys.F3:
                        {
                            View_File(listViewRight);
                            break;
                        }
                    case Keys.F4:
                        {
                            Edit_file(listViewRight);
                            break;
                        }
                    case Keys.F7:
                        {

                            string name = "New Folder";
                            int pos = 1;
                            while (listViewRight.FindItemWithText(name) != null)
                            {
                                name = "New Folder " + $"({pos})";
                                pos++;
                            }
                            currentRight.CreateSubdirectory(name);
                            Load_Directory(currentRight, listViewRight, tbright, Hidden);

                            break;
                        }
                    case Keys.F5:
                        {
                            if (listViewRight.SelectedItems.Count != 0)
                            {
                                Form4 form4 = new Form4();
                                form4.ShowDialog();

                                if (form4.button1.Tag is false)
                                {
                                    int count = 0;
                                    foreach (ListViewItem file in listViewRight.SelectedItems)
                                    {
                                        if (file.Tag is FileInfo)
                                        {
                                            FileInfo temp = (FileInfo)file.Tag;
                                            if (listViewLeft.FindItemWithText(file.Text) != null && count == 0)
                                            {
                                                Copy_file(temp.FullName, currentLeft.FullName + '\\' + temp.Name);
                                                count++;
                                            }
                                            if (listViewLeft.FindItemWithText(file.Text) != null && count != 0)
                                            {
                                                continue;
                                            }
                                            if (listViewLeft.FindItemWithText(file.Text) == null)
                                            {
                                                Copy_file(temp.FullName, currentLeft.FullName + '\\' + temp.Name);
                                            }
                                        }
                                        if (file.Tag is DirectoryInfo)
                                        {
                                            DirectoryInfo temp = (DirectoryInfo)file.Tag;
                                            if (listViewLeft.FindItemWithText(file.Text) != null && count == 0)
                                            {
                                                DirectoryInfo copy = new DirectoryInfo(currentLeft.FullName + "\\" + temp.Name);
                                                Copy_Folder(temp, copy);
                                                count++;
                                            }
                                            if (listViewLeft.FindItemWithText(file.Text) != null && count != 0)
                                            {
                                                continue;
                                            }
                                            if (listViewLeft.FindItemWithText(file.Text) == null)
                                            {
                                                DirectoryInfo copy = new DirectoryInfo(currentLeft.FullName + "\\" + temp.Name);
                                                Copy_Folder(temp, copy);
                                            }
                                        }
                                    }
                                    form4.button1.Tag = true;

                                }

                                if (form4.button2.Tag is false)
                                {
                                    foreach (ListViewItem file in listViewRight.SelectedItems)
                                    {
                                        if (file.Tag is FileInfo)
                                        {
                                            FileInfo temp = (FileInfo)file.Tag;
                                            Copy_file(temp.FullName, currentLeft.FullName + '\\' + temp.Name);
                                        }
                                        if (file.Tag is DirectoryInfo)
                                        {
                                            DirectoryInfo temp = (DirectoryInfo)file.Tag;
                                            DirectoryInfo copy = new DirectoryInfo(currentLeft.FullName + "\\" + temp.Name);
                                            Copy_Folder(temp, copy);
                                        }
                                    }
                                    form4.button2.Tag = true;
                                }

                                if (form4.button3.Tag is false)
                                {
                                    int count = 0;
                                    foreach (ListViewItem file in listViewRight.SelectedItems)
                                    {
                                        if (file.Tag is FileInfo)
                                        {
                                            FileInfo temp = (FileInfo)file.Tag;
                                            if (listViewLeft.FindItemWithText(file.Text) != null && count != 0)
                                            {
                                                Copy_file(temp.FullName, currentLeft.FullName + '\\' + temp.Name);

                                            }
                                            if (listViewLeft.FindItemWithText(file.Text) != null && count == 0)
                                            {
                                                count++;
                                                continue;

                                            }
                                            if (listViewLeft.FindItemWithText(file.Text) == null)
                                            {
                                                Copy_file(temp.FullName, currentLeft.FullName + '\\' + temp.Name);
                                            }
                                        }
                                        if (file.Tag is DirectoryInfo)
                                        {
                                            DirectoryInfo temp = (DirectoryInfo)file.Tag;
                                            if (listViewLeft.FindItemWithText(file.Text) != null && count != 0)
                                            {
                                                DirectoryInfo copy = new DirectoryInfo(currentLeft.FullName + "\\" + temp.Name);
                                                Copy_Folder(temp, copy);

                                            }
                                            if (listViewLeft.FindItemWithText(file.Text) != null && count == 0)
                                            {
                                                count++;
                                                continue;

                                            }
                                            if (listViewLeft.FindItemWithText(file.Text) == null)
                                            {
                                                DirectoryInfo copy = new DirectoryInfo(currentLeft.FullName + "\\" + temp.Name);
                                                Copy_Folder(temp, copy);
                                            }
                                        }
                                    }
                                    form4.button3.Tag = true;
                                }

                                if (form4.button4.Tag is false)
                                {
                                    foreach (ListViewItem file in listViewRight.SelectedItems)
                                    {
                                        if (file.Tag is FileInfo)
                                        {
                                            FileInfo temp = (FileInfo)file.Tag;
                                            if (listViewLeft.FindItemWithText(file.Text) == null)
                                            {
                                                Copy_file(temp.FullName, currentLeft.FullName + '\\' + temp.Name);
                                            }
                                        }
                                        if (file.Tag is DirectoryInfo)
                                        {
                                            DirectoryInfo temp = (DirectoryInfo)file.Tag;
                                            if (listViewLeft.FindItemWithText(file.Text) == null)
                                            {
                                                DirectoryInfo copy = new DirectoryInfo(currentLeft.FullName + "\\" + temp.Name);
                                                Copy_Folder(temp, copy);
                                            }
                                        }
                                    }
                                    form4.button4.Tag = true;
                                }

                                if (form4.button5.Tag is false)
                                {
                                    form4.button5.Tag = true;
                                    //
                                }
                            }
                        }
                        Load_Directory(currentLeft, listViewLeft, tbleft, Hidden);
                        Load_Directory(currentRight, listViewRight, tbright, Hidden);
                        break;
                    case Keys.F6:
                        if (listViewRight.SelectedItems.Count != 0)
                        {
                            Form4 form4 = new Form4();
                            form4.ShowDialog();
                            if (form4.button1.Tag is false)
                            {
                                int count = 0;
                                foreach (ListViewItem es in listViewRight.SelectedItems)
                                {

                                    if (listViewLeft.FindItemWithText(es.Text) == null)
                                    {
                                        Move_file(es, currentLeft);
                                    }
                                    if (listViewLeft.FindItemWithText(es.Text) != null && count == 0)
                                    {
                                        count++;
                                        Move_file(es, currentLeft);
                                    }
                                }
                                form4.button1.Tag = true;
                            }

                            if (form4.button3.Tag is false)
                            {
                                int count = 0;
                                foreach (ListViewItem es in listViewRight.SelectedItems)
                                {

                                    if (listViewLeft.FindItemWithText(es.Text) != null && count == 0)
                                    {
                                        count++;
                                    }
                                    else Move_file(es, currentLeft);
                                }
                                form4.button3.Tag = true;

                            }

                            if (form4.button5.Tag is false)
                            {
                                form4.button5.Tag = true;
                            }

                            if (form4.button4.Tag is false)
                            {
                                foreach (ListViewItem es in listViewRight.SelectedItems)
                                {
                                    if (listViewLeft.FindItemWithText(es.Text) == null)
                                    {

                                        Move_file(es, currentLeft);
                                    }
                                }
                                form4.button4.Tag = true;
                                //
                            }

                            if (form4.button2.Tag is false)
                            {
                                foreach (ListViewItem es in listViewRight.SelectedItems)
                                {

                                    Move_file(es, currentLeft);
                                } }
                            form4.Tag = true;
                        }
                        Load_Directory(currentLeft, listViewLeft, tbleft, Hidden);
                        Load_Directory(currentRight, listViewRight, tbright, Hidden);
                        break;
                }
            }
        }

        private void viewToolStripMenuItem1_Click(object sender, EventArgs e) //VIEW TOOLSTRIP FOR LISTVIEW LEFT
        {
            View_File(listViewLeft);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)   //VIEW TOOLSTRIP FOR LISTVIEW RIGHT
        {
            View_File(listViewRight);
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)  //RENAME TOOLSTRIP FOR LISTVIEW LEFT
        {
            if (listViewLeft.SelectedItems.Count == 1)
            {
                if (listViewLeft.SelectedItems[0].Text == "..")
                    MessageBox.Show("Cannot edit this one!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else listViewLeft.SelectedItems[0].BeginEdit();
            }

        }

        private void listViewLeft_AfterLabelEdit(object sender, LabelEditEventArgs e) //AFTER EDIT LISTVIEW LEFT
        {
            if (string.IsNullOrWhiteSpace(e.Label))
            {
                e.CancelEdit = true;
                MessageBox.Show("Invalid Name !!", "Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //
            }
            else
            {

                ListViewItem temp = listViewLeft.SelectedItems[0];
                if (temp.Tag is DirectoryInfo)
                {
                    DirectoryInfo dir = (DirectoryInfo)temp.Tag;
                    Directory.Move(dir.FullName, dir.FullName.Replace(dir.Name, e.Label));
                }
                else
                {
                    FileInfo file = (FileInfo)temp.Tag;
                    File.Move(file.FullName, file.FullName.Replace(file.Name, e.Label));
                }
                Load_Directory(currentLeft, listViewLeft, tbleft, Hidden);
            }
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e) //RENAME TOOLSTRIP FOR LISTVIEW RIGHT
        {
            if (listViewRight.SelectedItems.Count == 1)
            {

                if (listViewRight.SelectedItems[0].Text == "..")
                    MessageBox.Show("Cannot edit this one!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else listViewRight.SelectedItems[0].BeginEdit();
            }
        }

        private void listViewRight_AfterLabelEdit(object sender, LabelEditEventArgs e)    //EVENT AFTER EDIT LIST VIEW RIGHT
        {
            if (string.IsNullOrWhiteSpace(e.Label))
            {
                e.CancelEdit = true;
                MessageBox.Show("Invalid Name !!", "Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //
            }
            else
            {

                ListViewItem temp = listViewLeft.SelectedItems[0];
                if (temp.Tag is DirectoryInfo)
                {
                    DirectoryInfo dir = (DirectoryInfo)temp.Tag;
                    Directory.Move(dir.FullName, dir.FullName.Replace(dir.Name, e.Label));
                }
                else
                {
                    FileInfo file = (FileInfo)temp.Tag;
                    File.Move(file.FullName, file.FullName.Replace(file.Name, e.Label));
                }
                Load_Directory(currentRight, listViewRight, tbright, Hidden);
            }
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)  //EDIT TOOLSTRIP LISTVIEW LEFT
        {
            Edit_file(listViewLeft);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e) //EDIT TOOLSTRIP LISTVIEW RIGHT
        {
            Edit_file(listViewRight);
        }

        private void newFolderToolStripMenuItem1_Click(object sender, EventArgs e) //NEW FOLDER TOOLSTRIP LISTVIEW LEFT
        {
            if (currentLeft != null)
            {
                string name = "New Folder";
                int pos = 1;
                while (listViewLeft.FindItemWithText(name) != null)
                {
                    name = "New Folder " + $"({pos})";
                    pos++;
                }
                currentLeft.CreateSubdirectory(name);
                Load_Directory(currentLeft, listViewLeft, tbleft, Hidden);
                listViewLeft.LabelEdit = true;
                ListViewItem temp = listViewLeft.FindItemWithText(name);
                temp.BeginEdit();
                listViewLeft.LabelEdit = true;
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e) //NEW FOLDER TOOLSTRIP LISTVIEW RIGHT
        {
            if (currentRight != null)
            {
                string name = "New Folder";
                int pos = 1;
                while (listViewRight.FindItemWithText(name) != null)
                {
                    name = "New Folder " + $"({pos})";
                    pos++;
                }
                currentRight.CreateSubdirectory(name);
                Load_Directory(currentRight, listViewRight, tbright, Hidden);
                listViewRight.LabelEdit = true;
                ListViewItem temp = listViewRight.FindItemWithText(name);
                temp.BeginEdit();
                listViewRight.LabelEdit = false;
            }
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)  //COPY TOOLSTRIP LISTVIEW LEFT
        {
            if (listViewLeft.SelectedItems.Count != 0)
            {
                

                int count = 0;
                foreach (ListViewItem var in listViewLeft.SelectedItems)
                {
                    if (var.Text == "..") continue;
                    copyItems.SetValue(var, count);
                    label1.Text = var.Text;
                    count++;
                }
                pasteToolStripMenuItem.Enabled = true;
                pasteToolStripMenuItem1.Enabled = true;
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e) //COPY TOOLSTRIP LISTVIEW RIGHT
        {
            if (listViewRight.SelectedItems.Count != 0)
            {

                int count = 0;
                foreach (ListViewItem var in listViewRight.SelectedItems)
                {
                    if (var.Text == "..") continue;
                    copyItems.SetValue(var, count);
                    label1.Text = copyItems[count].Text;
                    count++;
                }
                pasteToolStripMenuItem.Enabled = true;
                pasteToolStripMenuItem1.Enabled = true;
            }
        }

        private void moveToolStripMenuItem_Click(object sender, EventArgs e) //MOVE TOOLSTRIP LISTVIEW LEFT
        {
            if (currentRight == null || currentLeft == null)
                return;
            if (currentLeft.ToString() != currentRight.ToString())
            {
                if (listViewLeft.SelectedItems.Count != 0)
                {
                    Form4 form4 = new Form4();
                    form4.ShowDialog();

                    if (form4.button1.Tag is false)
                    {
                        int count = 0;
                        foreach (ListViewItem es in listViewLeft.SelectedItems)
                        {
                            if (listViewRight.FindItemWithText(es.Text) == null)
                            {
                                Move_file(es, currentRight);
                            }
                            if (listViewRight.FindItemWithText(es.Text) != null && count == 0)
                            {
                                count++;
                                Move_file(es, currentRight);
                            }
                        }
                        form4.button1.Tag = true;
                        //
                    }

                    if (form4.button3.Tag is false)
                    {
                        int count = 0;
                        foreach (ListViewItem es in listViewLeft.SelectedItems)
                        {
                            if (listViewRight.FindItemWithText(es.Text) != null && count == 0)
                            {
                                count++;
                            }
                            else Move_file(es, currentRight);
                        }
                        form4.button3.Tag = true;
                        //
                    }

                    if (form4.button5.Tag is false)
                    {
                        form4.button5.Tag = true;
                        //
                    }

                    if (form4.button4.Tag is false)
                    {
                        foreach (ListViewItem es in listViewLeft.SelectedItems)
                        {
                            if (listViewRight.FindItemWithText(es.Text) == null)
                            {
                                Move_file(es, currentRight);
                            }
                        }
                        form4.button4.Tag = true;
                        //
                    }

                    if (form4.button2.Tag is false)
                    {
                        foreach (ListViewItem es in listViewLeft.SelectedItems)
                        {
                            Move_file(es, currentRight);
                        }
                        form4.Tag = true;

                    }
                }

                if (listViewRight.SelectedItems.Count != 0)
                {
                    Form4 form4 = new Form4();
                    form4.ShowDialog();
                    if (form4.button1.Tag is false)
                    {
                        int count = 0;
                        foreach (ListViewItem es in listViewRight.SelectedItems)
                        {

                            if (listViewLeft.FindItemWithText(es.Text) == null)
                            {
                                Move_file(es, currentLeft);
                            }
                            if (listViewLeft.FindItemWithText(es.Text) != null && count == 0)
                            {
                                count++;
                                Move_file(es, currentLeft);
                            }
                        }
                        form4.button1.Tag = true;
                        //
                    }

                    if (form4.button3.Tag is false)
                    {
                        int count = 0;
                        foreach (ListViewItem es in listViewRight.SelectedItems)
                        {

                            if (listViewLeft.FindItemWithText(es.Text) != null && count == 0)
                            {
                                count++;
                            }
                            else Move_file(es, currentLeft);
                        }
                        form4.button3.Tag = true;
                        //
                    }

                    if (form4.button5.Tag is false)
                    {
                        form4.button5.Tag = true;
                        //
                    }

                    if (form4.button4.Tag is false)
                    {
                        foreach (ListViewItem es in listViewRight.SelectedItems)
                        {
                            if (listViewLeft.FindItemWithText(es.Text) == null)
                            {

                                Move_file(es, currentLeft);
                            }
                        }
                        form4.button4.Tag = true;
                        //
                    }

                    if (form4.button2.Tag is false)
                    {
                        foreach (ListViewItem es in listViewRight.SelectedItems)
                        {

                            Move_file(es, currentLeft);
                        }
                        form4.Tag = true;


                    }

                }
                Load_Directory(currentLeft, listViewLeft, tbleft, Hidden);
                Load_Directory(currentRight, listViewRight, tbright, Hidden);
            }
            else
            {
                if(listViewLeft.SelectedItems.Count != 0)
                {
                    listViewLeft.SelectedItems[0].BeginEdit();
                }
                if (listViewRight.SelectedItems.Count != 0)
                {
                    listViewLeft.SelectedItems[0].BeginEdit();
                }
            }


        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e) //MOVE TOOLSTRIP TOP LISTVIEW LEFT
        {
            if (currentLeft == null || currentRight == null) return;
            if (currentLeft.ToString() == currentRight.ToString()) return;
            if (listViewLeft.SelectedItems.Count != 0)
            {
                Form4 form4 = new Form4();
                form4.ShowDialog();

                if (form4.button1.Tag is false)
                {
                    int count = 0;
                    foreach (ListViewItem file in listViewLeft.SelectedItems)
                    {
                        if (file.Tag is FileInfo)
                        {
                            FileInfo temp = (FileInfo)file.Tag;
                            if (listViewRight.FindItemWithText(file.Text) != null && count == 0)
                            {
                                Copy_file(temp.FullName, currentRight.FullName + '\\' + temp.Name);
                                count++;
                            }
                            if (listViewRight.FindItemWithText(file.Text) != null && count != 0)
                            {
                                continue;
                            }
                            if (listViewRight.FindItemWithText(file.Text) == null)
                            {
                                Copy_file(temp.FullName, currentRight.FullName + '\\' + temp.Name);
                            }
                        }
                        if (file.Tag is DirectoryInfo)
                        {
                            DirectoryInfo temp = (DirectoryInfo)file.Tag;
                            if (listViewRight.FindItemWithText(file.Text) != null && count == 0)
                            {

                                DirectoryInfo copy = new DirectoryInfo(currentRight.FullName + "\\" + temp.Name);
                                Copy_Folder(temp, copy);

                                count++;
                            }
                            if (listViewRight.FindItemWithText(file.Text) != null && count != 0)
                            {
                                continue;
                            }
                            if (listViewRight.FindItemWithText(file.Text) == null)
                            {

                                DirectoryInfo copy = new DirectoryInfo(currentRight.FullName + "\\" + temp.Name);
                                Copy_Folder(temp, copy);

                            }
                        }
                    }
                    form4.button1.Tag = true;

                }

                if (form4.button2.Tag is false)
                {
                    foreach (ListViewItem file in listViewLeft.SelectedItems)
                    {
                        if (file.Tag is FileInfo)
                        {
                            FileInfo temp = (FileInfo)file.Tag;
                            Copy_file(temp.FullName, currentRight.FullName + '\\' + temp.Name);
                        }
                        if (file.Tag is DirectoryInfo)
                        {
                            DirectoryInfo temp = (DirectoryInfo)file.Tag;
                            DirectoryInfo copy = new DirectoryInfo(currentRight.FullName + "\\" + temp.Name);
                            Copy_Folder(temp, copy);

                        }

                    }
                    form4.button2.Tag = true;
                }

                if (form4.button3.Tag is false)
                {

                    int count = 0;
                    foreach (ListViewItem file in listViewLeft.SelectedItems)
                    {
                        if (file.Tag is FileInfo)
                        {
                            FileInfo temp = (FileInfo)file.Tag;
                            if (listViewRight.FindItemWithText(file.Text) != null && count != 0)
                            {
                                Copy_file(temp.FullName, currentRight.FullName + '\\' + temp.Name);

                            }
                            if (listViewRight.FindItemWithText(file.Text) != null && count == 0)
                            {
                                count++;
                                continue;

                            }
                            if (listViewRight.FindItemWithText(file.Text) == null)
                            {
                                Copy_file(temp.FullName, currentRight.FullName + '\\' + temp.Name);
                            }
                        }
                        if (file.Tag is DirectoryInfo)
                        {
                            DirectoryInfo temp = (DirectoryInfo)file.Tag;

                            if (listViewRight.FindItemWithText(file.Text) != null && count != 0)
                            {
                                DirectoryInfo copy = new DirectoryInfo(currentRight.FullName + "\\" + temp.Name);
                                Copy_Folder(temp, copy);


                            }
                            if (listViewRight.FindItemWithText(file.Text) != null && count == 0)
                            {
                                count++;
                                continue;

                            }
                            if (listViewRight.FindItemWithText(file.Text) == null)
                            {
                                DirectoryInfo copy = new DirectoryInfo(currentRight.FullName + "\\" + temp.Name);
                                Copy_Folder(temp, copy);

                            }
                        }

                    }

                    form4.button3.Tag = true;
                }

                if (form4.button4.Tag is false)
                {
                    foreach (ListViewItem file in listViewLeft.SelectedItems)
                    {
                        if (file.Tag is FileInfo)
                        {
                            FileInfo temp = (FileInfo)file.Tag;
                            if (listViewRight.FindItemWithText(file.Text) == null)
                            {
                                Copy_file(temp.FullName, currentRight.FullName + '\\' + temp.Name);
                            }
                        }
                        if (file.Tag is DirectoryInfo)
                        {
                            DirectoryInfo temp = (DirectoryInfo)file.Tag;
                            if (listViewRight.FindItemWithText(file.Text) == null)
                            {
                                DirectoryInfo copy = new DirectoryInfo(currentRight.FullName + "\\" + temp.Name);
                                Copy_Folder(temp, copy);

                            }
                        }

                    }
                    form4.button4.Tag = true;
                }

                if (form4.button5.Tag is false)
                {
                    form4.button5.Tag = true;
                    //
                }
            }


            if (listViewRight.SelectedItems.Count != 0)
            {
                Form4 form4 = new Form4();
                form4.ShowDialog();

                if (form4.button1.Tag is false)
                {
                    int count = 0;
                    foreach (ListViewItem file in listViewRight.SelectedItems)
                    {
                        if (file.Tag is FileInfo)
                        {
                            FileInfo temp = (FileInfo)file.Tag;
                            if (listViewLeft.FindItemWithText(file.Text) != null && count == 0)
                            {
                                Copy_file(temp.FullName, currentLeft.FullName + '\\' + temp.Name);
                                count++;
                            }
                            if (listViewLeft.FindItemWithText(file.Text) != null && count != 0)
                            {
                                continue;
                            }
                            if (listViewLeft.FindItemWithText(file.Text) == null)
                            {
                                Copy_file(temp.FullName, currentLeft.FullName + '\\' + temp.Name);
                            }
                        }
                        if (file.Tag is DirectoryInfo)
                        {
                            DirectoryInfo temp = (DirectoryInfo)file.Tag;
                            if (listViewLeft.FindItemWithText(file.Text) != null && count == 0)
                            {
                                DirectoryInfo copy = new DirectoryInfo(currentLeft.FullName + "\\" + temp.Name);
                                Copy_Folder(temp, copy);
                                count++;
                            }
                            if (listViewLeft.FindItemWithText(file.Text) != null && count != 0)
                            {
                                continue;
                            }
                            if (listViewLeft.FindItemWithText(file.Text) == null)
                            {
                                DirectoryInfo copy = new DirectoryInfo(currentLeft.FullName + "\\" + temp.Name);
                                Copy_Folder(temp, copy);
                            }
                        }
                    }
                    form4.button1.Tag = true;

                }

                if (form4.button2.Tag is false)
                {
                    foreach (ListViewItem file in listViewRight.SelectedItems)
                    {
                        if (file.Tag is FileInfo)
                        {
                            FileInfo temp = (FileInfo)file.Tag;
                            Copy_file(temp.FullName, currentLeft.FullName + '\\' + temp.Name);
                        }
                        if (file.Tag is DirectoryInfo)
                        {
                            DirectoryInfo temp = (DirectoryInfo)file.Tag;
                            DirectoryInfo copy = new DirectoryInfo(currentLeft.FullName + "\\" + temp.Name);
                            Copy_Folder(temp, copy);
                        }
                    }
                    form4.button2.Tag = true;
                }

                if (form4.button3.Tag is false)
                {
                    int count = 0;
                    foreach (ListViewItem file in listViewRight.SelectedItems)
                    {
                        if (file.Tag is FileInfo)
                        {
                            FileInfo temp = (FileInfo)file.Tag;
                            if (listViewLeft.FindItemWithText(file.Text) != null && count != 0)
                            {
                                Copy_file(temp.FullName, currentLeft.FullName + '\\' + temp.Name);

                            }
                            if (listViewLeft.FindItemWithText(file.Text) != null && count == 0)
                            {
                                count++;
                                continue;

                            }
                            if (listViewLeft.FindItemWithText(file.Text) == null)
                            {
                                Copy_file(temp.FullName, currentLeft.FullName + '\\' + temp.Name);
                            }
                        }
                        if (file.Tag is DirectoryInfo)
                        {
                            DirectoryInfo temp = (DirectoryInfo)file.Tag;
                            if (listViewLeft.FindItemWithText(file.Text) != null && count != 0)
                            {
                                DirectoryInfo copy = new DirectoryInfo(currentLeft.FullName + "\\" + temp.Name);
                                Copy_Folder(temp, copy);

                            }
                            if (listViewLeft.FindItemWithText(file.Text) != null && count == 0)
                            {
                                count++;
                                continue;

                            }
                            if (listViewLeft.FindItemWithText(file.Text) == null)
                            {
                                DirectoryInfo copy = new DirectoryInfo(currentLeft.FullName + "\\" + temp.Name);
                                Copy_Folder(temp, copy);
                            }
                        }
                    }
                    form4.button3.Tag = true;
                }

                if (form4.button4.Tag is false)
                {
                    foreach (ListViewItem file in listViewRight.SelectedItems)
                    {
                        if (file.Tag is FileInfo)
                        {
                            FileInfo temp = (FileInfo)file.Tag;
                            if (listViewLeft.FindItemWithText(file.Text) == null)
                            {
                                Copy_file(temp.FullName, currentLeft.FullName + '\\' + temp.Name);
                            }
                        }
                        if (file.Tag is DirectoryInfo)
                        {
                            DirectoryInfo temp = (DirectoryInfo)file.Tag;
                            if (listViewLeft.FindItemWithText(file.Text) == null)
                            {
                                DirectoryInfo copy = new DirectoryInfo(currentLeft.FullName + "\\" + temp.Name);
                                Copy_Folder(temp, copy);
                            }
                        }
                    }
                    form4.button4.Tag = true;
                }

                if (form4.button5.Tag is false)
                {
                    form4.button5.Tag = true;
                    //
                }
            }

            Load_Directory(currentLeft, listViewLeft, tbleft, Hidden);
            Load_Directory(currentRight, listViewRight, tbright, Hidden);
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e) //VIEW TOOLSTRIP LISTVIEW LEFT
        {
            if (listViewLeft.SelectedItems.Count != 0)
            {
                View_File(listViewLeft);
            }
            if (listViewRight.SelectedItems.Count != 0)
            {
                View_File(listViewRight);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e) //EDIT TOOLSTRIP LISTVIEW LEFT
        {
            if (listViewLeft.SelectedItems.Count != 0)
            {
                Edit_file(listViewLeft);
            }
            if (listViewRight.SelectedItems.Count != 0)
            {
                Edit_file(listViewRight);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) //DELETE TOOLSTRIP TOP
        {
            if (listViewLeft.SelectedItems.Count != 0)
            {
                Delete_files(currentLeft, listViewLeft, tbleft);
            }
            if (listViewRight.SelectedItems.Count != 0)
            {
                Delete_files(currentRight, listViewRight, tbright);
            }
        }

        private void newFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewLeft.SelectedItems.Count != 0)
            {
                string name = "New Folder";
                int pos = 1;
                while (listViewLeft.FindItemWithText(name) != null)
                {
                    name = "New Folder " + $"({pos})";
                    pos++;
                }
                currentLeft.CreateSubdirectory(name);
                Load_Directory(currentLeft, listViewLeft, tbleft, Hidden);
                ListViewItem temp = listViewLeft.FindItemWithText(name);
                temp.BeginEdit();
            }
            if (listViewRight.SelectedItems.Count != 0)
            {
                string name = "New Folder";
                int pos = 1;
                while (listViewRight.FindItemWithText(name) != null)
                {
                    name = "New Folder " + $"({pos})";
                    pos++;
                }
                currentRight.CreateSubdirectory(name);
                Load_Directory(currentRight, listViewRight, tbright, Hidden);
                ListViewItem temp = listViewRight.FindItemWithText(name);
                listViewRight.LabelEdit = true;
                temp.BeginEdit();
            }
        } //NEW FOLDER TOOLSTRIP TOP

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e) //PASTE TOOLSTRIP TO LISTVIEW RIGHTS
        {

            Form4 form4 = new Form4();
            form4.ShowDialog();

            if (form4.button1.Tag is false)
            {
                int count = 0;
                foreach (ListViewItem file in copyItems)
                {
                    if (file != null)
                    {
                        if (file.Tag is FileInfo)
                        {
                            FileInfo temp = (FileInfo)file.Tag;
                            if (listViewRight.FindItemWithText(file.Text) != null && count == 0)
                            {
                                Copy_file(temp.FullName, currentRight.FullName + '\\' + temp.Name);
                                count++;
                            }
                            if (listViewRight.FindItemWithText(file.Text) != null && count != 0)
                            {
                                continue;
                            }
                            if (listViewRight.FindItemWithText(file.Text) == null)
                            {
                                Copy_file(temp.FullName, currentRight.FullName + '\\' + temp.Name);
                            }
                        }
                        if (file.Tag is DirectoryInfo)
                        {
                            DirectoryInfo temp = (DirectoryInfo)file.Tag;
                            if (listViewRight.FindItemWithText(file.Text) != null && count == 0)
                            {

                                DirectoryInfo copy = new DirectoryInfo(currentRight.FullName + "\\" + temp.Name);
                                Copy_Folder(temp, copy);

                                count++;
                            }
                            if (listViewRight.FindItemWithText(file.Text) != null && count != 0)
                            {
                                continue;
                            }
                            if (listViewRight.FindItemWithText(file.Text) == null)
                            {

                                DirectoryInfo copy = new DirectoryInfo(currentRight.FullName + "\\" + temp.Name);
                                Copy_Folder(temp, copy);

                            }

                        }
                    }
                    if (isCut == true)
                    {
                        if (file.Tag is DirectoryInfo)
                        {
                            DirectoryInfo temp = (DirectoryInfo)file.Tag;
                            temp.Delete(true);
                        }
                        else
                        {
                            FileInfo temp = (FileInfo)file.Tag;
                            temp.Delete();
                        }
                        isCut = false;
                    }
                }
                form4.button1.Tag = true;

            }

            if (form4.button2.Tag is false)
            {
                foreach (ListViewItem file in copyItems)
                {
                    if (file != null)
                    {
                        if (file.Tag is FileInfo)
                        {
                            FileInfo temp = (FileInfo)file.Tag;
                            Copy_file(temp.FullName, currentRight.FullName + '\\' + temp.Name);
                        }
                        if (file.Tag is DirectoryInfo)
                        {
                            DirectoryInfo temp = (DirectoryInfo)file.Tag;
                            DirectoryInfo copy = new DirectoryInfo(currentRight.FullName + "\\" + temp.Name);
                            Copy_Folder(temp, copy);

                        }

                    }
                    if (isCut == true)
                    {
                        if (file.Tag is DirectoryInfo)
                        {
                            DirectoryInfo temp = (DirectoryInfo)file.Tag;
                            temp.Delete(true);
                        }
                        else
                        {
                            FileInfo temp = (FileInfo)file.Tag;
                            temp.Delete();
                        }
                        isCut = false;
                    }
                }
                form4.button2.Tag = true;
            }

            if (form4.button3.Tag is false)
            {

                int count = 0;
                foreach (ListViewItem file in copyItems)
                {
                    if (file != null)
                    {
                        if (file.Tag is FileInfo)
                        {
                            FileInfo temp = (FileInfo)file.Tag;
                            if (listViewRight.FindItemWithText(file.Text) != null && count != 0)
                            {
                                Copy_file(temp.FullName, currentRight.FullName + '\\' + temp.Name);

                            }
                            if (listViewRight.FindItemWithText(file.Text) != null && count == 0)
                            {
                                count++;
                                continue;

                            }
                            if (listViewRight.FindItemWithText(file.Text) == null)
                            {
                                Copy_file(temp.FullName, currentRight.FullName + '\\' + temp.Name);
                            }
                        }
                        if (file.Tag is DirectoryInfo)
                        {
                            DirectoryInfo temp = (DirectoryInfo)file.Tag;

                            if (listViewRight.FindItemWithText(file.Text) != null && count != 0)
                            {
                                DirectoryInfo copy = new DirectoryInfo(currentRight.FullName + "\\" + temp.Name);
                                Copy_Folder(temp, copy);


                            }
                            if (listViewRight.FindItemWithText(file.Text) != null && count == 0)
                            {
                                count++;
                                continue;

                            }
                            if (listViewRight.FindItemWithText(file.Text) == null)
                            {
                                DirectoryInfo copy = new DirectoryInfo(currentRight.FullName + "\\" + temp.Name);
                                Copy_Folder(temp, copy);

                            }
                        }

                    }
                    if (isCut == true)
                    {
                        if (file.Tag is DirectoryInfo)
                        {
                            DirectoryInfo temp = (DirectoryInfo)file.Tag;
                            temp.Delete(true);
                        }
                        else
                        {
                            FileInfo temp = (FileInfo)file.Tag;
                            temp.Delete();
                        }
                        isCut = false;
                    }
                }

                form4.button3.Tag = true;
            }

            if (form4.button4.Tag is false)
            {
                foreach (ListViewItem file in copyItems)
                {
                    if (file != null)
                    {
                        if (file.Tag is FileInfo)
                        {
                            FileInfo temp = (FileInfo)file.Tag;
                            if (listViewRight.FindItemWithText(file.Text) == null)
                            {
                                Copy_file(temp.FullName, currentRight.FullName + '\\' + temp.Name);
                            }
                        }
                        if (file.Tag is DirectoryInfo)
                        {
                            DirectoryInfo temp = (DirectoryInfo)file.Tag;
                            if (listViewRight.FindItemWithText(file.Text) == null)
                            {
                                DirectoryInfo copy = new DirectoryInfo(currentRight.FullName + "\\" + temp.Name);
                                Copy_Folder(temp, copy);

                            }
                        }

                    }
                    if (isCut == true)
                    {
                        if (file.Tag is DirectoryInfo)
                        {
                            DirectoryInfo temp = (DirectoryInfo)file.Tag;
                            temp.Delete(true);
                        }
                        else
                        {
                            FileInfo temp = (FileInfo)file.Tag;
                            temp.Delete();
                        }
                        isCut = false;
                    }
                }
                form4.button4.Tag = true;
            }

            if (form4.button5.Tag is false)
            {
                form4.button5.Tag = true;
                //
            }
            pasteToolStripMenuItem.Enabled = false;
            pasteToolStripMenuItem1.Enabled = false;
            Load_Directory(currentLeft, listViewLeft, tbleft, Hidden);
            Load_Directory(currentRight, listViewRight, tbright, Hidden);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e) //PASTE TOOLSTRIP TO LISTVIEW LEFT
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();

            if (form4.button1.Tag is false)
            {
                int count = 0;
                foreach (ListViewItem file in copyItems)
                {
                    if (file != null)
                    {

                        if (file.Tag is FileInfo)
                        {

                            FileInfo temp = (FileInfo)file.Tag;
                            if (listViewLeft.FindItemWithText(file.Text) != null && count == 0)
                            {

                                Copy_file(temp.FullName, currentLeft.FullName + '\\' + temp.Name);
                                count++;
                            }
                            if (listViewLeft.FindItemWithText(file.Text) != null && count != 0)
                            {

                                continue;
                            }
                            if (listViewLeft.FindItemWithText(file.Text) == null)
                            {

                                Copy_file(temp.FullName, currentLeft.FullName + '\\' + temp.Name);
                            }
                        }
                        if (file.Tag is DirectoryInfo)
                        {
                            DirectoryInfo temp = (DirectoryInfo)file.Tag;
                            if (listViewLeft.FindItemWithText(file.Text) != null && count == 0)
                            {

                                DirectoryInfo copy = new DirectoryInfo(currentLeft.FullName + "\\" + temp.Name);
                                Copy_Folder(temp, copy);

                                count++;
                            }
                            if (listViewLeft.FindItemWithText(file.Text) != null && count != 0)
                            {
                                continue;
                            }
                            if (listViewLeft.FindItemWithText(file.Text) == null)
                            {

                                DirectoryInfo copy = new DirectoryInfo(currentLeft.FullName + "\\" + temp.Name);
                                Copy_Folder(temp, copy);

                            }
                        }
                    }
                    if (isCut == true)
                    {
                        if (file.Tag is DirectoryInfo)
                        {
                            DirectoryInfo temp = (DirectoryInfo)file.Tag;
                            temp.Delete(true);
                        }
                        else
                        {
                            FileInfo temp = (FileInfo)file.Tag;
                            temp.Delete();
                        }
                        isCut = false;
                    }
                }
                form4.button1.Tag = true;

            }

            if (form4.button2.Tag is false)
            {
                foreach (ListViewItem file in copyItems)
                {
                    if (file != null)
                    {
                        if (file.Tag is FileInfo)
                        {
                            FileInfo temp = (FileInfo)file.Tag;
                            Copy_file(temp.FullName, currentLeft.FullName + '\\' + temp.Name);
                        }
                        if (file.Tag is DirectoryInfo)
                        {
                            DirectoryInfo temp = (DirectoryInfo)file.Tag;
                            DirectoryInfo copy = new DirectoryInfo(currentLeft.FullName + "\\" + temp.Name);
                            Copy_Folder(temp, copy);

                        }
                    }
                    if (isCut == true)
                    {
                        if (file.Tag is DirectoryInfo)
                        {
                            DirectoryInfo temp = (DirectoryInfo)file.Tag;
                            temp.Delete(true);
                        }
                        else
                        {
                            FileInfo temp = (FileInfo)file.Tag;
                            temp.Delete();
                        }
                        isCut = false;
                    }
                }
                form4.button2.Tag = true;
            }

            if (form4.button3.Tag is false)
            {

                int count = 0;
                foreach (ListViewItem file in copyItems)
                {
                    if (file != null)
                    {
                        if (file.Tag is FileInfo)
                        {
                            FileInfo temp = (FileInfo)file.Tag;
                            if (listViewLeft.FindItemWithText(file.Text) != null && count != 0)
                            {
                                Copy_file(temp.FullName, currentLeft.FullName + '\\' + temp.Name);

                            }
                            if (listViewLeft.FindItemWithText(file.Text) != null && count == 0)
                            {
                                count++;
                                continue;

                            }
                            if (listViewLeft.FindItemWithText(file.Text) == null)
                            {
                                Copy_file(temp.FullName, currentLeft.FullName + '\\' + temp.Name);
                            }
                        }
                        if (file.Tag is DirectoryInfo)
                        {
                            DirectoryInfo temp = (DirectoryInfo)file.Tag;

                            if (listViewLeft.FindItemWithText(file.Text) != null && count != 0)
                            {
                                DirectoryInfo copy = new DirectoryInfo(currentLeft.FullName + "\\" + temp.Name);
                                Copy_Folder(temp, copy);


                            }
                            if (listViewLeft.FindItemWithText(file.Text) != null && count == 0)
                            {
                                count++;
                                continue;

                            }
                            if (listViewLeft.FindItemWithText(file.Text) == null)
                            {
                                DirectoryInfo copy = new DirectoryInfo(currentLeft.FullName + "\\" + temp.Name);
                                Copy_Folder(temp, copy);

                            }
                        }
                    }
                    if (isCut == true)
                    {
                        if (file.Tag is DirectoryInfo)
                        {
                            DirectoryInfo temp = (DirectoryInfo)file.Tag;
                            temp.Delete(true);
                        }
                        else
                        {
                            FileInfo temp = (FileInfo)file.Tag;
                            temp.Delete();
                        }
                        isCut = false;
                    }

                }

                form4.button3.Tag = true;
            }

            if (form4.button4.Tag is false)
            {
                foreach (ListViewItem file in copyItems)
                {
                    if (file != null)
                    {
                        if (file.Tag is FileInfo)
                        {
                            FileInfo temp = (FileInfo)file.Tag;
                            if (listViewLeft.FindItemWithText(file.Text) == null)
                            {
                                Copy_file(temp.FullName, currentLeft.FullName + '\\' + temp.Name);
                            }
                        }
                        if (file.Tag is DirectoryInfo)
                        {
                            DirectoryInfo temp = (DirectoryInfo)file.Tag;
                            if (listViewLeft.FindItemWithText(file.Text) == null)
                            {
                                DirectoryInfo copy = new DirectoryInfo(currentLeft.FullName + "\\" + temp.Name);
                                Copy_Folder(temp, copy);

                            }
                        }
                    }
                    if (isCut == true)
                    {
                        if (file.Tag is DirectoryInfo)
                        {
                            DirectoryInfo temp = (DirectoryInfo)file.Tag;
                            temp.Delete(true);
                        }
                        else
                        {
                            FileInfo temp = (FileInfo)file.Tag;
                            temp.Delete();
                        }
                        isCut = false;
                    }

                }
                form4.button4.Tag = true;
            }

            if (form4.button5.Tag is false)
            {
                form4.button5.Tag = true;
                return;
            }
            pasteToolStripMenuItem.Enabled = false;
            pasteToolStripMenuItem1.Enabled = false;
            Load_Directory(currentLeft, listViewLeft, tbleft, Hidden);
            Load_Directory(currentRight, listViewRight, tbright, Hidden);
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)   //HELP TOOLSTRIP
        {
            System.Diagnostics.Process.Start("Help.pdf");
        }


        private void cutToolStripMenuItem_Click(object sender, EventArgs e) //CUT TOOLSTRIP LEFT
        {
            if (listViewLeft.SelectedItems.Count != 0)
            {
                copyItems = new ListViewItem[20];

                int count = 0;
                foreach (ListViewItem var in listViewLeft.SelectedItems)
                {
                    if (var.Text == "..") continue;
                    copyItems.SetValue(var, count);
                    label1.Text = var.Text;
                    count++;
                }
                pasteToolStripMenuItem.Enabled = true;
                pasteToolStripMenuItem1.Enabled = true;
                isCut = true;
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e) //CUT TOOLSTRIP RIGHT
        {
            if (listViewRight.SelectedItems.Count != 0)
            {
              

                int count = 0;
                foreach (ListViewItem var in listViewRight.SelectedItems)
                {
                    if (var.Text == "..") continue;
                    copyItems.SetValue(var, count);
                    label1.Text = var.Text;
                    count++;
                }
                pasteToolStripMenuItem.Enabled = true;
                pasteToolStripMenuItem1.Enabled = true;
                isCut = true;
            }
        }
    }
}
