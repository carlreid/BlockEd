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
            _undoName = "Remove tile [" + tile.getX() + ", " + tile.getY() + "]";
            _redoName = "Place tile [" + tile.getX() + ", " + tile.getY() + "]";
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
            _undoName = "Place tile [" + tile.getX() + ", " + tile.getY() + "]";
            _redoName = "Remove tile [" + tile.getX() + ", " + tile.getY() + "]";
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

    internal class CApplyTileData : Command
    {
        MapTile _tile;
        List<GraphicTile> _graphicTiles;
        TileData _tileData;
        Form1 _hostForm;

        GraphicTile _undoData = null;
        GraphicTile _redoData = null;

        internal CApplyTileData(MapTile selectedTile, ref List<GraphicTile> graphicTiles, ref TileData tileData, Form1 hostForm)
        {
            _tile = selectedTile;
            _graphicTiles = graphicTiles;
            _tileData = tileData;
            _hostForm = hostForm;
            _undoName = "Remove tile data change";
            _redoName = "Apply tile data change";
        }

        internal override bool Do()
        {
            if (_redoData != null)
            {
                foreach (GraphicTile gfxTile in _graphicTiles)
                {
                    if (gfxTile.getTileID() == _tile.getID())
                    {
                        gfxTile.setTypeID(_redoData.getTypeID());
                        gfxTile.setDataOne(_redoData.getDataOne());
                        gfxTile.setDataTwo(_redoData.getDataTwo());
                        _hostForm.updateTileUI(_tile.getID());
                        return true;
                    }
                }
                return false;
            }

            foreach (GraphicTile gfxTile in _graphicTiles)
            {
                if (gfxTile.getTileID() == _tile.getID())
                {
                    _undoData = new GraphicTile(gfxTile);

                    if (_hostForm.tileData1Combo.Enabled)
                    {
                        foreach (TileType tileData in _tileData.getList())
                        {
                            if (tileData._name == _hostForm.tileTypeCombo.Text)
                            {
                                gfxTile.setTypeID(tileData._id);
                                foreach (TileDataOne tileDataOne in tileData.getList())
                                {
                                    if (tileDataOne._name == _hostForm.tileData1Combo.Text)
                                    {
                                        gfxTile.setDataOne(tileDataOne._id);
                                        gfxTile.setDataTwo(Int32.Parse(_hostForm.tileData2ValueTextBox.Text));
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (TileType tileData in _tileData.getList())
                        {
                            if (tileData._name == _hostForm.tileTypeCombo.Text)
                            {
                                gfxTile.setTypeID(tileData._id);

                                if (String.IsNullOrEmpty(tileData.getList()[0].getSecondData()._name))
                                {
                                    gfxTile.setDataOne(Int32.Parse(_hostForm.dataOneTextBox.Text));
                                }
                                else
                                {
                                    gfxTile.setDataOne(Int32.Parse(_hostForm.dataOneTextBox.Text));
                                    gfxTile.setDataTwo(Int32.Parse(_hostForm.dataTwoTextBox.Text));
                                }
                            }
                        }
                    }
                    _redoData = new GraphicTile(gfxTile);
                    return true;
                }
            }
            return false;
        }

        internal override bool Undo()
        {
            foreach (GraphicTile gfxTile in _graphicTiles)
            {
                if (gfxTile.getTileID() == _tile.getID())
                {
                    gfxTile.setTypeID(_undoData.getTypeID());
                    gfxTile.setDataOne(_undoData.getDataOne());
                    gfxTile.setDataTwo(_undoData.getDataTwo());
                    _hostForm.updateTileUI(_tile.getID());
                    return true;
                }
            }
            return false;
        }
    }

}
