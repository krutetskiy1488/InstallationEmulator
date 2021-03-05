using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connector : MonoBehaviour
{
    private void OnCollisionStay(Collision collision)
    {
        var obj = collision.gameObject;

        obj.GetComponent<Renderer>().material.color = Color.green;
        transform.position = obj.transform.GetChild(0).position;
    }

    private void OnCollisionExit(Collision collision)
    {
        var obj = collision.gameObject;

        obj.GetComponent<Renderer>().material.color = Color.red;
    }
}
