using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float life = 5;
    float time;
    Rigidbody2D rb; 
    // Start is called before the first frame update
    void Start()
    {
        time = Time.time;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, 0);
        
        rb.AddForce(transform.up * -speed);
        if ((time + life) <= Time.time)
        {
            Destroy(gameObject);
        }
    }
}
