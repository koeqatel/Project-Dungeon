using System;
using System.Collections.Generic;
using System.Xml.Serialization;

[Serializable]
public class BaseWeaponClass : BaseItemClass
{
    [XmlElement("Damage")]
    public int damage { get; set; }

    [XmlElement("ChargeSpeed")]
    public int chargeSpeed { get; set; }

    [XmlElement("StaminaCost")]
    public int staminaCost { get; set; }

    [XmlElement("ManaCost")]
    public int manaCost { get; set; }
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

}
[Serializable]
[XmlRoot("WeaponCollection")]
public class BaseWeaponList
{
    [XmlArray("Weapons")]
    [XmlArrayItem("BaseWeapon", typeof(BaseWeaponClass))]
    public List<BaseWeaponClass> weapons { get; set; }
}