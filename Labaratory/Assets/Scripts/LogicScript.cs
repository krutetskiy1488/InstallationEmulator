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
    private Slidewire _slidewire;

    private int[] _config;
    private int[] _compar;

    void Start()
    {
        _connectors = FindObjectsOfType<Connector>().ToList();
        _slidewire = FindObjectOfType<Slidewire>();
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
                if (update > Slider.maxValue / 2)
                {
                    Slider.maxValue += update - Slider.maxValue / 2 + 1;
                }
                else if (update < Slider.maxValue / 2)
                {
                    Slider.minValue += update - Slider.maxValue / 2 - 1;
                }

                _slidewire.UpdateArrow(update);
            }

            _compar[0] = _connectors[0].Type;
            _compar[1] = _connectors[1].Type;
            _compar[2] = _connectors[2].Type;
        }

        Value.text = $"{GetValidValue(value):N}";
    }

    float GetValidValue(float value)
    {
        if (value > 10f)
            return 10f;
        else if (value < 0f)
            return 0f;
        else
            return value;
    }
}
