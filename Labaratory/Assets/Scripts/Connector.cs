using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay(Collision collision)
    {
        print("Log");
        var obj = collision.gameObject;

        obj.GetComponent<Renderer>().material.color = Color.green;
        transform.position = obj.transform.GetChild(0).position;
    }

    private void OnCollisionExit(Collision collision)
    {
        print("Log");
        var obj = collision.gameObject;

        obj.GetComponent<Renderer>().material.color = Color.red;
    }
}
