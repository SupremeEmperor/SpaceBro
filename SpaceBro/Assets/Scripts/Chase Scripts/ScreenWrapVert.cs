using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapVert : MonoBehaviour
{
    private float screenHeight;
    private GameObject[] ghosts = new GameObject[2];

    // Start is called before the first frame update
    void Start()
    {
        screenHeight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).y - Camera.main.ScreenToWorldPoint(Vector3.zero).y;
        CreateGhostShips();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Camera.main.WorldToViewportPoint(transform.position).y <= .25)
        {
            transform.Translate(new Vector3(0, screenHeight, 0));
            ghosts[0].transform.Translate(new Vector3(0, screenHeight, 0));
            ghosts[1].transform.Translate(new Vector3(0, screenHeight, 0));
        }
        if (Camera.main.WorldToViewportPoint(transform.position).y > .75)
        {
            transform.Translate(new Vector3(0, -screenHeight, 0));
            ghosts[0].transform.Translate(new Vector3(0, -screenHeight, 0));
            ghosts[1].transform.Translate(new Vector3(0, -screenHeight, 0));
        }
    }

    void CreateGhostShips()
    {
        ghosts[0] = Instantiate(gameObject, transform.position - new Vector3(0, screenHeight, 0), Quaternion.identity) as GameObject;
        ghosts[1] = Instantiate(gameObject, transform.position + new Vector3(0, screenHeight, 0), Quaternion.identity) as GameObject;
        ghosts[0].transform.parent = transform.parent;
        ghosts[1].transform.parent = transform.parent;
        Destroy(ghosts[0].GetComponent<ScreenWrap>());
        Destroy(ghosts[1].GetComponent<ScreenWrap>());
        Destroy(ghosts[0].GetComponent<ScreenWrapVert>());
        Destroy(ghosts[1].GetComponent<ScreenWrapVert>());
    }
}
