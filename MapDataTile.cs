using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockEd
{
    public class MapDataTile
    {

        public MapDataTile(int id, int x, int y)
        {
            _spriteID = id;
            _xPos = x;
            _yPos = y;
        }

        public int _spriteID;
        public int _xPos;
        public int _yPos;
    }
}
