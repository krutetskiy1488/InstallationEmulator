using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public List<Connector> Connectors;
    private int[] _configure;

    void Start()
    {
        Connectors = FindObjectsOfType<Connector>().ToList();
        _configure = new int[3];
    }

    void Update()
    {
        _configure[0] = Connectors[0].Type;
        _configure[1] = Connectors[1].Type;
        _configure[2] = Connectors[2].Type;


    }
}
