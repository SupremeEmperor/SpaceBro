using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateExplosions : MonoBehaviour
{
    public GameObject explosionPrefab;
    public int numExplosions;
    public float xRange;
    public float yRange;
    public float interval;

    private float timer = 0;
    private int explosionsLeft;


    // Start is called before the first frame update
    void Start()
    {
        explosionsLeft = numExplosions;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (explosionsLeft > 0)
        {
            if (timer > interval)
            {
                Instantiate(explosionPrefab, transform.position + new Vector3(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange), 0), transform.rotation);
                new WaitForSeconds(interval);
                --explosionsLeft;
                timer -= interval;
            }
        } else {
            Destroy(gameObject);
        }
    }
}
