using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWindow : MonoBehaviour
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

    private GameObject[] inventorySlots;
    public BaseWeaponRanged[] inventoryItems;

    void Start()
    {
        CreateInvSlots();

        inventoryItems = new BaseWeaponRanged[totalSlotCount];
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
            if (inventoryItems[i] != null)
            {
                
            }
        }
    }

    private void CreateInvSlots()
    {
        inventorySlots = new GameObject[totalSlotCount];

        posX = startPositionX;
        posY = startPositionY;

        for (int i = 0; i < totalSlotCount; i++)
        {
            itemSlot = Instantiate(itemSlotPrefab);
            itemSlot.name = "ItemSlot" + i.ToString();
            itemSlot.GetComponent<Toggle>().group = itemSlotToggleGroup;

            inventorySlots[i] = itemSlot;
            //inventorySlots.Add(itemSlot);

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
    }
}
