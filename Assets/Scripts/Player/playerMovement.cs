using System.Collections;
using System.Collections.Generic;
using InkySaveUsPls;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    public Animator animator;
    float inputHorizontal;
    float inputVertical;

    [SerializeField]
    public float moveSpeed = 5f;

    private Rigidbody2D rb;

    Vector2 movement;

    //On game start
    private void Awake(){
        //Set variables
        rb = GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = InputHandler.instance.input.movement.x;
        movement.y = InputHandler.instance.input.movement.y;
        
        //Variables se hacen dentro de unity
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        if (DialogueManager.instance.dialogueIsPlaying)
        {
            rb.isKinematic = true;
        }
        else
        {
            rb.isKinematic = false;
            rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
        }
    }

}
