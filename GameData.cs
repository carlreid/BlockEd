using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockEd
{
    class GameData
    {

        public GameData(string name = "Default", int maxScrollX = 0, int maxScrollY = 0)
        {
            _name = name;

            if (maxScrollX != 0)
            {
                _maxScrollX = maxScrollX;
            }

            if (maxScrollY != 0)
            {
                _maxScrollY = maxScrollY;
            }

            _level = new List<GameLevel>();

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

        public void addLevel(int startX, int startY, string levelName = null){
            _level.Add(new GameLevel(_level.Count, startX, startY, levelName));
        }

        private string _name;
        private int _maxScrollX;
        private int _maxScrollY;
        private List<GameLevel> _level;


    }
}
