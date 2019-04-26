using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRotation : MonoBehaviour
{
    public GameObject pin;

    // Update is called once per frame
    void Update()
    {
        pin = gameObject.GetComponent<EnemyMovement>().pin;
        Vector3 diff = (pin.transform.position - transform.position).normalized;
        transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg);

    }
}
