using System.Diagnostics;

namespace FD
{
    public partial class Form1 : Form
    {

        ListBox CurrentListBox;
        TextBox CurrentTextBox;
        Files FileManager = new Files();
        public Form1()
        {
            InitializeComponent();
            FileManager.LoadCurrentDrivers(listBox1, ref back);
            FileManager.LoadCurrentDrivers(listBox2, ref back);
        }

        private void FillListBox(ListBox list)
        {


            if (list.SelectedItem is ListItem selectedItem)
            {
                if (selectedItem.ItemData is DriveInfo driver)
                {
                    if (driver.IsReady)
                    {
                        CurrentTextBox.Text = driver.Name;
                        LoadFilesAndDirectories(driver.RootDirectory.FullName, list);
                    }
                }
                else if (selectedItem.ItemData is DirectoryInfo directory)
                {
                    CurrentTextBox.Text = directory.FullName;
                    LoadFilesAndDirectories(directory.FullName, list);
                }
                else if (selectedItem.ItemData is FileInfo file)
                {
                    FileManager.OpenFile(file.FullName, out bool result);
                    if (!result)
                    {
                        MessageBox.Show("File cannot be opened", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Navigate()
        {
            if (CurrentListBox == listBox1)
            {

                FillListBox(listBox1);

            }
            else
            {
                CurrentTextBox = Path2;
                FillListBox(listBox2);
            }
        }
        private void LoadFilesAndDirectories(string path, ListBox listBoxToAdd)
        {

            int index = listBoxToAdd.TopIndex;
            try
            {
                listBoxToAdd.Items.Clear();
                DirectoryInfo directory = FileManager.GetDirectoryInfo(path);
                listBoxToAdd.Items.AddRange(FileManager.GetDirectoriesOfDirectory(directory));
                listBoxToAdd.Items.AddRange(FileManager.GetFilesFromPath(directory));


                back.Enabled = true;
                listBoxToAdd.TopIndex = index;
            }

            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: {ex}");
            }
        }

        private bool CanBanGoBack()
        {
            return CurrentTextBox.Text != string.Empty;
        }


        private void back_Click(object sender, EventArgs e)
        {

           

            DirectoryInfo CurrentDirectory = FileManager.GetDirectoryInfo(CurrentTextBox.Text);


            if (CurrentDirectory != null)
            {


                DirectoryInfo ParentDirectory = CurrentDirectory.Parent;

                if (ParentDirectory == null)
                {
                    FileManager.LoadCurrentDrivers(CurrentListBox, ref back);
                    CurrentTextBox.Text = string.Empty;
                    return;
                }

                LoadFilesAndDirectories(ParentDirectory.FullName, CurrentListBox);

                if (CurrentListBox == listBox1)
                {

                    Path1.Text = ParentDirectory.FullName;


                }
                else
                {
                    Path2.Text = ParentDirectory.FullName;
                }

            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Navigate();
        }

        private void listBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Navigate();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCurrentControls(listBox1, Path1);
        }
      

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCurrentControls(listBox2, Path2);
        }

        private void UpdateCurrentControls(ListBox listBox, TextBox textBox)
        {
            CurrentListBox = listBox;
            CurrentTextBox = textBox;
            back.Enabled = CanBanGoBack();
        }
    


        private void moveToRight_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is ListItem selectedItem)
            {
                FileManager.MoveFile(selectedItem, Path2.Text);
                RefreshList();
            }
        }



        private void moveToLeft_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem is ListItem selectedItem)
            {
                FileManager.MoveFile(selectedItem, Path1.Text);
                RefreshList();
            }
        }


        private void copyTo_Click(object sender, EventArgs e)
        {

            if (listBox1.SelectedItem is ListItem selectedItem)
            {
                string dest = Path2.Text;
                FileManager.Copy(selectedItem.ItemData.ToString(), dest);
                RefreshList(listBox2);
            }
         
            else
            {
                MessageBox.Show("Please select a file to copy -_-");
            }

        }

        private void RefreshList(ListBox? listBox = null)
        {
            if (listBox == null)
            {
                LoadFilesAndDirectories(Path2.Text, listBox2);
                LoadFilesAndDirectories(Path1.Text, listBox1);
                return;
            }
            switch (listBox.Name)
            {
                case "listBox1":
                    LoadFilesAndDirectories(Path1.Text, listBox1);
                    break;
                case "listBox2":
                    LoadFilesAndDirectories(Path2.Text, listBox2);
                    break;
            }
        }
    

        private void delete_Click(object sender, EventArgs e)
        {
            if (CurrentListBox !=null && CurrentListBox.SelectedItem != null)
            {

                ListItem ItemToDelete = (ListItem)CurrentListBox.SelectedItem;

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show($"THIS IS DISTRUCTIVE ACTION!!!! \nAre you sure you want to delete this file ({ItemToDelete.ItemData})?", "Delete File", buttons, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                   bool isDeleted = FileManager.DeleteFile(ItemToDelete.ItemData.ToString());

                    if (isDeleted) { 
                        MessageBox.Show("File Deleted Successfully\n I hope you know what're you doing ...","DONE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("File Deletion Failed\n Please check the file path and try again ...", "FAILED", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                RefreshList(CurrentListBox);

            }
            else
            {
                MessageBox.Show("Please select a file to delete -_-");
            }
         
        
        }
    }

}
