using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int cat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            if(collision.gameObject.GetComponent<EnemyMovement>().getVulnerable() == false)
            {
                health -= collision.gameObject.GetComponent<EnemyDamage>().damage;
            }
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Bullet")
        {
            health -= collision.gameObject.GetComponent<EnemyDamage>().damage;
            Destroy(collision.gameObject);
        }
    }
}
