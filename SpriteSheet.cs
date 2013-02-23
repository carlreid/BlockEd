using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockEd
{
    class SpriteSheet
    {

        public SpriteSheet(int id, string imageToLoad)
        {
            _fileID = id;
            _imagePath = imageToLoad;
        }

        public void setGLTexId(int id){
            _textureID = id;
        }

        public string getImagePath()
        {
            return "data/" + _imagePath;
        }

        public string getImageFileName()
        {
            String[] fileNameExplode = _imagePath.Split('.');
            return fileNameExplode[0];
        }

        public int getFileId()
        {
            return _fileID;
        }

        public int getGLTexId()
        {
            return _textureID;
        }

        public void setWidth(int width)
        {
            _width = width;
        }

        public void setHeight(int height)
        {
            _height = height;
        }

        public int getWidth()
        {
            return _width;
        }

        public int getHeight()
        {
            return _height;
        }

        private int _fileID;
        private int _textureID;
        private int _width, _height;
        string _imagePath;
    }
}
