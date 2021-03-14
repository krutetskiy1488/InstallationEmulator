using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public static class Configuration
{
    private static readonly System.Random _rd = new System.Random();

    private static List<(int, int, int)> _configurations = new List<(int, int, int)>
    {
        (1, 2, 3)
    };

    public static float GetValue(int[] config)
    {
        if (!config.All(c => c > 0))
            return -1;
        
        return (float) (_rd.Next(0, 9) + _rd.NextDouble());
    }
}

public class LogicScript : MonoBehaviour
{
    public Text Value;
    public Slider Slider; 

    private List<Connector> _connectors;
    private int[] _config;
    private int[] _compar;

    void Start()
    {
        _connectors = FindObjectsOfType<Connector>().ToList();
        _config = new int[_connectors.Count];
        _compar = new int[]
        {
            0, 0, 0
        };
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
        float value = Slider.value;

        if (!_compar.SequenceEqual(_config))
        {
            var update = Configuration.GetValue(_config);
            if (update > 0)
            {
                value = update;
                Slider.value = update;
            }

            _compar[0] = _connectors[0].Type;
            _compar[1] = _connectors[1].Type;
            _compar[2] = _connectors[2].Type;
        }

        Value.text = $"{value:N}";
    }
}
