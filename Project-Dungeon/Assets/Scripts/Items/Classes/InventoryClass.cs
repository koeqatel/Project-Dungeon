using System.Collections.Generic;
using UnityEngine;

public class InventoryClass {
    public GameObject inventorySlots { get; set; }
    public BaseWeaponRanged inventoryItems { get; set; }
}

public class InventoryListClass
{
    public List<InventoryClass> inventory { get; set; }
}
