using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public static event Action OnTap;
    private UserInput userInput;
    private void Awake()
    {
        userInput = new UserInput();
        userInput.Enable();
        
    }

    private void Start()
    {
        userInput.MobileTouch.Tap.performed += OnTapPerformed;
    }

    private void OnTapPerformed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        OnTap?.Invoke();
    }

    private void OnDestroy()
    {
        userInput.MobileTouch.Tap.performed -= OnTapPerformed;
    }

}
