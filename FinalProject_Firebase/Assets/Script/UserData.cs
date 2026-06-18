using System.Collections.Generic;
using Newtonsoft.Json;

[System.Serializable]
public class UserData
{
    public string NickName;
    public int Coin;
    public int Score;

    public string UnitList;
    public string Inventory;

    public UserData()
    {
    }

    public UserData(string nickName)
    {
        NickName = nickName;
        Coin = 500;
        Score = 0;

        Dictionary<string, bool> unitList = new Dictionary<string, bool>();

        unitList["Unit1"] = true;
        unitList["Unit2"] = false;
        unitList["Unit3"] = false;
        unitList["Unit4"] = false;
        unitList["Unit5"] = false;

        Dictionary<string, int> inventory = new Dictionary<string, int>();

        inventory["EnergyCore"] = 0;
        inventory["RepairKit"] = 0;
        inventory["GoldKey"] = 0;

        UnitList = JsonConvert.SerializeObject(unitList);
        Inventory = JsonConvert.SerializeObject(inventory);
    }
}