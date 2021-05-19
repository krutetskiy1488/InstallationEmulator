using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RotateButton : MonoBehaviour
{
    public float Speed = 1.0f;

    private bool _rotate = false;

    private int _inx = 0;
    private List<(float angle, int mult)> _steps = new List<(float angle, int mult)>()
    {
        (340,  1),
        (21, 1),
        (60, 5),
        (110, 20),
        (130, 100)
    };

    public Slider Slider;

    private Slidewire _slidewire;
    private LogicScript _logic;

    public int Mult = 1;

    void Start()
    {
        _slidewire = FindObjectOfType<Slidewire>();
        _logic = FindObjectOfType<LogicScript>();
    }

    public void Update()
    {

        if (_rotate)
            transform.RotateAround(transform.position, new Vector3(0, 1, 0), Time.deltaTime * Speed);

        var y = transform.eulerAngles.y;

        if (y <= _steps[(_inx + 1) % _steps.Count].angle + 1f && y >= _steps[(_inx + 1) % _steps.Count].angle - 1f)
        {
            _rotate = false;
            _inx++;
        }

        if (Mult != _steps[_inx % _steps.Count].mult)
        {
            Mult = _steps[_inx % _steps.Count].mult;
            Slider.value = (_logic.ValueF * Slider.maxValue) / (Slider.value / Mult);
        }
    }

    void OnMouseDown()
    {
        _rotate = true;
    }
}
