using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject[] pin;
    public float speed;
    public float turnRadius;
    private Rigidbody2D rb;
    int pinNum;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pinNum = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        check();
        rotate();
        move();
        
    }

    void rotate()
    {
        Vector3 diff = (pin[pinNum].transform.position - transform.position).normalized;
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
        rb.velocity = new Vector2(0, 0);
        rb.AddForce(transform.right * speed);
    }

    private void check()
    {
        Debug.Log((pin[pinNum].transform.position - transform.position).magnitude);
        if ((pin[pinNum].transform.position - transform.position).magnitude < turnRadius)
        {
            if (pinNum < (pin.Length - 1))
            {
                pinNum++;
            }
            else{
                pin[pinNum] = GameObject.FindGameObjectWithTag("Despawner");
            }
        }
    }
}
