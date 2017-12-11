using System;
using System.Collections.Generic;
using System.Xml.Serialization;

[Serializable]
public class BaseItemClass {

    [XmlElement("ItemId")]
    public string itemId;

    [XmlElement("ItemName")]
    public string itemName;

    [XmlElement("ItemDescription")]
    public string itemDescription;

    public enum itemTypes
    {
        Weapon,
        Potion,
        Money
    }
    [XmlElement("ItemType")]
    public itemTypes itemType;
}

[Serializable]
[XmlRoot("ItemCollection")]
public class BaseItemsList
{
    [XmlArray("Items")]
    [XmlArrayItem("NewBaseItem", typeof(BaseItemClass))]
    public List<BaseItemClass> items { get; set; }
}