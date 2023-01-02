using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{   
    //Components
    Rigidbody2D rb;

    //Player
    float walkSpeed = 4f;
    float speedLimiter = 0.7f;
    float inputHorizontal;
    float inputVertical;

    void Start(){
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update(){
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate(){
        //Check if direction input is pressed
        if(inputHorizontal != 0 ||inputVertical != 0){
            //Check if both direction inputs are pressed at the same time (diagonal movement)
            if (inputHorizontal != 0 && inputVertical != 0){
                inputHorizontal *= speedLimiter;
                inputVertical *= speedLimiter;
            }
            rb.velocity = new Vector2(inputHorizontal * walkSpeed, inputVertical * walkSpeed);
        }else {
            rb.velocity = new Vector2(0f, 0f);
        }
    }
}
