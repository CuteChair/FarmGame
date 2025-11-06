using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlaceCrops : MonoBehaviour
{
    public static event Action<ItemData> OnPlacedCropEvent;

    [SerializeField] private GameObject selector;
    [SerializeField] private ItemData currentCropsData;
    [SerializeField] private LayerMask interactibleLayer;

    //private HashSet<Vector3Int> placedCropsLocations = new HashSet<Vector3Int>();

    [SerializeField] private Tilemap tilemap;
    private Vector3Int lastHoveredCell;

    private void Awake()
    {
       // tilemap = GameObject.FindGameObjectWithTag("Interact").GetComponent<Tilemap>();
        
    }

    private void OnEnable()
    {
        PlayerInventoryManager.OnSelectedItemEvent += UpdateItemToPlace;
    }
    private void OnDisable()
    {
        PlayerInventoryManager.OnSelectedItemEvent -= UpdateItemToPlace;
    }

    private void Update()
    {

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0f;


        Vector3Int cellPos = tilemap.WorldToCell(worldPos);

       
        if (lastHoveredCell != cellPos)
        {
            lastHoveredCell = cellPos;

            if (tilemap.HasTile(cellPos))
            {
                selector.SetActive(true);
                selector.transform.position = tilemap.GetCellCenterWorld(cellPos);
            }
            else
            {
                selector.SetActive(false);
            }
        }

        if (Input.GetMouseButtonUp(0) && currentCropsData != null)
        {
            PlaceCrop(currentCropsData.ItemPrefab, cellPos);
        }
    }


    private void UpdateItemToPlace(ItemData obj)
    {
        currentCropsData = obj;
    }

    private void PlaceCrop(GameObject obj, Vector3Int cellPos)
    {
        if (tilemap.HasTile(cellPos) && !SavedCropScene.Instance.CheckForPosition(cellPos))
        {
            Vector2 cropsOffset = new Vector2(cellPos.x + 0.5f, cellPos.y + 0.5f);
            GameObject newCrop = Instantiate(obj, cropsOffset, Quaternion.identity);

            SaveCropData newCropData = new SaveCropData
            {
                CropData = currentCropsData,
                CropLocation = cropsOffset,
                GameTime = GameTimeManager.Instance.GetGameTimeInSec()
            };

            SavedCropScene.Instance.AddCropToSave(cellPos, newCropData);

            OnPlacedCropEvent?.Invoke(currentCropsData); // optional event
        }
        else
        {
            Debug.Log("Can't place crop here!");
        }
    }
}
