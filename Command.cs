using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockEd
{
    internal abstract class Command
    {
        abstract internal bool Do();
        abstract internal bool Undo();
        internal string getUndoName()
        {
            return _undoName;
        }

        internal string getRedoName()
        {
            return _redoName;
        }

        protected string _undoName { get; set; }
        protected string _redoName { get; set; }
    }


    internal class CPlaceTile : Command
    {
        MapTile _tile;
        MapData _map;

        internal CPlaceTile(MapTile tile, MapData addToMap)
        {
            _tile = new MapTile(tile.getID(), tile.getX(), tile.getY());
            _map = addToMap;
            _undoName = "Remove tile";
            _redoName = "Place tile";
        }

        internal override bool Do()
        {
            int tileInc = _map.addTile(_tile);
            if (tileInc == 0)
            {
                return false;
            } else {
                return true;
            }
        }

        internal override bool Undo()
        {
            _map.removeTile(_tile.getX(), _tile.getY());
            return true;
        }
    }

}
