using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject pin;
    public float speed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rotate();
        move();
        
    }

    void rotate()
    {
        Vector3 diff = (pin.transform.position - transform.position).normalized;
        transform.rotation = Quaternion.Euler(0f,0f,Mathf.Atan2(diff.y,diff.x) * Mathf.Rad2Deg);
        
        /*
         * Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
         diff.Normalize();
 
         float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
         transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        */
    }

    private void move()
    {
        rb.velocity = new Vector2(0, 1 * speed);
    }
}
