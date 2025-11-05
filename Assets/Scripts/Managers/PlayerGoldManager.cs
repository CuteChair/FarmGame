using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerGoldManager : MonoBehaviour
{

    public static PlayerGoldManager Instance { get; private set; }
    public int PlayersGold { get; private set; }

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

    public void AddGold(int amount) => PlayersGold += amount;

    public void RemoveGold(int amout) => PlayersGold -= amout;

}
