using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLocationManager : MonoBehaviour
{
    public static PlayerLocationManager Instance { get; private set; }

    private Vector3 savedOutsidePos;
    private bool hasSavedPos = false;
    private bool shouldPlacePlayer = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnEnable()
    {
        DoorInteract.OnEnterHouse += SavePosition;
        DoorInteract.OnExitHouse += PrepareTeleportBack;
    }

    private void OnDisable()
    {
        DoorInteract.OnEnterHouse -= SavePosition;
        DoorInteract.OnExitHouse -= PrepareTeleportBack;
    }

    private void SavePosition(Vector3 pos)
    {
        savedOutsidePos = pos;
        hasSavedPos = true;
    }

    private void PrepareTeleportBack()
    {
        shouldPlacePlayer = true;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (!shouldPlacePlayer || !hasSavedPos)
        {
            transform.position = new Vector3(0f, 0f, 0f);
            return;
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            player.transform.position = savedOutsidePos;

        shouldPlacePlayer = false;
    }
}
