using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int velInterval = 1;
    public int maxvel = 4;
    public int dashDelay = 30;
    public int dashCooldown = 1;
    public int dashSpeed = 6;
    public int dashTime = 60;

    private const float deadzone = .2F;
    private const float forceAmount = 100f;
    private int dashTimer = 0;
    private int dashCooldownTimer = 0;
    private int dashResetTimer = 0;
    private float screenWidth;
    private Rigidbody2D rb;

    private string state = "idle";

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        screenWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).x - Camera.main.ScreenToWorldPoint(Vector3.zero).x;
    }

    void FixedUpdate()
    {
        if(Input.GetAxisRaw("Horizontal") < -deadzone)
        {
            if(state != "left" && state != "dashleft")
            {
                if(dashTimer < 0 && dashCooldownTimer == 0)
                {
                    dashTimer = 0;
                    dashCooldownTimer = dashCooldown;
                    dashResetTimer = dashTime;
                    state = "dashleft";
                }
                else
                {
                    dashTimer = -dashDelay;
                    state = "left";
                }
            }
        }
        else if(Input.GetAxisRaw("Horizontal") > deadzone)
        {
            if (state != "right" && state != "dashright")
            {
                if (dashTimer > 0 && dashCooldownTimer == 0)
                {
                    dashTimer = 0;
                    dashCooldownTimer = dashCooldown;
                    dashResetTimer = dashTime;
                    state = "dashright";
                }
                else
                {
                    dashTimer = dashDelay;
                    state = "right";
                }
            }
        }
        else
        {
            state = "idle";
        }

        switch(state)
        {
            case "right":
                if (rb.velocity.x < maxvel)
                    rb.velocity += new Vector2(velInterval, 0);
                if (rb.velocity.x > maxvel)
                    rb.velocity -= new Vector2(velInterval, 0);
                break;
            case "left":
                if (rb.velocity.x > -maxvel)
                    rb.velocity -= new Vector2(velInterval, 0);
                if (rb.velocity.x < -maxvel)
                    rb.velocity += new Vector2(velInterval, 0);
                break;
            case "dashright":
                rb.velocity = new Vector2(dashSpeed, 0);
                if (dashResetTimer == 0)
                    state = "right";
                break;
            case "dashleft":
                rb.velocity = new Vector2(-dashSpeed, 0);
                if (dashResetTimer == 0)
                    state = "left";
                break;
            default:
                if (Mathf.Abs(rb.velocity.x) != 0)
                    rb.velocity -= new Vector2(velInterval * Mathf.Sign(rb.velocity.x), 0);
                break;
        }

        if (dashTimer > 0)
            --dashTimer;
        else if (dashTimer < 0)
            ++dashTimer;

        if (dashCooldownTimer > 0)
            --dashCooldownTimer;

        if (dashResetTimer > 0)
            --dashResetTimer;
    }
    
}
