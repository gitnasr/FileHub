namespace FD
{
    public partial class Form1 : Form
    {
        private enum LastAccessed
        {
            LeftListBox,
            RightListBox
        }
        private LastAccessed lastAccessed;
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
        private void FillListBox(ListBox list, TextBox currentTextBox)
        {
            if (list.SelectedItem is DriveInfo driver)
            {
                if (driver.IsReady)
                {
                    currentTextBox.Text = driver.Name;
                    LoadDirectory(driver.RootDirectory.FullName, list);
                }
            }
            else if (list.SelectedItem is DirectoryInfo directory)
            {
                currentTextBox.Text = directory.FullName;
                LoadDirectory(directory.FullName, list);
            }
        }

        private void Navigate()
        {
            if (lastAccessed == LastAccessed.LeftListBox)
            {

                FillListBox(listBox1, Path1);

            }
            else
            {
                FillListBox(listBox2, Path2);
            }
        }
        private void LoadDirectory(string path, ListBox listBoxToAdd)
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
            string CurrentPath = string.Empty;
            ListBox currentListBox = null;
            TextBox textBox = null;
            if (lastAccessed == LastAccessed.LeftListBox)
            {

                CurrentPath = Path1.Text;
                currentListBox = listBox1;
                textBox = Path1;


            }
            else
            {
                CurrentPath = Path2.Text;
                currentListBox = listBox2;
                textBox = Path2;
            }

       

            if (CurrentPath.Equals(string.Empty))
            {
                back.Enabled = false;
                return;
            }
            back.Enabled = true;

            DirectoryInfo CurrentDirectory = new DirectoryInfo(CurrentPath);



            DirectoryInfo ParentDirectory = CurrentDirectory.Parent;

            if (ParentDirectory == null)
            {
                LoadCurrentDrivers(currentListBox);
                textBox.Text = string.Empty;
                return;
            }

            LoadDirectory(ParentDirectory.FullName, currentListBox);

            if (lastAccessed == LastAccessed.LeftListBox)
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
            lastAccessed = LastAccessed.LeftListBox;

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            lastAccessed = LastAccessed.RightListBox;

        }
    }
}
