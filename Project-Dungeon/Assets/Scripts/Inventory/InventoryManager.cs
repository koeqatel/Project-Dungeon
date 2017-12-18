using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    public int startPositionX;
    public int startPositionY;

    public int totalSlotCount;
    public int totalSlotLenght;

    public GameObject itemSlotPrefab;
    public ToggleGroup itemSlotToggleGroup;

    private int posX;
    private int posY;

    private GameObject itemSlot;
    private int itemSlotCount;

    private bool isActive = false;

    private InventoryListClass inventorySlots;
    private InventoryClass inventoryItems;
    private InventoryClass Slot;

    private List<InventoryClass> gameObjectList;

    void Start()
    {
        inventorySlots = new InventoryListClass();
        inventoryItems = new InventoryClass();
        Slot = new InventoryClass();
        gameObjectList = new List<InventoryClass>();

        CreateInvSlots();
        GameObject.Find("Inventory").transform.localScale = new Vector3(0, 0, 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isActive)
            {
                GameObject.Find("Inventory").transform.localScale = new Vector3(1, 1, 1);
                isActive = true;
            }
            else if(isActive)
            {
                GameObject.Find("Inventory").transform.localScale = new Vector3(0, 0, 0);
                isActive = false;
            }
        }

        for (int i = 0; i < totalSlotCount; i++)
        {
            //if (inventoryItems[i] != null)
            //{
                
            //}
        }
    }

    private void CreateInvSlots()
    {
        posX = startPositionX;
        posY = startPositionY;

        for (int i = 0; i < totalSlotCount; i++)
        {
            itemSlot = Instantiate(itemSlotPrefab);
            itemSlot.name = "ItemSlot" + i.ToString();
            itemSlot.GetComponent<Toggle>().group = itemSlotToggleGroup;

            Slot.inventorySlots = itemSlot;
            gameObjectList.Add(Slot);

            itemSlot.transform.SetParent(this.gameObject.transform);
            itemSlot.GetComponent<RectTransform>().localPosition = new Vector3(posX, posY, 0);
            itemSlot.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 0);

            posX = posX + (int)itemSlot.GetComponent<RectTransform>().rect.width + 17;

            itemSlotCount++;

            if (itemSlotCount % totalSlotLenght == 0)
            {
                itemSlotCount = 0;

                posY = posY - (int)itemSlot.GetComponent<RectTransform>().rect.width - 5;
                posX = startPositionX;
            }
        }
        inventorySlots.inventory = gameObjectList;
    }

    public void AddItemToInv(Collision2D item)
    {
        if (item.gameObject.tag == "Items")
        {
            var itemPickedup = item.gameObject.GetComponent<BaseWeaponRanged>();

            foreach (InventoryClass inv in inventorySlots.inventory)
            {
                if(inv.inventorySlots != null && inv.inventoryItems == null)
                {
                    inv.inventoryItems = itemPickedup;
                    break;
                }
            }
        }
    }
}
