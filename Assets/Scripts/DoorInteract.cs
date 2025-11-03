using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteract : MonoBehaviour
{
    public static event Action<Vector3> OnEnterHouse;
    public static event Action OnExitHouse;

    [SerializeField] private int sceneIndex;
    [SerializeField] private bool isExitDoor = false; // set in inspector
    private bool inRange;

    private void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!isExitDoor)
            {
                // entering house: save position BEFORE loading
                OnEnterHouse?.Invoke(transform.position);
            }
            else
            {
                // exiting house: tell manager to place player at saved pos
                OnExitHouse?.Invoke();
            }

            SceneManager.LoadScene(sceneIndex);
        }
    }

    // trigger code stays the same…
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            inRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            inRange = false;
    }
}
