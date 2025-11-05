using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavedCropScene : MonoBehaviour
{
    public static SavedCropScene Instance;

    public static event Action<List<SaveCropData>, float> OnMainMapSceneEvent;

    [SerializeField] private List<SaveCropData> CropsInScene = new List<SaveCropData>();

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
            OnMainMapSceneEvent?.Invoke(CropsInScene, GameTimeManager.Instance.GetGameTimeInSec());
        }
    }

    public void AddToSave(SaveCropData data)
    {
        CropsInScene.Add(data);
    }

    public void RemoveFromSave(SaveCropData data)
    {
        CropsInScene.Remove(data);
    }
}
