using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private const int timermax = 5;
    private const int forceAmount = 500;
    private float screenHeight;
    private float starty;
    private float timer;
    private string state = "idle";
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        timer = 2;
        starty = gameObject.transform.position.y;
        rb = gameObject.GetComponent<Rigidbody2D>();
        screenHeight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).y - Camera.main.ScreenToWorldPoint(Vector3.zero).y;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer += timermax;
            onTimer();
        }
    }

    void FixedUpdate()
    {
        if (state == "bump" && Camera.main.WorldToViewportPoint(transform.position).y <= 0)
        {
            state = "reset";
            transform.Translate(new Vector3(0, screenHeight, 0));
        }
        if (state == "reset" && transform.position.y <= starty)
        {
            state = "idle";
            rb.AddForce(new Vector2(0, forceAmount));
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    private void onTimer()
    {
        state = "bump";
        rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
        rb.AddForce(new Vector2(0, -forceAmount));
    }
}
