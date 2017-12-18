using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;

public class ItemDatabase : MonoBehaviour {

    public WeaponListClass weapon = new WeaponListClass();

    XmlSerializer serialization;
    FileStream fs;
    XmlReader reader;

    public void Start()
    {
        GetItems();
    }

    public void GetItems()
    {
        foreach (string File in Directory.GetFiles("Assets/Scripts/Items/ItemFiles/Weapons", "*.xml").Select(Path.GetFileName))
        {
            serialization = new XmlSerializer(typeof(WeaponListClass));

            fs = new FileStream("Assets/Scripts/Items/ItemFiles/Weapons/" + File, FileMode.Open);
            reader = XmlReader.Create(fs);

            weapon = (WeaponListClass)serialization.Deserialize(reader);
            fs.Close();
        }
    }
}
