using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockEd
{
    class GameLevel
    {
        public GameLevel(int id, int startX, int startY, string levelName = null)
        {
            _id = id;
            _startPosX = startX;
            _startPosY = startY;

            if (levelName != null)
            {
                _name = levelName;
            }
            else
            {
                _name = "Level " + _id.ToString();
            }

            _mapLayers = new List<MapData>();

        }

        public void addLayer(int width, int height, int drawType, int zDepth, string mapName = "Default", int maxTileWidth = 32, int maxTileHeight = 32)
        {
            _mapLayers.Add(new MapData(width, height, drawType, zDepth, mapName, maxTileWidth, maxTileHeight));
            _mapLayers.Sort(delegate(MapData a, MapData b)
                           {
                               return a.getZDepth().CompareTo(b.getZDepth());
                           }
            );
        }

        public MapData getLastAddedLayer()
        {
            return _mapLayers[_mapLayers.Count - 1];
        }

        public List<MapData> getLayerList()
        {
            return _mapLayers;
        }

        private int _id; //Rq
        private string _name;

        private int _startPosX; //Rq
        private int _startPosY; //Rq
        private int _exitPosX;
        private int _exitPosY;

        List<MapData> _mapLayers;

    }
}
