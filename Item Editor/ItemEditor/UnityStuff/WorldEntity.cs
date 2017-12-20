using Assets.Scripts.Entities;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEntity
{
    /// <summary>
    /// This is an unique item id
    /// </summary>
    public string itemId;

    /// <summary>
    /// The actual name of the item which is displayed in the game
    /// </summary>
    public string itemName;

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
    /// This indicates the rarity of the world entity
    /// </summary>
    public EntityRarity rarity;

    /// <summary>
    /// This is the actual sprite that is shown in the world 
    /// </summary>
    public List<string> entitySprites { get; set; }

    /// <summary>
    /// This is the actual sprite that is shown in the inventory slot (If this is null it should load the entitySprite as inventorySprite)
    /// </summary>
    public string inventorySprite
    {
        get
        {
            if (string.IsNullOrEmpty(_inventorySprite))
            {
                if (entitySprites.Count > 0)
                    return entitySprites[0];
                else
                    return null;
            }
            else
                return _inventorySprite;
        }
        set
        {
            _inventorySprite = value;
        }
    }

    private string _inventorySprite;

    public string configPath { get; set; }

    /// <summary>
    /// Constructor what is here to say?....
    /// </summary>
    public WorldEntity()
    {
        inventorySprite = null;
        entitySprites = new List<string>();

        owner = "world";
        instanceId = Guid.NewGuid().ToString();
        value = 0;
        isInInventory = false;
        isPickupable = false;
    }
}
