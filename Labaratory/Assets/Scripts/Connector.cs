using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connector : MonoBehaviour
{
    public static string ConnectedPlace { get; set; }
    public static string ConnectorName { get; set; }

    private void OnCollisionStay(Collision collision)
    {
        var obj = collision.gameObject;
        if (obj.tag != "ConnectPoint")
            return;

        ConnectedPlace = obj.name;

        obj.GetComponent<Renderer>().material.color = Color.green;
        transform.position = obj.transform.GetChild(0).position;
    }

    private void OnCollisionExit(Collision collision)
    {
        var obj = collision.gameObject;
        if (obj.tag != "ConnectPoint")
            return;

        ConnectedPlace = null;

        obj.GetComponent<Renderer>().material.color = Color.red;
    }
}
