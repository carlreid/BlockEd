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

        private int _spriteID;
        private int _xPos;
        private int _yPos;
    }
}
