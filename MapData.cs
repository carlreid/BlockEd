﻿using System;
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

        public void addTile(MapTile tile)
        {
            foreach (MapDataTile checkTile in _tiles)
            {
                if (checkTile._xPos == tile.getX() && checkTile._yPos == tile.getY())
                {
                    checkTile._spriteID = tile.getID();
                    return;
                }
            }

            _tiles.Add(new MapDataTile(tile.getID(), tile.getX(), tile.getY()));
        }

        public void removeTile(int tileX, int tileY)
       {
            _tiles.RemoveAll(delegate(MapDataTile tile)
            {
                return (tile._xPos == tileX && tile._yPos == tileY);
            });
        }

        public int getZDepth(){
            return _zDepth;
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
