using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System;

namespace BlockEd
{

    public partial class EditorForm
    {
        Process gameTestApplication = null;
        bool isTestAppRunning = false;

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

            buildStripButton.Image = BlockEd.Properties.Resources.StatusAnnotations_Stop_32xLG_color;

            string[] fileNames = Directory.GetFiles("game/");
            foreach (string file in fileNames)
            {
                if (Path.GetExtension("game/" + file) != ".exe")
                {
                    File.Delete(file);
                    //Debug.WriteLine("Would have deleted: game/" + file);
                }
            }

            DirectoryCopy("data/", "game/", true);
            data.saveMapXml(loadedMap, "game", "TestMap");

            string gamePath = Path.GetDirectoryName(Application.ExecutablePath) + "\\game\\GGame.exe";
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WorkingDirectory = Path.GetDirectoryName(Application.ExecutablePath) + @"\game\";
            //startInfo.CreateNoWindow = false;
            startInfo.FileName = "GGame.exe";

            gameTestApplication = Process.Start(startInfo);
            isTestAppRunning = true;
            gameTestApplication.EnableRaisingEvents = true;
            gameTestApplication.Exited += (sender, e) => { buildStripButton.Image = BlockEd.Properties.Resources.StatusAnnotations_Play_32xLG_color; isTestAppRunning = false;  };
        }

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
