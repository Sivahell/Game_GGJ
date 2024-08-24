using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class MouseInputManager : MonoBehaviour
{
    public static MouseInputManager instance;
    private MouseInput mouseInput;
    private Coroutine mouseSlideCoro;
    public delegate void MosueEvent(Vector2 mousePos);
    public MosueEvent OnClick;
    public MosueEvent OnHold;
    public MosueEvent OnCancel;
    private void Awake()
    {
        instance = this;
        mouseInput = new();
        mouseInput.Mouse.Enable();
    }

    private void OnEnable()
    {
        mouseInput.Mouse.Click.performed += StartSlide;
        mouseInput.Mouse.Click.canceled += StopSlide;
    }

   

    private void OnDisable()
    {
        mouseInput.Mouse.Click.performed -= StartSlide;
        mouseInput.Mouse.Click.canceled -= StopSlide;
    }

    private void StartSlide(InputAction.CallbackContext obj)
    {
        OnClick.Invoke(MouseValue());
        if (mouseSlideCoro != null)
            StopCoroutine(mouseSlideCoro);
        mouseSlideCoro = StartCoroutine(MouseSlide());
        BladeControlDetecter.instance.CheckTouched(MouseValue());
    }
    private void StopSlide(InputAction.CallbackContext obj)
    {
        if (mouseSlideCoro != null)
            StopCoroutine(mouseSlideCoro);
        mouseSlideCoro = null;
        OnCancel.Invoke(MouseValue());
    }

    public Vector2 MouseValue()
    {
        return mouseInput.Mouse.Position.ReadValue<Vector2>();
    }

    private IEnumerator MouseSlide()
    {
        while(true)
        {
            OnHold.Invoke(MouseValue());
            yield return null;
        }
    }
}
