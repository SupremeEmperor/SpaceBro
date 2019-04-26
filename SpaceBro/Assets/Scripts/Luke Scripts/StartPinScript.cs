using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPinScript : MonoBehaviour
{
    public GameObject toSpawn;

    //Input time chronologicly 
    public string hint = "Please input time Chronologicly";
    public float[] spawnTimes;
    private float time;
    int pos;


    // Start is called before the first frame update
    void Start()
    {
        time = Time.time;
        pos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (pos < spawnTimes.Length)
        {
            if (spawnTimes[pos] <= (Time.time - time))
            {
                Instantiate(toSpawn, gameObject.transform.position,Quaternion.identity).GetComponent<EnemyMovement>().startPin(gameObject);
                pos++;
            }
        }
    }
}
