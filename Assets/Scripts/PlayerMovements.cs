using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private float moveX => Input.GetAxisRaw("Horizontal");
    private float moveY => Input.GetAxisRaw("Vertical");

    void Update()
    {
        Vector2 move = new Vector2(moveX, moveY).normalized;

        transform.Translate(move * moveSpeed * Time.deltaTime);
    }
}
