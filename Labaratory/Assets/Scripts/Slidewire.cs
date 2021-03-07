using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slidewire : MonoBehaviour
{
    public int Step;

    public GameObject ArrowHold;
    public GameObject Arrow;
    public Slider MoveSlider;

    private int _mult = RotateButton.Mult;

    private float _cur;
    private float _prev;

    void Start()
    {
        _prev = MoveSlider.value;
        _cur = _prev;
    }

    void Update()
    {
        _prev = _cur;
        _cur = MoveSlider.value;
        var dif = _cur - _prev;

        transform.Rotate(new Vector3(0, 0, 1), dif * Step);
        Arrow.transform.RotateAround(ArrowHold.transform.position, new Vector3(0, 1, 0), dif * Step);
    }
}
