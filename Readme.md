# FileHub 🚀

FileHub is a modern file management utility built with Windows Forms in C#. It allows users to view, navigate, copy, move, and delete files and directories with an intuitive dual-pane interface.

## Features ✨

- **Dual-Pane Navigation:** Quickly browse drives and directories in two separate list views.
- **Recursive Copy & Move:** Use reliable algorithms to copy or move whole directories.
- **File Preview & Open:** Double-click files to open them with their default applications.
- **Emoji-enhanced UI:** Visual cues with custom emojis for different file types.

## Working Algorithm & Flow 🔄

1. **Initialization:**
   - At startup, the application loads all available drives using the method [`Files.LoadCurrentDrivers`](FD/Files.cs).
   - Both panes (list boxes) are populated with drive icons and names.

2. **Navigation:**
   - When an item is double-clicked in any list box, the `FillListBox` method in [`Form1.cs`](FD/Form1.cs) checks if it's a drive, directory, or file.
   - If it’s a drive or directory, its contents (folders and files) are listed. Files are tagged with emojis via [`Files.GetFileEmjoiFromPath`](FD/Files.cs).

3. **File Operations:**
   - **Copy:** Clicking the **Copy** button calls [`Files.Copy`](FD/Files.cs) which:
     - Checks if the source is a file or directory.
     - For directories, it uses the recursive helper method [`Files.CopyDirectory`](FD/Files.cs) to copy all contents.
   - **Move:** Clicking the move buttons calls [`Files.MoveFile`](FD/Files.cs) to reposition the selected item from one panel to another.
   - **Delete:** The **DESTROY** button initiates deletion via [`Files.DeleteFile`](FD/Files.cs). A confirmation prompt helps prevent accidental deletion.

4. **Back Navigation:**
   - A **BACK** button allows users to navigate up one directory level. It reloads the parent directory or switches back to the drive view if at the root.

## Directory Structure 📂

- **FD.sln & FD.csproj:** Project solution and configuration files.
- **FD/Files.cs:** Contains core file operations such as navigation, copying, moving, and deleting.
- **FD/Form1.cs & Form1.Designer.cs:** Implements the UI and event handlers.
- **FD/ListItem.cs:** A helper class for displaying file/directory items with associated data.
- **FD/Program.cs:** Application entry point.

## Getting Started 🚀

1. Open the project in [Visual Studio](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/).
2. Build the project using .NET 8.0 for Windows.
3. Run the application and start managing your files quickly with FileHub.

---

Enjoy the simplicity and speed of FileHub! If you have any issues or suggestions, feel free to [open an issue](https://github.com/yourrepo/filehub/issues).

Happy coding! 😎