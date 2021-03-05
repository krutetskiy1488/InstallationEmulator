using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public static Text OnOff;

    private enum State
    {
        Down = 0,
        Up = 1,
        Unable
    }

    public float Speed = 0.8f;
    public float Up = 1.55f;
    public float Bottom = 1.4f;

    private State _state = State.Unable;

    void Update()
    {
        switch (_state)
        {
            case State.Down:
            {
                transform.Translate(Vector3.back * Time.deltaTime * Speed);
                break;
            }
            case State.Up:
            {
                transform.Translate(Vector3.forward * Time.deltaTime * Speed);
                break;
            }
            case State.Unable:
            {
                break;
            }
        }

        if (transform.position.y <= Bottom)
            _state = State.Up;
        else if (transform.position.y >= Up)
            _state = State.Unable;
    }

    void OnMouseDown()
    {
        if(_state != State.Up)
            _state = State.Down;

        OnOff.text = (OnOff.text == "ON") ? "OFF" : "ON";
    }
}
