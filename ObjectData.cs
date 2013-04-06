using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockEd
{
    partial class EditorForm 
    {

        TileData _tileData = new TileData();

        public void updateTileUI(int tileID)
        {

            int typeID = 0;
            int dataOne = 0;
            int dataTwo = 0;

            tileTypeCombo.Items.Clear();
            tileData1Combo.Items.Clear();

            foreach (GraphicTile gfxTile in graphicTiles)
            {
                if (gfxTile.getTileID() == tileID)
                {
                    typeID = gfxTile.getTypeID();
                    dataOne = gfxTile.getDataOne();
                    dataTwo = gfxTile.getDataTwo();
                    break;
                }
            }


            if (typeID == 0)
            {
                toggleTabPageEnable(tileDataPage, false);
                //tileDataGroupBox.Enabled = false;
                //dataTabControl.Enabled = false;

                tileTypeCombo.Text = "";
                tileData1Combo.Text = "";
                tileData2ValueLabel.Text = "Value:";
                tileData2ValueTextBox.Text = "";
                dataTwoLabel.Text = "Value:";
                dataTwoTextBox.Text = "";
                dataOneLabel.Text = "Value:";
                dataOneTextBox.Text = "";

                return;
            }

            //tileDataGroupBox.Enabled = true;
            //dataTabControl.Enabled = true;
            toggleTabPageEnable(tileDataPage, true);
            tileTypeCombo.Text = "";
            tileData1Combo.Text = "";

            tileTypeCombo.Enabled = true;
            tileData1Combo.Enabled = true;
            tileTypeLabel.Enabled = true;
            tileData2ValueLabel.Enabled = true;
            tileData2ValueTextBox.Enabled = true;

            dataOneLabel.Enabled = false;
            dataOneTextBox.Enabled = false;
            dataTwoLabel.Enabled = false;
            dataTwoTextBox.Enabled = false;
            
            foreach (TileType tileData in _tileData.getList())
            {
                tileTypeCombo.Items.Add(tileData._name);
                if (tileData._id == typeID)
                {
                    tileTypeCombo.SelectedItem = tileData._name;
                    foreach(TileDataOne tileDataOne in tileData.getList()){
                        if (tileDataOne._id == 0)
                        {
                            //tileTypeCombo.Enabled = false;
                            tileData1Combo.Enabled = false;
                            tileTypeLabel.Enabled = false;
                            tileData2ValueLabel.Enabled = false;
                            tileData2ValueTextBox.Enabled = false;

                            dataOneLabel.Enabled = true;
                            dataOneTextBox.Enabled = true;
                            dataTwoLabel.Enabled = true;
                            dataTwoTextBox.Enabled = true;

                            dataOneLabel.Text = tileDataOne._name + ":";
                            dataOneTextBox.Text = dataOne.ToString();

                            if (tileDataOne.getSecondData()._name == null)
                            {
                                dataTwoLabel.Enabled = false;
                                dataTwoTextBox.Enabled = false;
                            }
                            else
                            {
                                dataTwoLabel.Text = tileDataOne.getSecondData()._name + ":";
                                dataTwoTextBox.Text = dataTwo.ToString();
                            }
                        }
                        else
                        {
                            if (tileDataOne._name == null)
                            {
                                tileData1Combo.Enabled = false;
                            }
                            else
                            {
                                tileData1Combo.Items.Add(tileDataOne._name);
                            }
                            if (tileDataOne._id == dataOne)
                            {
                                tileData1Combo.SelectedItem = tileDataOne._name;
                                tileData2ValueLabel.Text = tileDataOne.getSecondData()._name + ":";
                                tileData2ValueTextBox.Text = dataTwo.ToString();
                            }
                        }
                    }
                }
            }

        }

        
    }

    class TileData
    {
        public TileData()
        {
            _tileTypeList = new List<TileType>();
        }

        public void addTileType(int id, string name)
        {
            _tileTypeList.Add(new TileType(id, name));
        }

        public TileType getLastList()
        {
            return _tileTypeList[_tileTypeList.Count - 1];
        }

        public List<TileType> getList()
        {
            return _tileTypeList;
        }

        List<TileType> _tileTypeList;
    }

    class TileType
    {
        public TileType(int id, string name)
        {
            _id = id;
            _name = name;
            _dataOneList = new List<TileDataOne>();
        }

        public void addDataOne(int id, string name)
        {
            _dataOneList.Add(new TileDataOne(id, name));
        }

        public TileDataOne getLastList()
        {
            return _dataOneList[_dataOneList.Count - 1];
        }

        public List<TileDataOne> getList()
        {
            return _dataOneList;
        }

        public int _id { get; set; }
        public string _name { get; set; }
        List<TileDataOne> _dataOneList;
    }

    class TileDataOne
    {
        //ID could be 0
        //Name could be null

        public TileDataOne(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public void setSecondData(string name, string melee, string shot)
        {
            _mySecondData = new TileDataTwo(name, melee, shot);
        }

        public TileDataTwo getSecondData()
        {
            return _mySecondData;
        }

        public int _id { get; set; }
        public string _name { get; set; }
        TileDataTwo _mySecondData;
    }

    class TileDataTwo
    {
        //Name could be null

        public TileDataTwo(string name, string melee, string shot)
        {
            _name = name;
            _melee = melee;
            _shot = shot;
        }

        public string _name { get; set; }
        public string _melee { get; set; }
        public string _shot { get; set; }
    }

}
