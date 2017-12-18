using System;
using System.Collections.Generic;
using System.Xml.Serialization;

[Serializable]
public class WeaponClass
{
    [XmlElement("ItemId")]
    public int itemId { get; set; }

    [XmlElement("DataId")]
    public int dataId { get; set; }

    [XmlElement("ItemName")]
    public string itemName { get; set; }

    [XmlElement("ItemDescription")]
    public string itemDescription { get; set; }

    public enum itemTypes
    {
        Weapon,
        Potion,
        Money
    }
    [XmlElement("ItemType")]
    public itemTypes itemType { get; set; }

    public enum weaponTypes
    {
        Melee,
        Ranged,
        Magic
    }
    [XmlElement("WeaponType")]
    public weaponTypes weaponType { get; set; }

    public enum weaponDamageTypes
    {
        Water,
        Fire,
        Air,
        Electric,
        Earth,
        Normal,
        Explosion,
        Etc
    }
    [XmlElement("WeaponDamageType")]
    public weaponDamageTypes weaponDamageType { get; set; }

    [XmlElement("ChargeSpeed")]
    public int chargeSpeed { get; set; }

    [XmlElement("StaminaCost")]
    public int staminaCost { get; set; }

    [XmlElement("ManaCost")]
    public int manaCost { get; set; }

    [XmlElement("MeleeDamage")]
    public int meleeDamage { get; set; }

    [XmlElement("RangedDamage")]
    public int rangedDamage { get; set; }

    [XmlElement("MagicDamage")]
    public int magicDamage { get; set; }

    [XmlElement("ExplosionDamage")]
    public int explosionDamage { get; set; }

    [XmlElement("SocketCount")]
    public int socketCount { get; set; }

    [XmlElement("Sprite")]
    public string sprite { get; set; }
}

[Serializable]
[XmlRoot("WeaponCollection")]
public class WeaponListClass
{
    [XmlArray("Weapons")]
    [XmlArrayItem("NewWeapon", typeof(WeaponClass))]
    public List<WeaponClass> weapons { get; set; }
}