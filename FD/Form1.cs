namespace FD
{
    public partial class Form1 : Form
    {

        ListBox CurrentListBox ;
        TextBox CurrentTextBox ;

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
                    listToShow.Items.Add(driver);


            }
        }
        private void FillListBox(ListBox list)
        {
            if (list.SelectedItem is DriveInfo driver)
            {
                if (driver.IsReady)
                {
                    CurrentTextBox.Text = driver.Name;
                    LoadFilesAndDirectories(driver.RootDirectory.FullName, list);
                }
            }
            else if (list.SelectedItem is DirectoryInfo directory)
            {
                CurrentTextBox.Text = directory.FullName;
                LoadFilesAndDirectories(directory.FullName, list);
            }
        }

        private void Navigate()
        {
            if (CurrentListBox == listBox1)
            {
                CurrentTextBox = Path1;
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
                    listBoxToAdd.Items.Add(dir);
                }

                foreach (FileInfo file in directory.GetFiles())
                {
                    listBoxToAdd.Items.Add(file);
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

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            CurrentListBox = listBox2;
        }
    }
}
