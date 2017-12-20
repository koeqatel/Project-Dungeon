using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    /// <summary>
    /// Inventory items contains all items of the assigned player
    /// </summary>
    public List<WorldEntity> inventoryItems;

    public void Start()
    {
        inventoryItems = new List<WorldEntity>();

        //Let's load all the JSON files
        if (Directory.Exists(Environment.CurrentDirectory + "/WorldEntities/"))
        {
            //List all files that have extension name *.json
            List<string> files = new List<string>(Directory.GetFiles(Environment.CurrentDirectory + "/WorldEntities/", "*.json"));
            Debug.Log(string.Format("Found {0} World Entities, loading now...", files.Count));
            

        }
        else
        {
            Debug.Log("Couldn't load items, aborting!");
            Application.Quit();
        }
    }
}
