using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BlockEd
{
    [DataContract]
    public class MapDataTile
    {

        public MapDataTile(int id, int x, int y)
        {
            _spriteID = id;
            _xPos = x;
            _yPos = y;
        }

        [DataMember]
        public int _spriteID;
        [DataMember]
        public int _xPos;
        [DataMember]
        public int _yPos;
    }
}
