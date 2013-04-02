using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BlockEd
{
    [DataContract]
    class MapData
    {
        public MapData(int width, int height, int drawType, int zDepth, string mapName = "Default", int maxTileWidth = 32, int maxTileHeight = 32)
        {
            _width = width;
            _height = height;
            _drawType = drawType;
            _zDepth = zDepth;

            _mapName = mapName;
            _maxTileWidth = maxTileWidth;
            _maxTileHeight = maxTileHeight;

            _layerOffsetX = 0;
            _layerOffsetY = 0;

            _tiles = new List<MapDataTile>();
        }

        public void setLayerOffset(int offsetX, int offsetY){
            _layerOffsetX = offsetX;
            _layerOffsetY = offsetY;
        }

        public void addTile(int tileID, int xPos, int yPos)
        {
            _tiles.Add(new MapDataTile(tileID, xPos, yPos));
        }

        public int addTile(MapTile tile)
        {
            foreach (MapDataTile checkTile in _tiles)
            {
                if (checkTile._xPos == tile.getX() && checkTile._yPos == tile.getY())
                {
                    if (checkTile._spriteID != tile.getID())
                    {
                        checkTile._spriteID = tile.getID();
                        return 0;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }

            _tiles.Add(new MapDataTile(tile.getID(), tile.getX(), tile.getY()));
            return 1;
        }

        public int removeTile(int tileX, int tileY)
       {
           bool didRemove = false;
            _tiles.RemoveAll(delegate(MapDataTile tile)
            {
                if (tile._xPos == tileX && tile._yPos == tileY)
                {
                    didRemove = true;
                    return true;
                }
                else
                {
                    return false;
                }
            });
            if (didRemove)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int getZDepth(){
            return _zDepth;
        }

        public void setZDepth(int zDepth)
        {
            _zDepth = zDepth;
        }

        public List<MapDataTile> getTileList()
        {
            return _tiles;
        }

        public int getMaxTileWidth()
        {
            return _maxTileWidth;
        }

        public int getMaxTileHeight()
        {
            return _maxTileHeight;
        }

        public string getMapName()
        {
            return _mapName;
        }

        public int getMapWidth()
        {
            return _width;
        }

        public int getMapHeight()
        {
            return _height;
        }

        public int getDrawType()
        {
            if (_drawType <= 0 || _drawType >= 4)
            {
                //Default value (blit/copy)
                //Set draw type to correct the issue.
                _drawType = 2;
                return 2;   
            }
            return _drawType;
        }

        public int getLayerOffsetX()
        {
            return _layerOffsetX;
        }

        public int getLayerOffsetY()
        {
            return _layerOffsetY;
        }

        public void setWidth(int width)
        {
            _width = width;
        }

        public void setHeight(int height)
        {
            _height = height;
        }

        public void setMaxTileWidth(int width)
        {
            _maxTileWidth = width;
        }

        public void setMaxTileHeight(int height)
        {
            _maxTileHeight = height;
        }

        public void setLayerOffsetX(int newX)
        {
            _layerOffsetX = newX;
        }

        public void setLayerOffsetY(int newY)
        {
            _layerOffsetY = newY;
        }

        public void setMapName(string name)
        {
            _mapName = name;
        }

        public void setDrawType(int type)
        {
            _drawType = type;
        }

        [DataMember]
        private string _mapName;
        [DataMember]
        private int _zDepth; //Rq
        [DataMember]
        private int _width; //Rq
        [DataMember]
        private int _height; //Rq
        [DataMember]
        private int _maxTileWidth;
        [DataMember]
        private int _maxTileHeight;
        [DataMember]
        private int _layerOffsetX;
        [DataMember]
        private int _layerOffsetY;
        [DataMember]
        private int _drawType; //Wtf
        [DataMember]
        private List<MapDataTile> _tiles;

    }

}
