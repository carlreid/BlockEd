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
        GameData _loadedMap;

        internal CPlaceTile(MapTile tile, MapData addToMap, GameData loadedMap)
        {
            _tile = new MapTile(tile.getID(), tile.getX(), tile.getY());
            _map = addToMap;
            _loadedMap = loadedMap;
            _undoName = "Remove tile";
            _redoName = "Place tile";
        }

        internal override bool Do()
        {
            _loadedMap.incrementNumTiles(_map.addTile(_tile));
            return false;
        }

        internal override bool Undo()
        {
            _loadedMap.decrementNumTiles(_map.removeTile(_tile.getX(), _tile.getY()));
            return true;
        }
    }

    internal class CRemoveTile : Command
    {
        MapTile _tile;
        MapData _map;
        GameData _loadedMap;

        internal CRemoveTile(MapTile tile, MapData removeFromMap, GameData loadedMap)
        {
            _tile = new MapTile(tile.getID(), tile.getX(), tile.getY());
            _map = removeFromMap;
            _loadedMap = loadedMap;
            _undoName = "Place tile";
            _redoName = "Remove tile";
        }

        internal override bool Do()
        {
            foreach (MapDataTile tile in _map.getTileList())
            {
                if (tile._xPos == _tile.getX() && tile._yPos == _tile.getY())
                {
                    _tile.setID(tile._spriteID);
                    break;
                }
            }
            _loadedMap.decrementNumTiles(_map.removeTile(_tile.getX(), _tile.getY()));
            return true;
        }

        internal override bool Undo()
        {
            _loadedMap.incrementNumTiles(_map.addTile(_tile));
            return true;
        }
    }

}
