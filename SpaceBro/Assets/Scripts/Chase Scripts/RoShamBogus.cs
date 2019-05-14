using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoShamBogus : MonoBehaviour
{
    
    public string state = "idle";

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetLocation(Vector3 location)
    {
        transform.Translate(location - transform.position);
    }

    void SetSpeed()
    {

    }

    void SetRock()
    {
        state = "rock";
    }

    void SetPaper()
    {
        state = "paper";
    }

    void SetScissors()
    {
        state = "scissors";
    }
}
