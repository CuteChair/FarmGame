using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crops : MonoBehaviour
{
    [SerializeField] private float timeToGrow;
    private float thirdOfTime;
    private SpriteRenderer sR;
    [SerializeField] private Sprite[] cropSprites;

    private void Awake()
    {
        sR = GetComponent<SpriteRenderer>();

        thirdOfTime = timeToGrow * 0.33f;
    }

    private void Update()
    {
        timeToGrow -= Time.deltaTime;
        //print(timeToGrow);

        UpdateSprite();
    }

    private void LateUpdate()
    {
        sR.sortingOrder = Mathf.RoundToInt(transform.position.y * -100);
    }

    private void UpdateSprite()
    {

        if (timeToGrow > thirdOfTime * 2f)
        {
            //print("Sprout");
            sR.sprite = cropSprites[0];
        }
        else if (timeToGrow > thirdOfTime)
        {
            //print("Mid Sprout");
            sR.sprite = cropSprites[1];
        }
        else
        {
            //print("Plant is ready");
            sR.sprite = cropSprites[2];
        }
    }
}
