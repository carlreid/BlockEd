using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BlockEd
{
    [DataContract]
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

            _hasExit = false;

        }

        public void setExit(int exitX, int exitY){
            _hasExit = true;
            _exitPosX = exitX;
            _exitPosY = exitY;
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

        public void removeLayer(MapData map)
        {
            _mapLayers.Remove(map);
            _mapLayers.RemoveAll(delegate(MapData checkMap)
            {
                return checkMap.getMapName() == map.getMapName() && checkMap.getZDepth() == map.getZDepth();
            });
        }

        public MapData getLastAddedLayer()
        {
            return _mapLayers[_mapLayers.Count - 1];
        }

        public List<MapData> getLayerList()
        {
            return _mapLayers;
        }

        public int getID()
        {
            return _id;
        }

        public string getName()
        {
            return _name;
        }

        public int getStartX()
        {
            return _startPosX;
        }

        public int getStartY()
        {
            return _startPosY;
        }

        public bool hasExitBeenSet()
        {
            return _hasExit;
        }

        public int getExitX()
        {
            return _exitPosX;
        }

        public int getExitY()
        {
            return _exitPosY;
        }

        [DataMember]
        private int _id; //Rq
        [DataMember]
        private string _name;

        [DataMember]
        private int _startPosX; //Rq
        [DataMember]
        private int _startPosY; //Rq

        [DataMember]
        private bool _hasExit;
        [DataMember]
        private int _exitPosX;
        [DataMember]
        private int _exitPosY;

        [DataMember]
        List<MapData> _mapLayers;

    }
}
