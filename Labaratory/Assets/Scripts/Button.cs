using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public Text Mode;

    private int _click = 0;
    public enum EState
    {
        Able = 0,
        Unable = 1
    }

    public float Speed = 0.8f;
    public float Up = 1.55f;
    public float Bottom = 1.4f;

    public EState State = EState.Unable;

    void Update()
    {
        if (State == EState.Unable)
            return;

        var dir = (_click % 2 == 0) ? 1 : -1;
        transform.Translate(dir * Vector3.forward * Time.deltaTime * Speed);

        if (transform.position.y <= Bottom || transform.position.y >= Up)
            State = EState.Unable;
    }

    void OnMouseDown()
    {
        State = EState.Able;
        _click++;

        Mode.text = Mode.text == "ON"? "OFF" : "ON";
    }
}
