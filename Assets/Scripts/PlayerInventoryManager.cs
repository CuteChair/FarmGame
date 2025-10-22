using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventoryManager : MonoBehaviour
{
    private List<GameObject>[] playersInventory = new List<GameObject>[9];
    [SerializeField] private GameObject[] placeHolders = new GameObject[10];

    private void Awake()
    {
        int test = 0;
        for(int i = 0; i < playersInventory.Length; i++)
        {
            playersInventory[i] = new List<GameObject>();
            test++;
        }

        print("Created : " + test + " lists");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AddItem(placeHolders[0]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AddItem(placeHolders[1]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            AddItem(placeHolders[2]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            AddItem(placeHolders[3]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            AddItem(placeHolders[4]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            AddItem(placeHolders[5]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            AddItem(placeHolders[6]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            AddItem(placeHolders[7]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            AddItem(placeHolders[8]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            AddItem(placeHolders[9]);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            ShowInventory();
        }
    }
    private void AddItem(GameObject itemToAdd)
    {
        print("1");
        int emptySlotsChecker = 0;
        //Checks if the players inventory is empty
        for (int i = 0; i < playersInventory.Length; i++)
        {
            if (playersInventory[i].Count == 0)
                emptySlotsChecker++;
                
        }
        if (emptySlotsChecker == 9)
        {
            playersInventory[0].Add(itemToAdd);
            print($"Inventory was empty : {itemToAdd} was add at : 0 : 0");
            return;
        }

        print("2");
        //Checks if theres already a slot that contains the same gameobject
        bool found = false;

        for(int i = 0; i < playersInventory.Length; i++)
        {
            if (playersInventory[i].Count != 0)
            {
                if (playersInventory[i][0].gameObject == itemToAdd)
                {
                    playersInventory[i].Add(itemToAdd);
                    found = true;
                    print($"The same Game Object was found at slot : {i}! \nAdding {itemToAdd} to : {i}");
                    break;
                }
            }
            
        }

        if (found)
            return;

        print("3");
        //Checks if theres an empty spots where the item can be placed
        for (int i = 0; i < playersInventory.Length; i++)
        {
            if (playersInventory[i].Count == 0)
            {
                playersInventory[i].Add(itemToAdd);
                print($"New item added to the inventory at slot : {i}!\nAdding {itemToAdd} there");
                return;
            }
        }

        print("Inventory is full : Cant add item");

    }

    private void ShowInventory()
    {
        for (int i = 0;i < playersInventory.Length; i++)
        {
            print($"Slot {i} : {string.Join(", ", playersInventory[i])}");
        }
    }

    //------------------------------V1--------------------------------------------------
    //[SerializeField] private List<GameObject> inventory = new List<GameObject>();

    //[SerializeField] private GameObject PlaceholderItem;

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //        AddItem(PlaceholderItem);
    //    if (Input.GetKeyDown(KeyCode.R))
    //        RemoveItem(PlaceholderItem);
    //}

    //private void AddItem(GameObject item)
    //{
    //    inventory.Add(item);
    //}

    //private void RemoveItem(GameObject ObjectToRemove)
    //{
    //    if (inventory.Count == 0)
    //    {
    //        print("Inventory is empty");
    //        return;
    //    }    

    //    bool found = false;

    //    for (int i = 0; i < inventory.Count; i++)
    //    {
    //        if (inventory[i].gameObject == ObjectToRemove)
    //        {
    //            found = true;
    //            inventory.RemoveAt(i);
    //            break;
    //        }
    //    }

    //    if (!found)
    //        print("No object to remove in inventory");
    //}

}
