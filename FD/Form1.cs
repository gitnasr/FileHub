namespace FD
{
    public partial class Form1 : Form
    {

        ListBox CurrentListBox;
        TextBox CurrentTextBox;

        public Form1()
        {
            InitializeComponent();
            LoadCurrentDrivers(listBox1);
            LoadCurrentDrivers(listBox2);
        }
        private void LoadCurrentDrivers(ListBox listToShow)
        {
            back.Enabled = false;

            DriveInfo[] drivers = DriveInfo.GetDrives();
            listToShow.Items.Clear();

            foreach (DriveInfo driver in drivers)
            {
                listToShow.Items.Add(new ListItem
                {
                    DisplayText = $"🖴 {driver.Name}",
                    Data = driver
                });
            }
        }
        private void FillListBox(ListBox list)
        {


            if (list.SelectedItem is ListItem selectedItem)
            {
                if (selectedItem.Data is DriveInfo driver)
                {
                    if (driver.IsReady)
                    {
                        CurrentTextBox.Text = driver.Name;
                        LoadFilesAndDirectories(driver.RootDirectory.FullName, list);
                    }
                }
                else if (selectedItem.Data is DirectoryInfo directory)
                {
                    CurrentTextBox.Text = directory.FullName;
                    LoadFilesAndDirectories(directory.FullName, list);
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
            try
            {
                DirectoryInfo directory = new DirectoryInfo(path);
                listBoxToAdd.Items.Clear();

                foreach (DirectoryInfo dir in directory.GetDirectories())
                {
                    listBoxToAdd.Items.Add(new ListItem
                    {
                        DisplayText = $"📁 {dir.Name}",
                        Data = dir
                    });
                }

                foreach (FileInfo file in directory.GetFiles())
                {
                    listBoxToAdd.Items.Add(new ListItem
                    {
                        DisplayText = $"📄 {file.Name}",
                        Data = file
                    });
                }

                back.Enabled = true;
            }

            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: {ex.Message}");
            }
        }



        private void back_Click(object sender, EventArgs e)
        {

            if (CurrentTextBox.Text.Equals(string.Empty))
            {
                back.Enabled = false;
                return;
            }
            back.Enabled = true;

            DirectoryInfo CurrentDirectory = new DirectoryInfo(CurrentTextBox.Text);



            DirectoryInfo ParentDirectory = CurrentDirectory.Parent;

            if (ParentDirectory == null)
            {
                LoadCurrentDrivers(CurrentListBox);
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
            CurrentListBox = listBox1;
            CurrentTextBox = Path1;

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            CurrentListBox = listBox2;
            CurrentTextBox = Path2;
        }

        private void moveToRight_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is ListItem selectedItem)
            {
                Move(selectedItem, Path2.Text);
            }
        }

        private void Move(ListItem src, string dest)
        {
            try
            {
                if (src.Data != null)
                {
                    string srcPath = src.Data.ToString();
                    if (!string.IsNullOrEmpty(srcPath))
                    {
                        string fileName = Path.GetFileName(srcPath);

                        string fullDest = @$"{dest}{fileName}".ToString();
                        if (srcPath.Equals(fullDest))
                        {
                            MessageBox.Show("How dare you move in the same folder!");
                            return;
                        }
                        if (src.Data is DirectoryInfo)
                        {
                            Directory.Move($@"{srcPath}", @$"{dest}\{fileName}");
                        }
                        else
                        {
                            File.Move($@"{srcPath}", @$"{dest}\{fileName}");
                        }

                        LoadFilesAndDirectories(Path2.Text, listBox2);
                        LoadFilesAndDirectories(Path1.Text, listBox1);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR]: {ex}");
            }
        }

        private void moveToLeft_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem is ListItem selectedItem)
            {
                Move(selectedItem, Path1.Text);
            }
        }
    }
}
