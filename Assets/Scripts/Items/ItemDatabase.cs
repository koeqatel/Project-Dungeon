using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

public class ItemDatabase : MonoBehaviour {

    public TextAsset baseItems;
    public TextAsset baseWeapons;

    public BaseItemsList baseItem;
    public BaseWeaponList baseWeapon;

    XmlSerializer serialization;
    FileStream fs;
    XmlReader reader;

    public void Start()
    {
        GetBaseItems();
    }

    public void GetBaseItems()
    {
        serialization = new XmlSerializer(typeof(BaseItemsList));

        fs = new FileStream("Assets/Scripts/Items/ItemFiles/" + baseItems.name + ".xml", FileMode.Open);
        reader = XmlReader.Create(fs);

        baseItem = new BaseItemsList();
        baseItem = (BaseItemsList)serialization.Deserialize(reader);

        fs.Close();

        serialization = new XmlSerializer(typeof(BaseWeaponList));

        fs = new FileStream("Assets/Scripts/Items/ItemFiles/" + baseWeapons.name + ".xml", FileMode.Open);
        reader = XmlReader.Create(fs);

        baseWeapon = new BaseWeaponList();
        baseWeapon = (BaseWeaponList)serialization.Deserialize(reader);

        foreach (BaseWeaponClass weapon in baseWeapon.weapons)
        {
            foreach (BaseItemClass items in baseItem.items)
            {
                if (weapon.itemId == items.itemId)
                {
                    weapon.itemDescription = items.itemDescription;
                    weapon.itemName = items.itemName;
                    weapon.itemType = items.itemType;
                    break;
                }
            }
        }
        fs.Close();
    }
}
