using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireControler : MonoBehaviour
{
    public GameObject bullet;
    public GameObject parent;
    public float fireRate;
    float nextFire;
    // Start is called before the first frame update
    void Start()
    {
        nextFire = Time.time + fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Transform mine = parent.transform;
            Instantiate(bullet,mine.position,Quaternion.identity);
        }
    }
}
