using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public static class Configuration
{
    private static List<(int, int, int)> _configurations = new List<(int, int, int)>
    {
        (1, 2, 3)
    };

    public static int GetValue(int[] config)
    {
        return 1;
    }
}

public class LogicScript : MonoBehaviour
{
    public Text Value;
    public Slider Slider; 

    private List<Connector> _connectors;
    private int[] _config;

    void Start()
    {
        _connectors = FindObjectsOfType<Connector>().ToList();
        _config = new int[_connectors.Count];
    }

    void Update()
    {
        _config[0] = _connectors[0].Type;
        _config[1] = _connectors[1].Type;
        _config[2] = _connectors[2].Type;

        SetValue();
    }

    void SetValue()
    {
        var value = Configuration.GetValue(_config);

        Value.text = $"{value:N}";
    }
}
