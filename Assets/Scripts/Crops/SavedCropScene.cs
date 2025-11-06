using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavedCropScene : MonoBehaviour
{
    public static SavedCropScene Instance;

    public static event Action<Dictionary<Vector3Int, SaveCropData>, float> OnMainMapSceneEvent;

    private Dictionary<Vector3Int, SaveCropData> cropsInScene = new Dictionary<Vector3Int, SaveCropData>();
    public IReadOnlyDictionary<Vector3Int, SaveCropData> CropsInScene => cropsInScene;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; 
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainMap")
        {
            OnMainMapSceneEvent?.Invoke(cropsInScene, GameTimeManager.Instance.GetGameTimeInSec());
        }
    }
    public bool CheckForPosition(Vector3Int pos)
    {
      return cropsInScene.ContainsKey(pos);
    }

    public void AddCropToSave(Vector3Int pos, SaveCropData data)
    {
        cropsInScene[pos] = data;
    }
}
