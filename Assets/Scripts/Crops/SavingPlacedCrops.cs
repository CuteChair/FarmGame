using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingPlacedCrops : MonoBehaviour
{
    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    private void AddToList(Vector3Int cellPos, ItemData data, Vector2 location)
    {
        //print(data + ", " + location);
        SaveCropData newCrop = new SaveCropData();
        newCrop.CropData = data;
        newCrop.CropLocation = location;
        newCrop.GameTime = GameTimeManager.Instance.GetGameTimeInSec();
        //print("Data : " + newCrop.CropData + "| Location : " + newCrop.CropLocation);
        SavedCropScene.Instance.AddCropToSave(cellPos, newCrop);
        
    }
}
