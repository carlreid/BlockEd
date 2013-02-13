using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockEd
{
    class MapData
    {

        public MapData(int width, int height, int drawType, string mapName = "Default", int maxTileWidth = 32, int maxTileHeight = 32)
        {
            _width = width;
            _height = height;
            _drawType = drawType;

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

        public int getZDepth(){
            return _zDepth;
        }

        public List<MapDataTile> getTileList()
        {
            return _tiles;
        }

        private string _mapName;
        private int _zDepth; //Rq
        private int _width; //Rq
        private int _height; //Rq
        private int _maxTileWidth;
        private int _maxTileHeight;
        private int _layerOffsetX;
        private int _layerOffsetY;
        private int _drawType; //Wtf
        private List<MapDataTile> _tiles;

    }

}
