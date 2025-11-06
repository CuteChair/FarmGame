using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCropFromData : MonoBehaviour
{
    private void OnEnable()
    {
        SavedCropScene.OnMainMapSceneEvent += LoadCrops;
    }

    private void OnDisable()
    {
        SavedCropScene.OnMainMapSceneEvent -= LoadCrops;
    }

    private void LoadCrops(Dictionary<Vector3Int, SaveCropData> cropsToLoad, float gameTime)
    {
        foreach(var kvp in cropsToLoad)
    {
            Vector3Int cellPos = kvp.Key;
            SaveCropData cropData = kvp.Value;

            Vector3 newCropPosition = new Vector3(cropData.CropLocation.x, cropData.CropLocation.y, 0f);
            GameObject newCrop = Instantiate(cropData.CropData.ItemPrefab, newCropPosition, Quaternion.identity);

            Crops currentCrop = newCrop.GetComponent<Crops>();
            float timeElapsed = gameTime - cropData.GameTime;

            if (currentCrop != null)
                currentCrop.SetGrowthTime(timeElapsed);
            else
                Debug.LogWarning("Didn't find Crops component on instantiated crop!");
        }
    }
    //for(int i = 0; i < cropsToLoad.Count; i++)
    //{
    //    Vector3 newCropPosition = new Vector3(cropsToLoad[i].CropLocation.x, cropsToLoad[i].CropLocation.y, 0f);
    //    GameObject newCrop = Instantiate(cropsToLoad[i].CropData.ItemPrefab, newCropPosition, Quaternion.identity);
    //    Crops currentCrop = newCrop.GetComponent<Crops>();
    //    float timeElapsed = gameTime - cropsToLoad[i].GameTime;
    //    if (currentCrop != null)
    //        currentCrop.SetGrowthTime(timeElapsed);
    //    else
    //        print("Didnt find crop component");

    //}
}

