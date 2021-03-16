﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slidewire : MonoBehaviour
{
    public int Step;

    public GameObject ArrowHold;
    public GameObject Arrow;
    public Slider Slider;

    private Button _button;

    private float _cur;
    private float _prev;

    void Start()
    {
        var rd = new System.Random();

        _button = FindObjectOfType<Button>();

        _prev = Slider.value;
        _cur = _prev;
    }

    void Update()
    {
        

        if(_button.Mode.text == "OFF")
        {
            Slider.enabled = false;
            return;
        }
        else
            Slider.enabled = true;

        _prev = _cur;
        _cur = Slider.value;
        var dif = _cur - _prev;

        transform.Rotate(new Vector3(0, 0, 1), dif * Step);

        if (Arrow.transform.rotation.y >= 0.477f && dif > 0 || Arrow.transform.rotation.y <= -0.477f && dif < 0)
            return;

        Arrow.transform.RotateAround(ArrowHold.transform.position, new Vector3(0, 1, 0), dif * Step);
    }

    public void UpdateArrow(float update)
    {
        Arrow.transform.RotateAround(ArrowHold.transform.position, new Vector3(0, 1, 0), (_cur - update) * Step);
    }
}
