using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoShamBogus : MonoBehaviour
{
    
    public string state = "idle";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetLocation()
    {

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
