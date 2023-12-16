using System;
using System.Collections.Generic;
using UnityEngine;
using XynokConvention.Data.Saver;

[Serializable]
public class Inventory : ADataSaver<Inventory>
{
    public string name = "Inventory";
    public List<string> xx;
    public override string SaveKey { get; }
}

[Serializable]
public class Shop : ADataSaver<Inventory>
{
    public string name = "Shop";
    public override string SaveKey { get; }
}

public class NewBehaviourScript : MonoBehaviour
{
}