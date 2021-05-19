using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class Slidewire : MonoBehaviour
{
    public float Step;

    public GameObject ArrowHold;
    public GameObject Arrow;
    public Slider Slider;

    private Button _button;
    private RotateButton _rotateButton;

    private float _start = -72f;
    private float _cur;
    private float _prev;
    private float _center = 5f;
    private int _coff;

    void Start()
    {
        var rd = new System.Random();

        _button = FindObjectOfType<Button>();
        _rotateButton = FindObjectOfType<RotateButton>();

        //Arrow.transform.RotateAround(ArrowHold.transform.position, new Vector3(0, 1, 0), _start);

        Slider.onValueChanged.AddListener(delegate { ValueChanged();});
    }

    public void ValueChanged()
    {
        var dif = Slider.value - _center;
        ClearArrow();
        Arrow.transform.RotateAround(ArrowHold.transform.position, new Vector3(0, 1, 0),
            Math.Min(Math.Max(dif * 18 / _coff, -72), 72));
    }

    void Update()
    {
        if (_button.Mode.text == "OFF")
        {
            Slider.enabled = false;
            return;
        }
        else
            Slider.enabled = true;

        _coff = _rotateButton.Mult;
    }

    public void UpdateArrow(float center)
    {
        _center = center;
        var dif = Slider.value - center;
        Arrow.transform.RotateAround(ArrowHold.transform.position, new Vector3(0, 1, 0), Math.Min(Math.Max(dif * 18, 0), 144));
    }

    public void ArrowToLeft()
    {
        var center = 5 * _coff;
        var dif = Slider.value - center;
        ClearArrow();
        Arrow.transform.RotateAround(ArrowHold.transform.position, new Vector3(0, 1, 0), Math.Min(Math.Max(dif * 18 , -72), 72));

    }

    public void ClearArrow()
    {
        var v = Arrow.transform.rotation;
        Arrow.transform.RotateAround(ArrowHold.transform.position, new Vector3(0, 1, 0), -v.eulerAngles.y);
    }
}
