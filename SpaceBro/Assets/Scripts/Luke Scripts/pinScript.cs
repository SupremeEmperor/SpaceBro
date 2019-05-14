using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinScript : MonoBehaviour
{
    public GameObject next;
    public float waitTime;
    public bool vulnerable;
    public bool shooting;
    public float speed = 100;
    

    public GameObject getNext()
    {
        return next;
    }
}
