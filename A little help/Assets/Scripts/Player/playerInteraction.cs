using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerInteraction : MonoBehaviour
{
    /*Script related to player interaction ONLY*/
    private static playerInteraction instance;
    private bool interactPressed = false;

    private void Awake()
    {
        //Detect inputmanager
        if (instance != null)
        {
            Debug.LogError("Found more than one Input Manager in the scene.");
        }
        instance = this;
    }

    public static playerInteraction GetInstance(){
        return instance;
    }

    public void InteractButtonPressed(InputAction.CallbackContext context){
        if (context.performed)
        {
            interactPressed = true;
        }
        else if (context.canceled)
        {
            interactPressed = false;
        }
    }

    public bool GetInteractPressed() {
        bool result = interactPressed;
        interactPressed = false;
        return result;
    }

}
