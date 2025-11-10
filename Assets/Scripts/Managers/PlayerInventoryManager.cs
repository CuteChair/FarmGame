using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventoryManager : MonoBehaviour
{
    public static PlayerInventoryManager Instance;
    public static event Action<ItemData> OnSelectedItemEvent;

    [SerializeField] private InventorySlot[] inventory = new InventorySlot[9];
    private void OnEnable()
    {
        PickableItem.OnPickedUpItem += AddItem;
        PlaceCrops.OnPlacedCropEvent += RemoveItem;
        BuyingPlants.OnPlantBought += AddItem;
    }

    private void OnDisable()
    {
        PickableItem.OnPickedUpItem -= AddItem;
        PlaceCrops.OnPlacedCropEvent -= RemoveItem;
        BuyingPlants.OnPlantBought -= AddItem;
    }
    private void Awake()
    {
        if (Instance == null)
        {
            print("First instance load");
            for (int i = 0; i < inventory.Length; i++)
                inventory[i] = new InventorySlot();
        }
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

       
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            //ShowInventory();
        }

        for (int i = 0; i < 9; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                SelectSlot(i);
                break; 
            }
        }
    }

    public bool Contains(ItemData item)
    {
        return inventory.Any(slot => !slot.IsEmpty && slot.item == item);
    }

    private void AddItem(ItemData itemToAdd)
    {
        if (itemToAdd == null)
        {
            Debug.LogWarning("Tried to add a null item to inventory!");
            return;
        }

        // Try stacking
        foreach (var slot in inventory)
        {
            if (!slot.IsEmpty && slot.item == itemToAdd)
            {
                slot.AddItem(itemToAdd);
                Debug.Log($"Stacked {itemToAdd.name}");
                print("QTY sent : " + slot.quantity);
                return;
            }
        }

        // Try finding empty slot
        foreach (var slot in inventory)
        {
            if (slot.IsEmpty)
            {
                slot.AddItem(itemToAdd);
                Debug.Log($"Added a new item {itemToAdd.name}");
                return;
            }
        }

        Debug.Log("Inventory is full");
    }

    private void RemoveItem(ItemData itemToRemove)
    {
        foreach (var slot in inventory)
        {
            if (!slot.IsEmpty && slot.item == itemToRemove)
            {
                slot.quantity--;

                if (slot.quantity <= 0)
                {
                    slot.Clear();
                    Debug.Log($"Used last item: {itemToRemove.name}");
                        OnSelectedItemEvent?.Invoke(null);
                    
                }
                else
                {
                    Debug.Log($"Removed one: {itemToRemove.name} (x{slot.quantity} left)");
                }

                return;
            }
        }

        Debug.LogWarning($"Tried to remove {itemToRemove.name}, but it wasn't found in inventory!");
    }
    private void SelectSlot(int index)
    {
        if (index < 0 || index >= inventory.Length) return;

        InventorySlot selected = inventory[index];
        if (selected.IsEmpty)
        {
            return;
        }

        OnSelectedItemEvent?.Invoke(selected.item);
        print($"Selected: {selected.item}");
    }
    
}
