using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private float screenWidth;
    private GameObject[] ghosts = new GameObject[2];

    // Start is called before the first frame update
    void Start()
    {
        screenWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).x - Camera.main.ScreenToWorldPoint(Vector3.zero).x;
        CreateGhostShips();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Camera.main.WorldToViewportPoint(transform.position).x <= 0)
        {
            transform.Translate(new Vector3(screenWidth, 0, 0));
            ghosts[0].transform.Translate(new Vector3(screenWidth, 0, 0));
            ghosts[1].transform.Translate(new Vector3(screenWidth, 0, 0));
        }
        if (Camera.main.WorldToViewportPoint(transform.position).x > 1)
        {
            transform.Translate(new Vector3(-screenWidth, 0, 0));
            ghosts[0].transform.Translate(new Vector3(-screenWidth, 0, 0));
            ghosts[1].transform.Translate(new Vector3(-screenWidth, 0, 0));
        }
    }

    void CreateGhostShips()
    {
        ghosts[0] = Instantiate(gameObject, transform.position - new Vector3(screenWidth, 0, 0), Quaternion.identity) as GameObject;
        ghosts[1] = Instantiate(gameObject, transform.position + new Vector3(screenWidth, 0, 0), Quaternion.identity) as GameObject;
        Destroy(ghosts[0].GetComponent<ScreenWrap>());
        Destroy(ghosts[1].GetComponent<ScreenWrap>());
    }
}
