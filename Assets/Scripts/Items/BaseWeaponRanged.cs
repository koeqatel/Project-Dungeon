using System.Collections.Generic;
using UnityEngine;

public class BaseWeaponRanged : MonoBehaviour {

    public Sprite BulletSprite;
    public GameObject Database;

    public string weaponId;

    // Use this for initialization
    void Start () {
        SerializeWeapon();
    }
	
	// Update is called once per frame
	void Update () {

    }

    private void SerializeWeapon()
    {
        ItemDatabase itemDatabase = Database.GetComponent<ItemDatabase>();
        BaseWeaponList weapons = itemDatabase.baseWeapon;

        foreach (BaseWeaponClass weapon in weapons.weapons)
        {
            if (weaponId == weapon.itemId)
            {
                baseWeapon = weapon;
                break;
            }
        }
    }
}
