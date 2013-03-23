using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System;

namespace BlockEd
{

    public partial class Form1
    {
        //http://www.codeproject.com/Articles/9123/Hosting-EXE-Applications-in-a-WinForm-project
        //[DllImport("user32.dll")]
        //static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        //[DllImport("user32.dll")]
        //static extern int SetWindowLong(IntPtr hWnd, int nIndex, UInt32 dwNewLong);
        //[DllImport("user32.dll", SetLastError = true)]
        //internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
        //[DllImport("user32.dll")]
        //static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        //Process p = null;
        //IntPtr appWin;
        //int GWL_STYLE = (-16);
        //UInt32 WS_VISIBLE = 0x10000000;
        //UInt32 WM_CLOSE = 0x0010;

        Process gameTestApplication;

        //Launches exe running TestMap.xml
        public void launchTest()
        {
            if (!Directory.Exists("game/"))
            {
                MessageBox.Show("Unable to find game, please make sure it exists in /game/", "Unable to execute", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (loadedMap == null)
            {
                MessageBox.Show("There is nothing to test, please load a map first.", "Load a map", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string[] fileNames = Directory.GetFiles("game/");
            foreach (string file in fileNames)
            {
                if (Path.GetExtension("game/" + file) != ".exe")
                {
                    //File.Delete(file);
                    //Debug.WriteLine("Would have deleted: game/" + file);
                }
            }

            //DirectoryCopy("data/", "game/", true);
            //data.saveMapXml(loadedMap, "game", "TestMap");

            //From: http://stackoverflow.com/questions/7762379/run-a-foreign-exe-inside-a-windows-form-app
            string gamePath = Path.GetDirectoryName(Application.ExecutablePath) + "\\game\\GGame.exe";
            gameTestApplication = Process.Start(gamePath);
            //SetParent(gameTestApplication.MainWindowHandle, this.Handle);

            //try
            //{
            //    // Start the process 
            //    p = System.Diagnostics.Process.Start(gamePath);

            //    // Wait for process to be created and enter idle condition 
            //    p.WaitForInputIdle();

            //    // Get the main handle
            //    appWin = p.MainWindowHandle;

            //    // Put it into this form
            //    SetParent(appWin, this.Handle);

            //    // Remove border and whatnot
            //    //SetWindowLong(appWin, GWL_STYLE, WS_VISIBLE);

            //    // Move the window to overlay it on this window
            //    MoveWindow(appWin, 0, 0, this.Width, this.Height, true);

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(this, ex.Message, "Error");
            //}

        }

        //protected override void OnResize(EventArgs e)
        //{
        //    if (this.appWin != IntPtr.Zero)
        //    {
        //        MoveWindow(appWin, 0, 0, this.Width, this.Height, true);
        //    }
        //    base.OnResize(e);
        //}

        //protected override void OnHandleDestroyed(EventArgs e)
        //{
        //    // Stop the application
        //    if (appWin != IntPtr.Zero)
        //    {

        //        // Post a colse message
        //        PostMessage(appWin, WM_CLOSE, 0, 0);

        //        // Delay for it to get the message
        //        System.Threading.Thread.Sleep(1000);

        //        // Clear internal handle
        //        appWin = IntPtr.Zero;

        //    }

        //    base.OnHandleDestroyed(e);
        //}

        //From: http://msdn.microsoft.com/en-GB/library/bb762914.aspx
        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, true);
            }

            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
    }
}
