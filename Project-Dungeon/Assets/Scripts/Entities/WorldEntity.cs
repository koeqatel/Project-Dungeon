using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEntity : MonoBehaviour
{
    /// <summary>
    /// This guid indicates the owner of the item
    /// </summary>
    public string owner;

    /// <summary>
    /// This is the instance id of this item, making it unique in the game world.
    /// </summary>
    public string instanceId;

    /// <summary>
    /// This is the actual value of the World Entity
    /// </summary>
    public double value;

    /// <summary>
    /// This boolean indiates if the entity is in a players inventory
    /// </summary>
    public bool isInInventory;

    /// <summary>
    /// This boolean indicates if the entity is a pickupable entity
    /// </summary>
    public bool isPickupable;

    /// <summary>
    /// This is the actual sprite that is shown in the world
    /// </summary>
    public List<Sprite> entitySprite { get; set; }

    /// <summary>
    /// This is the actual sprite that is shown in the inventory slot (If this is null it should load the entitySprite as inventorySprite)
    /// </summary>
    public Sprite inventorySprite
    {
        get
        {
            if (inventorySprite == null)
            {
                if (entitySprite.Count > 0)
                    return entitySprite[0];
                else
                    return null;
            }
            else
                return inventorySprite;
        }
        set
        {
            inventorySprite = value;
        }
    }

    public string configPath { get; set; }

    /// <summary>
    /// Constructor what is here to say?....
    /// </summary>
    public WorldEntity ()
    {
        owner = "world";
        instanceId = Guid.NewGuid().ToString();
        value = 0;
        isInInventory = false;
        isPickupable = false;
    }
}
