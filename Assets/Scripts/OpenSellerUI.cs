using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSellerUI : MonoBehaviour
{
    private bool canReach;
    [SerializeField] private Canvas canvas;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && canReach)
        {
            if (!canvas.isActiveAndEnabled)
            {
                canvas.gameObject.SetActive(true);
            }
            else
            {
                canvas.gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canReach = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canReach = false;
        }

        if (canvas.isActiveAndEnabled)
        {
            canvas.gameObject.SetActive(false);
        }
    }
}
