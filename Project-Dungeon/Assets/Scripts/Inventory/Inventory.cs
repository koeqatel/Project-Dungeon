using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryEntity : MonoBehaviour
{
    /// <summary>
    /// Inventory items contains all items of the assigned player
    /// </summary>
    public List<WorldEntity> inventoryItems { get; private set; }

    public InventoryEntity() { inventoryItems = new List<WorldEntity>(); }
}
