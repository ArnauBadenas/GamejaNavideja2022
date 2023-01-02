using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerInteraction : MonoBehaviour
{
    private void Update(){
        if(action.Interact.IsPressed()){
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach(Collider collider in colliderArray){
                Debug.Log(collider);
            }
        }
    }
}
