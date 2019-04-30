using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject pin;
    public float speed;
    public float turnRadius;
    private Rigidbody2D rb;
    int pinNum;
    //Need to implement
    float waitTime;
    float lastTime;
    bool vulnerable = true;
    bool shooting = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pinNum = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(waitTime > 0){
            waitTime -= (Time.time - lastTime);
        }
        check();
        //rotate();
        move();
        lastTime = Time.time;
    }

    public void setSpeed(float sp)
    {
        speed = sp;
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
        rb.velocity = new Vector2(0, 0);
        if (waitTime <= 0)
        {
            rb.AddForce(transform.right * speed);
        }
        
    }

    private void check()
    {
        //Debug.Log((pin[pinNum].transform.position - transform.position).magnitude);
        if ((pin.transform.position - transform.position).magnitude < turnRadius)
        {
            waitTime = pin.GetComponent<pinScript>().waitTime;
            vulnerable = pin.GetComponent<pinScript>().vulnerable;
            shooting = pin.GetComponent<pinScript>().shooting;
            speed = pin.GetComponent<pinScript>().speed;

            if (pin.GetComponent<pinScript>().getNext() != null)
            {
                pin = pin.GetComponent<pinScript>().getNext();
            }
            else{
                pin = GameObject.FindGameObjectWithTag("Despawner");
            }
            
        }
        
    }

    public void startPin(GameObject startPin)
    {
        pin = startPin;
    }
}
