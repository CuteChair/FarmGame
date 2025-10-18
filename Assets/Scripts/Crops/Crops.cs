using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crops : MonoBehaviour
{
    [SerializeField] private float timeToGrow;
    private float thirdOfTime;
    private SpriteRenderer sR;
    [SerializeField] private Sprite[] cropSprites;
    private GameTimeManager gameTimeManager;

    private void Awake()
    {
        gameTimeManager = GameObject.FindGameObjectWithTag("Manager").GetComponentInChildren<GameTimeManager>();
        sR = GetComponent<SpriteRenderer>();

        thirdOfTime = timeToGrow * 0.33f;
    }

    private void Update()
    {
        timeToGrow -= Time.deltaTime;
        print(timeToGrow);

        UpdateSprite();
    }

    private void UpdateSprite()
    {

        if (timeToGrow > thirdOfTime * 2f)
        {
            print("Sprout");
            sR.sprite = cropSprites[0];
        }
        else if (timeToGrow > thirdOfTime)
        {
            print("Mid Sprout");
            sR.sprite = cropSprites[1];
        }
        else
        {
            print("Plant is ready");
            sR.sprite = cropSprites[2];
        }
    }
}
