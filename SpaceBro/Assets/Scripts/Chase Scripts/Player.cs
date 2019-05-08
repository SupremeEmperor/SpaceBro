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
    public int bumpSpeed = 4;

    private const float deadzone = .2F;
    private const float forceAmount = 100f;
    private int dashTimer = 0;
    private int dashCooldownTimer = 0;
    private int dashResetTimer = 0;
    private float screenWidth;
    public Vector3 startPoint = Vector3.zero;
    public Vector3 destPoint = Vector3.zero;
    private Rigidbody2D rb;

    public string state = "idle";

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        screenWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).x - Camera.main.ScreenToWorldPoint(Vector3.zero).x;
    }

    void FixedUpdate()
    {
        if(Input.GetAxisRaw("Fire1") == 1)
        {
            if(startPoint == Vector3.zero)
            {
                startPoint = transform.position;
                destPoint = transform.position + new Vector3(0, 1 / 3F);
            }
            state = "bump";
        }
        else if (transform.position.y > startPoint.y)
        {
            state = "bumpretract";
        }
        else if (state == "bumpretract")
        {
            state = "idle";
            rb.velocity = new Vector2(rb.velocity.x, 0);
            startPoint = Vector3.zero;
        }
        else if (state != "bump" && state != "bumprectract")
        {
            if (Input.GetAxisRaw("Horizontal") < -deadzone)
            {
                if (state != "left" && state != "dashleft")
                {
                    if (dashTimer < 0 && dashCooldownTimer == 0)
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
            else if (Input.GetAxisRaw("Horizontal") > deadzone)
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
        }
        else
        {
            state = "idle";
        }

        switch (state)
        {
            case "bump":
                if (transform.position.y < destPoint.y)
                    rb.velocity = new Vector2(0, bumpSpeed);
                else
                    rb.velocity = Vector2.zero;
                break;
            case "bumpretract":
                rb.velocity = new Vector2(0, -bumpSpeed);
                break;
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
                if (Mathf.Abs(rb.velocity.y) != 0)
                    rb.velocity = new Vector2(rb.velocity.x, 0);
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
