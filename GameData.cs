using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BlockEd
{
    [DataContract]
    class GameData
    {

        public GameData()
        {
            //_name = name;

            //if (maxScrollX != 0)
            //{
            //    _maxScrollX = maxScrollX;
            //}

            //if (maxScrollY != 0)
            //{
            //    _maxScrollY = maxScrollY;
            //}

            _numberOfTiles = 0;

            _level = new List<GameLevel>();
        }

        public void setName(string name)
        {
            _name = name;
        }

        public void incrementNumTiles(int incAmount = 1)
        {
            _numberOfTiles += incAmount;
        }

        public void decrementNumTiles(int decAmount = 1)
        {
            _numberOfTiles -= decAmount;
        }

        public int getNumTiles()
        {
            return _numberOfTiles;
        }

        public void setMaxScroll(int maxX, int maxY)
        {
            _maxScrollX = maxX;
            _maxScrollY = maxY;
        }
        public void setMaxScrollX(int maxX)
        {
            _maxScrollX = maxX;
        }
        public void setMaxScrollY(int maxY)
        {
            _maxScrollY = maxY;
        }


        public GameLevel getLastLoadedLevel()
        {
            return _level[_level.Count - 1];
        }

        public List<GameLevel> getLevelList()
        {
            return _level;
        }

        public void addLevel(int id, int startX, int startY, string levelName = null){
            _level.Add(new GameLevel(id, startX, startY, levelName));
        }

        public string getName()
        {
            return _name;
        }

        public int getMaxScrollX()
        {
            return _maxScrollX;
        }

        public int getMaxScrollY()
        {
            return _maxScrollY;
        }

        [DataMember]
        private string _name;
        [DataMember]
        private int _maxScrollX;
        [DataMember]
        private int _maxScrollY;
        [DataMember]
        private int _numberOfTiles;
        [DataMember]
        private List<GameLevel> _level;


    }
}
