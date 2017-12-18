using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeaponRanged : MonoBehaviour
{

    public Sprite bulletSprite;
    public GameObject database;

    public int weaponId;

    private WeaponClass weaponRanged = new WeaponClass();

    // Use this for initialization
    void Start()
    {
        serializeWeapon();
    }

    private void serializeWeapon()
    {
        ItemDatabase itemDatabase = database.GetComponent<ItemDatabase>();
        WeaponListClass weapons = itemDatabase.weapon;

        foreach (WeaponClass weapon in weapons.weapons)
        {
            if (weaponId == weapon.itemId)
            {
                weaponRanged = weapon;
                break;
            }
        }
    }
}
