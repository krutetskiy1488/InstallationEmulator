using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public static class Configuration
{
    private static (int, int, int) Current;

    private static Dictionary<(int, int, int), float> _configurations = new Dictionary<(int, int, int), float>()
    {
        {(1, 2, 3), 5.0f},
        {(1, 3, 2), 15.0f},
        {(2, 1, 3), 55.0f},
        {(3, 2, 1), 600.0f}
    };

    public static float GetValue(int[] config)
    {
        if (!config.All(c => c > 0))
            return -1;
    

        var key = (config[0], config[1], config[2]);

        //if (key == Current)
        //    return -1;
        
        //Current = key;
        var value = -1f;
        return _configurations.TryGetValue(key, out value)? value : -1;
    }
}

public class LogicScript : MonoBehaviour
{
    public Text Value;
    public Slider Slider; 

    private List<Connector> _connectors;
    private Slidewire _slidewire;
    private RotateButton _rotateButton;

    private int[] _config;
    private int[] _compare;
    private int _coff;

    public float ValueF = 5f;

    void Start()
    {
        Slider.value = 0;

        _connectors = FindObjectsOfType<Connector>().ToList();
        _slidewire = FindObjectOfType<Slidewire>();
        _rotateButton = FindObjectOfType<RotateButton>();

        _config = new int[_connectors.Count];
        _compare = new int[]
        {
            0, 0, 0
        };

    }

    public void Update()
    {
        _config[0] = _connectors[0].Type;
        _config[1] = _connectors[1].Type;
        _config[2] = _connectors[2].Type;

        _coff = _rotateButton.Mult;
        Slider.maxValue = _coff * 10;

        SetValue();
    }

    void SetValue()
    {
        float value = Slider.value;

        if (!_compare.SequenceEqual(_config))
        {
            var update = Configuration.GetValue(_config);
            ValueF = update;
            if (update <= 0)
            {
                Slider.value = 0;
                _slidewire.ArrowToLeft();
            }
            else if(update > 0)
            {
                _slidewire.UpdateArrow(update / _coff);
            }

            _compare[0] = _connectors[0].Type;
            _compare[1] = _connectors[1].Type;
            _compare[2] = _connectors[2].Type;
        }

        Value.text = $"{GetValidValue(value):N}";
    }

    float GetValidValue(float value)
    {
        value /= _coff;
        if (value > 10f)
            return 10f;
        else if (value < 0f)
            return 0f;
        else
            return value;
    }
}
