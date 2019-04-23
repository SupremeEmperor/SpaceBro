using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const float deadzone = .2F;
    private const int maxvel = 7;
    private const float forceAmount = 100f;
    private float screenWidth;
    private Rigidbody2D rb;
    protected string state = "idle";

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        screenWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).x - Camera.main.ScreenToWorldPoint(Vector3.zero).x;
    }

    void FixedUpdate()
    {
        if(Input.GetAxis("Horizontal") < -deadzone)
        {
            state = "left";
            if (rb.velocity.x > -maxvel)
                rb.AddForce(new Vector2(-forceAmount, 0f));
        }
        else if(Input.GetAxis("Horizontal") > deadzone)
        {
            state = "right";
            if (rb.velocity.x < maxvel)
                rb.AddForce(new Vector2(forceAmount, 0f));
        }
        else
        {
            state = "idle";
        }
        if (state == "idle")
            rb.drag = 20;
        else
            rb.drag = 0;

    }
    
}
