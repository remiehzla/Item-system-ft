using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataManager
{
    // Used to describe the methods that the implementing script needs to have

    // Allow the implementing script to read the data
    void LoadData(GameData data);

    // Allow the implementing script to modify the data
    void SaveData(GameData data);
}
