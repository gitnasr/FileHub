using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FD
{
    class Files
    {
        public void LoadCurrentDrivers(ListBox listToShow, ref Button BackButton)
        {
            BackButton.Enabled = false;

            DriveInfo[] drivers = DriveInfo.GetDrives();
            listToShow.Items.Clear();

            foreach (DriveInfo driver in drivers)
            {
                listToShow.Items.Add(new ListItem
                {
                    DisplayText = $"🖴 {driver.Name}",
                    ItemData = driver
                });
            }
        }
        public void CopyDirectory(string Source, string Destination)
        {
            DirectoryInfo sourceDirectory = new DirectoryInfo(Source);
            DirectoryInfo[] subDirectories = sourceDirectory.GetDirectories();
            FileInfo[] files = sourceDirectory.GetFiles();

            if (!Directory.Exists(Destination))
            {
                Directory.CreateDirectory(Destination);
            }

            foreach (FileInfo file in files)
            {
                string destFilePath = Path.Combine(Destination, file.Name);
                file.CopyTo(destFilePath, true);
            }

            foreach (DirectoryInfo subDirectory in subDirectories)
            {
                string newDestDir = Path.Combine(Destination, subDirectory.Name);
                CopyDirectory(subDirectory.FullName, newDestDir);
            }
        }
        public void Copy(string srcPath, string dest)
        {
            try
            {

                if (File.Exists(srcPath))
                {
                    string fileName = Path.GetFileName(srcPath);
                    string destFilePath = Path.Combine(dest, fileName);
                    File.Copy(srcPath, destFilePath);
                }
                if (Directory.Exists(srcPath))
                {
                    string dirName = Path.GetFileName(srcPath);
                    string ParentDirPath = Path.Combine(dest, dirName);
                    Directory.CreateDirectory(ParentDirPath);
                    CopyDirectory(srcPath, ParentDirPath);
                }
              
            }
            catch (Exception ErrorWhileCopy)
            {

                throw;
            }

        }

        public void MoveFile(ListItem SelectedItem, string Destination)
        {
            try
            {

                string srcPath = SelectedItem.ItemData.ToString();
                if (!string.IsNullOrEmpty(srcPath))
                {
                    string fileName = Path.GetFileName(srcPath);

                    string fullDest = Path.Combine(Destination, fileName);
                    if (srcPath.Equals(fullDest))
                    {
                        throw new Exception("Cannot move file to the same directory");
                    }
                    string PathToMove = Path.Combine(Destination, fileName);

                    if (SelectedItem.ItemData is DirectoryInfo)
                    {
                        Directory.Move(srcPath, PathToMove);

                    }
                    else
                    {
                        File.Move(srcPath, PathToMove);
                    }

                   
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool DeleteFile(string Path) {
            try
            {
                if (File.Exists(Path))
                {
                    File.Delete(Path);
                    return true;
                }
                if (Directory.Exists(Path))
                {
                    Directory.Delete(Path, true);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void OpenFile(string Path , out bool isOpen )
        {

            try
            {
                Process.Start(new ProcessStartInfo(Path) { UseShellExecute = true });
                isOpen = true;
            }
            catch (Exception)
            {
                isOpen = false;
            }
        }
        public void GetFileEmjoiFromPath(string Path, out string Emoji)
        {
            // get file extension
            string extension = Path.Split('.').Last();
            switch (extension)
            {
                case "txt":
                    Emoji = "📄";
                    break;
                case "pdf":
                    Emoji = "📄";
                    break;
                case "doc":
                    Emoji = "📄";
                    break;
                case "docx":
                    Emoji = "📄";
                    break;
                case "xls":
                    Emoji = "📄";
                    break;
                case "xlsx":
                    Emoji = "📄";
                    break;
                case "ppt":
                    Emoji = "📄";
                    break;
                case "pptx":
                    Emoji = "📄";
                    break;
                case "jpg":
                    Emoji = "🖼";
                    break;
                case "jpeg":
                    Emoji = "🖼";
                    break;
                case "png":
                    Emoji = "🖼";
                    break;
                case "gif":
                    Emoji = "🖼";
                    break;
                case "mp3":
                    Emoji = "🎵";
                    break;
                case "mp4":
                    Emoji = "🎥";
                    break;
                case "avi":
                    Emoji = "🎥";
                    break;
                case "mkv":
                    Emoji = "🎥";
                    break;
                case "mov":
                    Emoji = "🎥";
                    break;
                case "zip":
                    Emoji = "📦";
                    break;
                case "rar":
                    Emoji = "📦";
                    break;
                case "7z":
                    Emoji = "📦";
                    break;
                default:
                    Emoji = "📄";
                    break;
            }
        }

        public List<ListItem> GetDirectoriesFromPath(string Path)
        {
            List<ListItem> directories = new List<ListItem>();
            DirectoryInfo directory = new DirectoryInfo(Path);
            DirectoryInfo[] subDirectories = directory.GetDirectories();
            foreach (DirectoryInfo subDirectory in subDirectories)
            {
                directories.Add(new ListItem
                {
                    DisplayText = $"📁 {subDirectory.Name}",
                    ItemData = subDirectory
                });
            }
            return directories;
        }
    }
}
