using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateButton : MonoBehaviour
{
    public Slider Slider;
    public Text Value;
    public Text Status;
    public float Speed = 1.0f;

    private bool _rotate = false;

    private int _inx = 0;
    private List<(float angle, int mult)> _steps = new List<(float angle, int mult)>()
    {
        (0,  1),
        (50, 1),
        (90, 5),
        (120, 10)
    };

    public static int Mult = 1;

    void Start()
    {
        Slider.value = Slider.maxValue / 2;
    }

    void Update()
    {

        if (_rotate)
        {
            transform.RotateAround(transform.position, new Vector3(0, 1, 0), Time.deltaTime * Speed);
        }

        if (transform.eulerAngles.y <= _steps[(_inx + 1)% _steps.Count].angle + 1f && transform.eulerAngles.y >= _steps[(_inx + 1) % _steps.Count].angle - 1f)
        {
            _rotate = false;
            _inx++;
        }

        SetStatus();
        SetValue();

        Mult = _steps[_inx % _steps.Count].mult;
    }

    void SetStatus()
    {
        string text;
        switch (_inx % _steps.Count)
        {
            case 0:
            {
                text = "КАЛИБРОВКА";
                break;
            }
            case 1:
            {
                text = "1X";
                break;
            }
            case 2:
            {
                text = "5X";
                break;
            }
            case 3:
            {
                text = "10X";
                break;
            }
            default:
            {
                text = "ERROR";
                break;
            }
        }

        Status.text = text;
    }

    void SetValue()
    {
        var t = _steps[_inx % _steps.Count].mult;
        Value.text = $"{Slider.value * t:N}";
    }

    void OnMouseDown()
    { 
        _rotate = true;
    }
}
