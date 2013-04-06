using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockEd
{

    //The abstract command class to inherit from
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

    //Places a tile on a given map
    internal class CPlaceTile : Command
    {
        MapTile _tile;
        MapTile _previousTile = null;
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
            foreach (MapDataTile tile in _map.getTileList())
            {
                if (tile._xPos == _tile.getX() && tile._yPos == _tile.getY())
                {
                    _previousTile = new MapTile(tile._spriteID, tile._xPos, tile._yPos);
                    break;
                }
            }
            _loadedMap.incrementNumTiles(_map.addTile(_tile));
            return true;
        }

        internal override bool Undo()
        {
            if (_previousTile != null)
            {
                _loadedMap.incrementNumTiles(_map.addTile(_previousTile));
            }
            else
            {
                _loadedMap.decrementNumTiles(_map.removeTile(_tile.getX(), _tile.getY()));
            }
            return true;
        }
    }

    //Remove a tile from a given map
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

    //Updates the selected tile's data
    internal class CApplyTileData : Command
    {
        MapTile _tile;
        List<GraphicTile> _graphicTiles;
        TileData _tileData;
        EditorForm _hostForm;

        GraphicTile _undoData = null;
        GraphicTile _redoData = null;

        internal CApplyTileData(MapTile selectedTile, ref List<GraphicTile> graphicTiles, ref TileData tileData, EditorForm hostForm)
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

    //Updates the selected layer's data
    internal class CApplyLayerData : Command
    {

        GameData _loadedMap;
        EditorForm _hostForm;

        MapData _beforeDo = null;
        MapData _afterDo = null;

        internal CApplyLayerData(GameData loadedMap, EditorForm hostForm)
        {
            _loadedMap = loadedMap;
            _hostForm = hostForm;

            _undoName = "Remove layer data change";
            _redoName = "Apply layer data change";
        }

        internal override bool Do()
        {
            if (_beforeDo != null)
            {
                foreach (GameLevel level in _loadedMap.getLevelList())
                {
                    foreach (MapData map in level.getLayerList())
                    {
                        if (map.getMapName() == _beforeDo.getMapName())
                        {
                            map.setWidth(_afterDo.getMapWidth());
                            map.setHeight(_afterDo.getMapHeight());
                            map.setLayerOffsetX(_afterDo.getLayerOffsetX());
                            map.setLayerOffsetY(_afterDo.getLayerOffsetY());
                            map.setMapName(_afterDo.getMapName());
                            map.setMaxTileWidth(_afterDo.getMapWidth());
                            map.setMaxTileHeight(_afterDo.getMapHeight());
                            map.setDrawType(_afterDo.getDrawType());
                            map.setZDepth(_afterDo.getZDepth());

                            _hostForm.updateLayerList();
                            _hostForm.layerSelectionBox.SelectedItem = map.getMapName();
                            _hostForm.updateLayerSelectionBox();

                            return true;
                        }
                    }
                }
            }

            foreach (GameLevel level in _loadedMap.getLevelList())
            {
                foreach (MapData map in level.getLayerList())
                {
                    if (map.getMapName() == _hostForm.layerSelectionBox.Text)
                    {
                        _beforeDo = new MapData(map.getMapWidth(), map.getMapHeight(), map.getDrawType(), map.getZDepth(), map.getMapName(), map.getMaxTileWidth(), map.getMaxTileHeight());

                        map.setWidth(Int32.Parse(_hostForm.layerWidthTextBox.Text));
                        map.setHeight(Int32.Parse(_hostForm.layerHeightTextBox.Text));
                        map.setLayerOffsetX(Int32.Parse(_hostForm.layerOffsetXTextBox.Text));
                        map.setLayerOffsetY(Int32.Parse(_hostForm.layerOffsetYTextBox.Text));
                        map.setMapName(_hostForm.layerNameTextBox.Text);
                        //map.setZDepth(Int32.Parse(layerZDepthTextBox.Text)); //!!!
                        map.setMaxTileWidth(Int32.Parse(_hostForm.maxTileWidthTextBox.Text));
                        map.setMaxTileHeight(Int32.Parse(_hostForm.maxTileHeightTextBox.Text));
                        map.setDrawType(_hostForm.layerDrawTypeComboBox.SelectedIndex + 1); //!

                        //Change Z Depth
                        int destinationLayer = Int32.Parse(_hostForm.layerZDepthTextBox.Text);
                        foreach (MapData mapCheck in level.getLayerList())
                        {
                            if (mapCheck.getZDepth() == destinationLayer && mapCheck.getMapName() != map.getMapName())
                            {
                                DialogResult shouldSwitch = MessageBox.Show("A layer clash has been found with the layer: " + map.getMapName().ToString() + ". Would you like to swap the layer positions?",
                                                                            "Layer Clash", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (shouldSwitch == DialogResult.Yes)
                                {
                                    mapCheck.setZDepth(map.getZDepth());
                                    map.setZDepth(destinationLayer);
                                    _hostForm.layerSelectionBox.Text = map.getMapName();
                                }
                                else
                                {
                                    MessageBox.Show("Okay, reverting to previous Z Depth.", "Reverting...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    _hostForm.layerZDepthTextBox.Text = map.getZDepth().ToString();
                                }
                                break;
                            }
                        }

                        _afterDo = new MapData(map.getMapWidth(), map.getMapHeight(), map.getDrawType(), map.getZDepth(), map.getMapName(), map.getMaxTileWidth(), map.getMaxTileHeight());

                        _hostForm.updateLayerList();
                        _hostForm.layerSelectionBox.SelectedItem = map.getMapName();
                        _hostForm.updateLayerSelectionBox();

                        return true;

                    }
                }
            }
            return false;
        }

        internal override bool Undo()
        {
            foreach (GameLevel level in _loadedMap.getLevelList())
            {
                foreach (MapData map in level.getLayerList())
                {
                    if (map.getMapName() == _afterDo.getMapName())
                    {
                        map.setWidth(_beforeDo.getMapWidth());
                        map.setHeight(_beforeDo.getMapHeight());
                        map.setLayerOffsetX(_beforeDo.getLayerOffsetX());
                        map.setLayerOffsetY(_beforeDo.getLayerOffsetY());
                        map.setMapName(_beforeDo.getMapName());
                        map.setMaxTileWidth(_beforeDo.getMapWidth());
                        map.setMaxTileHeight(_beforeDo.getMapHeight());
                        map.setDrawType(_beforeDo.getDrawType());
                        map.setZDepth(_beforeDo.getZDepth());

                        _hostForm.updateLayerList();
                        _hostForm.layerSelectionBox.SelectedItem = map.getMapName();
                        _hostForm.updateLayerSelectionBox();

                        return true;
                    }
                }
            }
            return false;
        }
    }

    //Adds a layer to the game
    internal class CAddLayer : Command
    {

        GameData _loadedMap;
        EditorForm _hostForm;

        MapData _backupMap = null;
        string _targetedLevel = "";

        internal CAddLayer(GameData loadedMap, EditorForm hostForm)
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

                if (level.getName() == _hostForm.levelSelectionBox.Text || level.getName() == _targetedLevel)
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
                    _targetedLevel = level.getName();

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

                if (level.getName() == _hostForm.levelSelectionBox.Text)
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

    //Removes the selected layer
    internal class CRemoveLayer : Command
    {

        GameData _loadedMap;
        EditorForm _hostForm;

        MapData _backupMap = null;
        List<MapDataTile> _backupTiles;

        internal CRemoveLayer(GameData loadedMap, EditorForm hostForm)
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
                if (level.getName() == _hostForm.levelSelectionBox.Text)
                {

                    MapData mapToRemove = null;

                    foreach (MapData map in level.getLayerList())
                    {
                        if (map.getMapName() == _hostForm.layerSelectionBox.Text)
                        {
                            mapToRemove = map;
                            _backupTiles = map.getTileList();
                            _backupMap = new MapData(map.getMapWidth(), map.getMapHeight(), map.getDrawType(), map.getZDepth(), map.getMapName(), map.getMaxTileWidth(), map.getMaxTileHeight());
                            break;
                        }
                    }

                    level.removeLayer(mapToRemove);

                    //Update layer GUI items
                    _hostForm.updateLayerList();
                    _hostForm.layerSelectionBox.SelectedIndex = 0;

                    _loadedMap.recalculateNumTiles();
                    _hostForm.updateTileCount();

                    return true;
                }
            }
            return false;
        }

        internal override bool Undo()
        {
            foreach (GameLevel level in _loadedMap.getLevelList())
            {
                if (level.getName() == _hostForm.levelSelectionBox.Text)
                {
                    level.addLayer(_backupMap.getMapWidth(), _backupMap.getMapHeight(), _backupMap.getDrawType(), _backupMap.getZDepth(), _backupMap.getMapName(), _backupMap.getMaxTileWidth(), _backupMap.getMaxTileHeight());

                    foreach (MapData layer in level.getLayerList())
                    {
                        if (layer.getMapName() == _backupMap.getMapName())
                        {
                            foreach (MapDataTile tile in _backupTiles)
                            {
                                layer.addTile(new MapTile(tile._spriteID, tile._xPos, tile._yPos));
                            }
                        }
                    }

                    //Update layer GUI items
                    _hostForm.updateLayerList();
                    _hostForm.layerSelectionBox.SelectedItem = _backupMap.getMapName();

                    _loadedMap.recalculateNumTiles();
                    _hostForm.updateTileCount();
                    return true;
                }
            }
            return false;
        }
    }

    //Moves the selected layer up/down dpending on moveUp
    internal class CMoveLayerZ : Command
    {

        GameData _loadedMap;
        EditorForm _hostForm;
        bool _moveUp;

        internal CMoveLayerZ(GameData loadedMap, EditorForm hostForm, bool moveUp)
        {
            _loadedMap = loadedMap;
            _hostForm = hostForm;
            _moveUp = moveUp;

            if (moveUp)
            {
                _undoName = "Move layer down";
                _redoName = "Move layer up";
            }
            else
            {
                _undoName = "Move layer up";
                _redoName = "Move layer down";
            }
        }

        internal override bool Do()
        {
            int moveDirection = (_moveUp ? 1 : -1);

            foreach (GameLevel level in _loadedMap.getLevelList())
            {
                foreach (MapData map in level.getLayerList())
                {
                    if (map.getMapName() == _hostForm.layerSelectionBox.Text)
                    {
                        int destinationLayer = map.getZDepth() + moveDirection;

                        if (destinationLayer < 0 || destinationLayer > _hostForm.getMaxZDepth())
                        {
                            return false;
                        }

                        foreach (MapData mapCheck in level.getLayerList())
                        {
                            if (mapCheck.getZDepth() == destinationLayer)
                            {
                                mapCheck.setZDepth(map.getZDepth());
                                break;
                            }
                        }

                        map.setZDepth(destinationLayer);
                        _hostForm.updateLayerSelectionBox();
                        _hostForm.updateLayerList();
                        _hostForm.layerSelectionBox.Text = map.getMapName();
                        return true;
                    }
                }
            }
            return false;
        }

        internal override bool Undo()
        {
            int moveDirection = (!_moveUp ? 1 : -1);

            foreach (GameLevel level in _loadedMap.getLevelList())
            {
                foreach (MapData map in level.getLayerList())
                {
                    if (map.getMapName() == _hostForm.layerSelectionBox.Text)
                    {
                        int destinationLayer = map.getZDepth() + moveDirection;

                        if (destinationLayer < 0 || destinationLayer > _hostForm.getMaxZDepth())
                        {
                            return false;
                        }

                        foreach (MapData mapCheck in level.getLayerList())
                        {
                            if (mapCheck.getZDepth() == destinationLayer)
                            {
                                mapCheck.setZDepth(map.getZDepth());
                                break;
                            }
                        }

                        map.setZDepth(destinationLayer);
                        _hostForm.updateLayerSelectionBox();
                        _hostForm.updateLayerList();
                        _hostForm.layerSelectionBox.Text = map.getMapName();
                        return true;
                    }
                }
            }
            return false;
        }
        
    }

    //Adds a level to the game
    internal class CAddLevel : Command
    {
        GameData _loadedMap;
        EditorForm _hostForm;
        GameLevel _backupLevel = null;
        List<MapData> _backupLayers = null;

        internal CAddLevel(GameData loadedMap, EditorForm hostForm)
        {
            _loadedMap = loadedMap;
            _hostForm = hostForm;
            _undoName = "Remove level";
            _redoName = "Add level";
        }

        internal override bool Do()
        {

            if (_backupLevel != null)
            {
                _loadedMap.addLevel(_backupLevel.getID(), _backupLevel.getStartX(), _backupLevel.getStartY(), _backupLevel.getName());
                _loadedMap.getLastLoadedLevel().setExit(_backupLevel.getExitX(), _backupLevel.getExitY());

                foreach (MapData layer in _backupLayers)
                {
                    _loadedMap.getLastLoadedLevel().addLayer(layer.getMapWidth(), layer.getMapHeight(), layer.getDrawType(), layer.getZDepth(),
                                                             layer.getMapName(), layer.getMaxTileWidth(), layer.getMaxTileHeight());
                    foreach (MapDataTile tile in layer.getTileList())
                    {
                        MapTile mapTile = new MapTile(tile._spriteID, tile._xPos, tile._yPos);
                        _loadedMap.getLastLoadedLevel().getLastAddedLayer().addTile(mapTile);
                    }
                }

                _hostForm.updateLevelList();
                _hostForm.levelSelectionBox.Text = _backupLevel.getName();
                return true;
            }

            int targetID = _loadedMap.getLevelList().Count + 1;
            bool uniqueIDNotFound = true;
            while (uniqueIDNotFound)
            {
                int checkedLevels = 0;
                foreach (GameLevel level in _loadedMap.getLevelList())
                {
                    if (level.getID() == targetID)
                    {
                        targetID++;
                        break;
                    }
                    checkedLevels++;
                }
                if (checkedLevels == _loadedMap.getLevelList().Count)
                {
                    uniqueIDNotFound = false;
                }
            }

            _loadedMap.addLevel(targetID, 0, 0);
            _backupLevel = _loadedMap.getLastLoadedLevel();
            _backupLayers = _backupLevel.getLayerList();
            _hostForm.updateLevelList();
            _hostForm.levelSelectionBox.Text = _backupLevel.getName();
            return true;
        }

        internal override bool Undo()
        {
            _loadedMap.removeLevel(_backupLevel.getID());
            _hostForm.updateLevelList();
            return true;
        }

    }

    //Removes the selected level from the game
    internal class CRemoveLevel : Command
    {
        GameData _loadedMap;
        EditorForm _hostForm;
        GameLevel _backupLevel = null;
        List<MapData> _backupLayers = null;

        internal CRemoveLevel(GameData loadedMap, EditorForm hostForm)
        {
            _loadedMap = loadedMap;
            _hostForm = hostForm;
            _undoName = "Add level";
            _redoName = "Remove level";
        }

        internal override bool Do()
        {

            if (_backupLevel == null)
            {
                foreach (GameLevel level in _loadedMap.getLevelList())
                {
                    if (level.getName() == _hostForm.levelSelectionBox.Text)
                    {
                        _backupLevel = level;
                        _backupLayers = level.getLayerList();
                        break;
                    }
                }
            }


            _loadedMap.removeLevel(_backupLevel.getID());

            _hostForm.updateLevelList();
            _loadedMap.recalculateNumTiles();
            _hostForm.updateTileCount();
            return true;
        }

        internal override bool Undo()
        {
            _loadedMap.addLevel(_backupLevel.getID(), _backupLevel.getStartX(), _backupLevel.getStartY(), _backupLevel.getName());
            _loadedMap.getLastLoadedLevel().setExit(_backupLevel.getExitX(), _backupLevel.getExitY());

            foreach(MapData layer in _backupLayers){
                _loadedMap.getLastLoadedLevel().addLayer(layer.getMapWidth(), layer.getMapHeight(), layer.getDrawType(), layer.getZDepth(),
                                                         layer.getMapName(), layer.getMaxTileWidth(), layer.getMaxTileHeight());
                foreach (MapDataTile tile in layer.getTileList())
                {
                    MapTile mapTile = new MapTile(tile._spriteID, tile._xPos, tile._yPos);
                    _loadedMap.getLastLoadedLevel().getLastAddedLayer().addTile(mapTile);
                }
            }

            _hostForm.updateLevelList();
            _hostForm.levelSelectionBox.Text = _backupLevel.getName();
            _loadedMap.recalculateNumTiles();
            _hostForm.updateTileCount();
            return true;
        }

    }

    //Updates the level's data
    internal class CApplyLevelData : Command
    {

        GameData _loadedMap;
        EditorForm _hostForm;

        GameLevel _undoData = null;
        GameLevel _redoData = null;

        bool _wasIdSwapDone = false;
        int _doID = -1;
        int _undoID = -1;

        internal CApplyLevelData(GameData loadedMap, EditorForm hostForm)
        {
            _loadedMap = loadedMap;
            _hostForm = hostForm;
            _undoName = "Remove level data change";
            _redoName = "Apply level data change";
        }

        internal override bool Do()
        {
            if (_redoData != null)
            {
                foreach (GameLevel level in _loadedMap.getLevelList())
                {
                    if (level.getName() == _undoData.getName())
                    {
                        level.setName(_redoData.getName());
                        level.setID(_redoData.getID());
                        level.setStartX(_redoData.getStartX());
                        level.setStartY(_redoData.getStartY());
                        level.setExit(_redoData.getExitX(), _redoData.getExitY());
                        _hostForm.updateLevelList();
                        _hostForm.levelSelectionBox.Text = level.getName();
                        _hostForm.updateLevelSelectionBox();
                        return true;
                    }
                }
            }


            foreach (GameLevel level in _loadedMap.getLevelList())
            {
                if (level.getName() == _hostForm.levelSelectionBox.Text)
                {
                    //Dont do the below check if the doID was already set
                    if (_doID != -1)
                    {
                        //Just do a check to make sure the new level id isn't clashing with some other level
                        int idToCheck = Int32.Parse(_hostForm.levelIDTextBox.Text);
                        foreach (GameLevel levelChecking in _loadedMap.getLevelList())
                        {
                            if (levelChecking.getID() == idToCheck)
                            {
                                DialogResult result = MessageBox.Show("Woah! The ID you chose is already in use. Would you like to swap IDs from " + idToCheck + " to " + levelChecking.getID() + @"?\n\n" +
                                                                      "If you do press Yes (swap ids), if you press No, a new ID will be found for you.", "Clash Found", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);

                                if (result == DialogResult.Yes)
                                {
                                    idToCheck = levelChecking.getID();
                                    _wasIdSwapDone = true;
                                    _doID = Int32.Parse(_hostForm.levelIDTextBox.Text);
                                    _undoID = idToCheck;
                                }
                                else
                                {
                                    int targetID = _loadedMap.getLevelList().Count + 1;
                                    bool uniqueIDNotFound = true;
                                    while (uniqueIDNotFound)
                                    {
                                        int checkedLevels = 0;
                                        foreach (GameLevel levelIDChecking in _loadedMap.getLevelList())
                                        {
                                            if (levelIDChecking.getID() == targetID)
                                            {
                                                targetID++;
                                                break;
                                            }
                                            checkedLevels++;
                                        }
                                        if (checkedLevels == _loadedMap.getLevelList().Count)
                                        {
                                            uniqueIDNotFound = false;
                                        }
                                    }
                                    _doID = targetID;
                                }

                            }
                        }
                    }

                    if (_wasIdSwapDone)
                    {
                        foreach (GameLevel levelIDSwap in _loadedMap.getLevelList())
                        {
                            if (levelIDSwap.getID() == _undoID)
                            {
                                _undoData = new GameLevel(level.getID(), level.getStartX(), level.getStartY(), level.getName());
                                _undoData.setExit(level.getExitX(), level.getExitY());

                                level.setName(_hostForm.levelNameTextBox.Text);
                                level.setID(_undoID);
                                levelIDSwap.setID(_doID);
                                level.setStartX(Int32.Parse(_hostForm.levelStartXTextBox.Text));
                                level.setStartY(Int32.Parse(_hostForm.levelStartYTextBox.Text));
                                level.setExit(Int32.Parse(_hostForm.levelExitXTextBox.Text), Int32.Parse(_hostForm.levelExitYTextBox.Text));

                                _redoData = new GameLevel(level.getID(), level.getStartX(), level.getStartY(), level.getName());
                                _redoData.setExit(level.getExitX(), level.getExitY());
                                _hostForm.updateLevelList();
                                _hostForm.levelSelectionBox.Text = level.getName();
                                _hostForm.updateLevelSelectionBox();
                                return true;
                            }
                        }
                    }
                    else
                    {
                        _undoData = new GameLevel(level.getID(), level.getStartX(), level.getStartY(), level.getName());
                        _undoData.setExit(level.getExitX(), level.getExitY());

                        level.setName(_hostForm.levelNameTextBox.Text);
                        level.setID(_doID);
                        level.setStartX(Int32.Parse(_hostForm.levelStartXTextBox.Text));
                        level.setStartY(Int32.Parse(_hostForm.levelStartYTextBox.Text));
                        level.setExit(Int32.Parse(_hostForm.levelExitXTextBox.Text), Int32.Parse(_hostForm.levelExitYTextBox.Text));

                        _redoData = new GameLevel(level.getID(), level.getStartX(), level.getStartY(), level.getName());
                        _redoData.setExit(level.getExitX(), level.getExitY());
                        _hostForm.updateLevelList();
                        _hostForm.levelSelectionBox.Text = level.getName();
                        _hostForm.updateLevelSelectionBox();
                    }


                    return true;
                }
            }
            return false;
        }

        internal override bool Undo()
        {

            if (_wasIdSwapDone)
            {
                foreach (GameLevel level in _loadedMap.getLevelList())
                {
                    if (level.getID() == _doID)
                    {
                        level.setID(_undoID);
                        return true;
                    }
                }
            }

            foreach (GameLevel level in _loadedMap.getLevelList())
            {
                if (level.getName() == _redoData.getName())
                {
                    level.setName(_undoData.getName());
                    level.setID(_undoData.getID());
                    level.setStartX(_undoData.getStartX());
                    level.setStartY(_undoData.getStartY());
                    level.setExit(_undoData.getExitX(), _undoData.getExitY());
                    _hostForm.updateLevelList();
                    _hostForm.levelSelectionBox.Text = level.getName();
                    _hostForm.updateLevelSelectionBox();
                    return true;
                }
            }
            return false;
        }
    }

    //Updates the game's data
    internal class CApplyGameData : Command
    {
        GameData _loadedMap;
        EditorForm _hostForm;

        string _redoGameName = null;
        string _undoGameName = null;

        internal CApplyGameData(GameData loadedMap, EditorForm hostForm)
        {
            _loadedMap = loadedMap;
            _hostForm = hostForm;
            _undoName = "Revert game name change";
            _redoName = "Apply game name change";
        }

        internal override bool Do()
        {
            if (_redoGameName != null)
            {
                _loadedMap.setName(_redoGameName);
                _hostForm.gameNameTextBox.Text = _redoGameName;
                return true;
            }
            _undoGameName = _loadedMap.getName();
            _loadedMap.setName(_hostForm.gameNameTextBox.Text);
            _redoGameName = _hostForm.gameNameTextBox.Text;
            return true;
        }

        internal override bool Undo()
        {
            _loadedMap.setName(_undoGameName);
            _hostForm.gameNameTextBox.Text = _undoGameName;
            return true;
        }
    }

}
