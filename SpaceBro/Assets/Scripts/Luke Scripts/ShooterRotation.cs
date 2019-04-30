using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterRotation : MonoBehaviour
{
    public bool trace;

    GameObject pin;
    // Start is called before the first frame update
    void Start()
    {
        pin = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (trace)
        {
            Vector3 diff = (pin.transform.position - transform.position).normalized;
            transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -90f);
        }
    }

    public void setRotation(bool to)
    {
        trace = to;
    }
}
