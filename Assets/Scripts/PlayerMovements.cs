using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Sprite[] characterSprites;
    private SpriteRenderer p_SR;

    private float moveX => Input.GetAxisRaw("Horizontal");
    private float moveY => Input.GetAxisRaw("Vertical");

    private void Awake()
    {
        p_SR = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        p_SR.sprite = characterSprites[0];

    }
    void Update()
    {
        ChangePlayerOrientation();

        Vector2 move = new Vector2(moveX, moveY).normalized;

        transform.Translate(move * moveSpeed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        p_SR.sortingOrder = Mathf.RoundToInt(transform.position.y * -100);
    }

    private void ChangePlayerOrientation()
    {
        bool w_Held = Input.GetKey(KeyCode.W);
        bool a_Held = Input.GetKey(KeyCode.A);
        bool s_Held = Input.GetKey(KeyCode.S);
        bool d_Held = Input.GetKey(KeyCode.D);
        
        if (w_Held && !a_Held && !s_Held && !d_Held)
        {
            p_SR.sprite = characterSprites[1];
        }
        else if (s_Held && !a_Held && !w_Held && !d_Held)
        {
            p_SR.sprite = characterSprites[0];
        }
        else if (a_Held && !w_Held && !s_Held && !d_Held)
        {
            p_SR.sprite = characterSprites[3];
        }
        else if (d_Held && !a_Held && !s_Held && !w_Held)
        {
            p_SR.sprite = characterSprites[2];
        }
    }  
}
