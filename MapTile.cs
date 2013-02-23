using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockEd
{
    class MapTile
    {

        public MapTile(int spriteID, int xPos, int yPos)
        {
            _spriteID = spriteID;
            _xPos = xPos;
            _yPos = yPos;
        }

        public void newData(int spriteID, int xPos, int yPos)
        {
            _spriteID = spriteID;
            _xPos = xPos;
            _yPos = yPos;
        }

        public void setID(int ID)
        {
            _spriteID = ID;
        }

        public void setPosition(int X, int Y)
        {
            _xPos = X;
            _yPos = Y;
        }

        public int getID()
        {
            return _spriteID;
        }

        public int getX()
        {
            return _xPos;
        }

        public int getY()
        {
            return _yPos;
        }

        private int _spriteID;
        private int _xPos;
        private int _yPos;
    }
}
