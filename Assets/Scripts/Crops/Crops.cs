using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Crops : MonoBehaviour
{
    //public string CropID;
    [SerializeField] private float totalGrowTime;
    private float currentGrowTime;
    [SerializeField] private Sprite[] growthSprites;

    private SpriteRenderer spriteRenderer;
    private int currentStage = -1;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentGrowTime = totalGrowTime;
    }

    private void Update()
    {
        if (currentGrowTime <= 0f)
            return;

        currentGrowTime -= Time.deltaTime;
        UpdateVisual();
    }

    private void LateUpdate()
    {
        spriteRenderer.sortingOrder = Mathf.RoundToInt(transform.position.y * -100);
    }

    private void UpdateVisual()
    {
        float growthPercent = 1f - (currentGrowTime / totalGrowTime);
        int stage = Mathf.FloorToInt(growthPercent * growthSprites.Length);
        stage = Mathf.Clamp(stage, 0, growthSprites.Length - 1);

        if (stage != currentStage)
        {
            currentStage = stage;
            spriteRenderer.sprite = growthSprites[currentStage];
        }
    }

    public bool IsReadyToHarvest()
    {
        return currentGrowTime <= 0f;
    }

    public void SetGrowthTime(float timeElapsed)
    {
        currentGrowTime -= timeElapsed;      

        if (currentGrowTime < 0f)
            currentGrowTime = 0f;            

        UpdateVisual();                      
    }

}
