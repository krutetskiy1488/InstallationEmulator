using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Connector : MonoBehaviour
{
    public int Type { get; set; }


    private void OnCollisionEnter(Collision collision)
    {
        var obj = collision.gameObject;
        GetComponent<Renderer>().material.color = Color.green;

        switch (obj.name)
        {
            case "Red":
            {
                Type = 1; break;
            }
            case "Brown":
            {
                Type = 2; break;
            }
            case "Blue":
            {
                Type = 3; break;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        var obj = collision.gameObject;

        obj.transform.position = transform.GetChild(0).position;
    }

    private void OnCollisionExit(Collision collision)
    {
        var obj = collision.gameObject;

        Type = 0;

        GetComponent<Renderer>().material.color = Color.red;
    }
}
