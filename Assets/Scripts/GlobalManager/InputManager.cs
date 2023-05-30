using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InputManager : MonoSingleton<InputManager>
{
    private float axis;
    private bool isJumpButtonDown = false;
    private bool isFireButtonDown = false;

    public float Axis { get => axis; }
    public bool IsJumpButtonDown { get => isJumpButtonDown; }
    public bool IsFireButtonDown { get => isFireButtonDown; }

    private float t = 0f;

    // Start is called before the first frame update
    void Start()
    {
    }
    private void Update()
    {
        XInputAxis();
        JumpingButton();
    }
    private void XInputAxis()
    {
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || UIManager.Instance.MoveAxis == 1)
        {
            if(axis <= 0) {
                t = 0;
            }
            t += 2f * Time.deltaTime;
            axis = Mathf.Lerp(0f, 1f, t);
            return;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || UIManager.Instance.MoveAxis == -1)
        {
            if (axis >= 0)
            {
                t = 0;
            }
            t += 1f * Time.deltaTime;
            axis = Mathf.Lerp(0f, -1f, t);
            return;
        }
        axis = 0f;
    }
    private void JumpingButton()
    {
        if(Input.GetKeyDown(KeyCode.B) || Input.GetKey(KeyCode.UpArrow) || UIManager.Instance.JumpButtonDown)
        {
            isJumpButtonDown= true;
        }
        else if (Input.GetKeyUp(KeyCode.B) || Input.GetKeyUp(KeyCode.UpArrow) || !UIManager.Instance.JumpButtonDown)
        {
            isJumpButtonDown= false;
        }
    }
    private void FiringButton()
    {
        if (Input.GetKeyDown(KeyCode.F) || UIManager.Instance.FireButtonDown)
        {
            isFireButtonDown = true;
        }
        else if (Input.GetKeyUp(KeyCode.F) || !UIManager.Instance.FireButtonDown)
        {
            isFireButtonDown = false;
        }
    }
}
