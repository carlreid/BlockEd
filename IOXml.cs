using System.Windows.Forms;

namespace BlockEd
{
    partial class EditorForm
    {

        bool saveXML()
        {
            if (loadedMap == null)
            {
                MessageBox.Show("Please load a map first.", "No map open", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            //If a new map has been made which wasn't loaded using "Open"
            if (mapFilePath == null)
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "XML|*.xml";
                saveDialog.InitialDirectory = Application.ExecutablePath;
                saveDialog.CheckPathExists = true;
                saveDialog.DefaultExt = "xml";
                DialogResult saveResult = saveDialog.ShowDialog();

                if (saveResult == DialogResult.OK)
                {
                    string savePath = saveDialog.FileName;
                    string saveDirectory = System.IO.Path.GetDirectoryName(savePath);
                    string saveName = System.IO.Path.GetFileNameWithoutExtension(savePath);
                    data.saveMapXml(loadedMap, saveDirectory, saveName);
                    mapFilePath = savePath;
                }
                else if (saveResult == DialogResult.Cancel)
                {
                    return false;
                }

                this.Text = "BlockEd - " + System.IO.Path.GetFileNameWithoutExtension(mapFilePath);

            }
            else //We opened a map from a file, save to that location.
            {
                string saveDirectory = System.IO.Path.GetDirectoryName(mapFilePath);
                string saveName = System.IO.Path.GetFileNameWithoutExtension(mapFilePath);
                data.saveMapXml(loadedMap, saveDirectory, saveName);
            }

            changeMade = false;
            saveTimer.Enabled = false;

            //Delete the periodic save file.
            string backupFileSavePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\" + periodicFileName + ".xml";
            if (System.IO.File.Exists(backupFileSavePath))
            {
                System.IO.File.Delete(backupFileSavePath);
            }

            return true;

        }

        bool loadXML()
        {
            OpenFileDialog fileBrowser = new OpenFileDialog();
            fileBrowser.Multiselect = false;
            fileBrowser.InitialDirectory = Application.ExecutablePath;
            fileBrowser.Filter = "XML Files (*.xml)|*.xml";
            DialogResult browseResult = fileBrowser.ShowDialog();
            if (browseResult == DialogResult.OK)
            {
                data.loadTileData(ref _tileData);
                data.loadGraphics(graphicTiles, graphicFiles, ref mapLoaded);

                mapFilePath = fileBrowser.FileName;
                loadedMap = data.loadMap(loadedMap, mapFilePath);
                data.loadGraphics(graphicTiles, graphicFiles, ref mapLoaded);
                glFuncs.loadSpriteSheets(graphicFiles, alphaColorKey);
                updateGL(glMapMain);
                this.Text = "BlockEd - " + System.IO.Path.GetFileNameWithoutExtension(mapFilePath);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
