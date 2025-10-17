using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlaceCrops : MonoBehaviour
{
    [SerializeField] private GameObject selector;
    [SerializeField] private GameObject crops;
    [SerializeField] private LayerMask interactibleLayer;

    private Tilemap tilemap;
    private Vector3Int lastHoveredCell;

    private void Awake()
    {
        tilemap = GameObject.FindGameObjectWithTag("Interact").GetComponentInChildren<Tilemap>();
    }

    private void Update()
    {

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0f;


        Vector3Int cellPos = tilemap.WorldToCell(worldPos);

       
        if (lastHoveredCell != cellPos)
        {
            lastHoveredCell = cellPos;

            if (tilemap.HasTile(cellPos))
            {
                selector.SetActive(true);
                selector.transform.position = tilemap.GetCellCenterWorld(cellPos);
            }
            else
            {
                selector.SetActive(false);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (tilemap.HasTile(cellPos))
            {
                Vector2 cropsOffset = new Vector2(cellPos.x + 0.5f, cellPos.y + 0.5f);
                Debug.Log("Clicked " + cellPos);
                GameObject clone = Instantiate(crops, cropsOffset, Quaternion.identity);
            }
        }
    }
}
