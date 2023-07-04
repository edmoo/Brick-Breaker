using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 0.05f;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.position += Vector2.right * speed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            rb.position += Vector2.left * speed;
        }
    }
}
