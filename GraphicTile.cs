using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockEd
{
    class GraphicTile
    {
        public GraphicTile(Vector2 position, Vector2 texcoord)
        {
            _Position = position;
            _TexCoord = texcoord;
        }

        public GraphicTile(int id, int file, string name, int xPos, int yPos, int width, int height, string set, int type = 0, int data1 = 0, int data2 = 0, bool block = false)
        {
            _id = id;
            _file = file;
            _set = set;
            _name = name;
            _type = type;
            _data1 = data1;
            _data2 = data2;
            _block = block;
            _Position.X = xPos;
            _Position.Y = yPos;
            _TexCoord.X = width;
            _TexCoord.Y = height;
            _width = width;
            _height = height;

        }

        public Vector2 getPosition()
        {
            return _Position;
        }

        public Vector2 getTexCoord()
        {
            return _TexCoord;
        }

        public int getFileID()
        {
            return _file;
        }

        public string getSet()
        {
            return _set;
        }

        public int getWidth()
        {
            return _width;
        }

        public int getHeight()
        {
            return _height;
        }

        public int getTileID()
        {
            return _id;
        }

        //Can do: private bool _block{get; set;}
        private Vector2 _Position;
        private Vector2 _TexCoord;
        private string _name, _set;
        private int _id, _file, _type, _data1, _data2, _width, _height;
        private bool _block;
    }

    

}
