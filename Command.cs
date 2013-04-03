using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

    internal class CAddLayer : Command
    {

        GameData _loadedMap;
        Form1 _hostForm;

        MapData _backupMap = null;

        internal CAddLayer(GameData loadedMap, Form1 hostForm)
        {
            _loadedMap = loadedMap;
            _hostForm = hostForm;

            _undoName = "Remove Layer";
            _redoName = "Add Layer";
        }

        internal override bool Do()
        {
            foreach (GameLevel level in _loadedMap.getLevelList())
            {

                if (level.getName() == "typed in") //TODO: Apply selected level here
                {

                    if (_backupMap != null)
                    {
                        level.addLayer(_backupMap.getMapWidth(), _backupMap.getMapHeight(), _backupMap.getDrawType(), _backupMap.getZDepth(),
                                       _backupMap.getMapName(), _backupMap.getMaxTileWidth(), _backupMap.getMaxTileHeight());

                        //Update layer GUI items
                        _hostForm.updateLayerList();
                        _hostForm.layerSelectionBox.SelectedItem = _backupMap.getMapName();

                        return true;
                    }


                    int designatedZIndex = 0;

                    //Since no layer is selected, we'll try add a new layer at the highest z index
                    if (_hostForm.layerSelectionBox.Text == "Show All")
                    {
                        int highestZIndex = 0;
                        foreach (MapData map in level.getLayerList())
                        {
                            if (highestZIndex < map.getZDepth())
                            {
                                highestZIndex = map.getZDepth();
                            }
                        }
                        designatedZIndex = highestZIndex + 1;

                        //Looks like we can't make a new layer on top as it's higher than max. Try find a free spot
                        if (highestZIndex >= _hostForm.getMaxZDepth())
                        {
                            for (int zDepth = 9; zDepth > 0; --zDepth)
                            {
                                bool emptyLayer = true;

                                foreach (MapData map in level.getLayerList())
                                {
                                    if (zDepth == map.getZDepth())
                                    {
                                        emptyLayer = false;
                                        break;
                                    }
                                }
                                if (emptyLayer)
                                {
                                    designatedZIndex = zDepth;
                                    break;
                                }
                            }
                        }
                    }
                    else //Try find a free layer above the selected layer.
                    {

                        //Find Z index to be higher than
                        int selectedZIndex = 0;
                        foreach (MapData map in level.getLayerList())
                        {
                            if (map.getMapName() == _hostForm.layerSelectionBox.Text)
                            {
                                selectedZIndex = map.getZDepth();
                                break;
                            }
                        }

                        //If the selected Z index is already the highest, find a free spot.
                        if (selectedZIndex == _hostForm.getMaxZDepth())
                        {
                            for (int zDepth = 9; zDepth > 0; --zDepth)
                            {
                                bool emptyLayer = true;
                                foreach (MapData map in level.getLayerList())
                                {
                                    if (zDepth == map.getZDepth())
                                    {
                                        emptyLayer = false;
                                        break;
                                    }
                                }
                                if (emptyLayer)
                                {
                                    designatedZIndex = zDepth;
                                    break;
                                }
                            }
                        }

                        //Okay, looks like a decent selected layer, now see if a free spot is above it.
                        for (int findZ = selectedZIndex + 1; findZ <= _hostForm.getMaxZDepth(); ++findZ)
                        {
                            bool freeLayerFound = true;
                            foreach (MapData map in level.getLayerList())
                            {
                                if (findZ == map.getZDepth())
                                {
                                    freeLayerFound = false;
                                    break;
                                }
                            }
                            if (freeLayerFound)
                            {
                                designatedZIndex = findZ;
                                break;
                            }
                        }

                        //Can't have found a Z index going up, try goign down.
                        if (designatedZIndex == 0)
                        {
                            for (int findZ = selectedZIndex - 1; findZ > 0; --findZ)
                            {
                                bool freeLayerFound = true;
                                foreach (MapData map in level.getLayerList())
                                {
                                    if (findZ == map.getZDepth())
                                    {
                                        freeLayerFound = false;
                                        break;
                                    }
                                }
                                if (freeLayerFound)
                                {
                                    designatedZIndex = findZ;
                                    break;
                                }
                            }
                        }

                    }

                    if (designatedZIndex <= 0)
                    {
                        MessageBox.Show("Unable to add a layer, maybe there isn't any space?", "Unable to add layer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }

                    //Find a name for the new layer
                    bool nameNotFound = true;
                    string mapName = "New Layer";
                    int layerNameCount = 1;
                    while (nameNotFound)
                    {
                        string nameBackup = mapName;
                        foreach (MapData map in level.getLayerList())
                        {
                            if (map.getMapName() == mapName)
                            {
                                mapName = "New Layer " + layerNameCount.ToString();
                                ++layerNameCount;
                                break;
                            }
                        }
                        if (nameBackup == mapName)
                        {
                            nameNotFound = false;
                        }
                    }

                    //Add the layer
                    level.addLayer(32, 32, 3, designatedZIndex, mapName);

                    //Make a duplicate for undo/redo
                    _backupMap = new MapData(32, 32, 3, designatedZIndex, mapName);

                    //Update layer GUI items
                    _hostForm.updateLayerList();
                    _hostForm.layerSelectionBox.SelectedItem = mapName;
                    return true;
                }
            }
            return false;
        }

        internal override bool Undo()
        {
            foreach (GameLevel level in _loadedMap.getLevelList())
            {

                if (level.getName() == "typed in") //TODO: Apply selected level here
                {
                    level.removeLayer(_backupMap);
                }

            }
            //Update layer GUI items
            _hostForm.updateLayerList();
            _hostForm.layerSelectionBox.SelectedIndex = 0;
            return true;
        }
    }


}
