using System.IO.Pipes;
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
        if (InputHandler.instance.input.interact)
        {
            if (!InputHandler.instance.input.interactHasBeenUsed)
            {
                Interact();
            }

            InputHandler.instance.input.interactHasBeenUsed = true;
        }
        //Variables se hacen dentro de unity
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    //This happens when button is pressed
    private void Interact()
    {
        Debug.Log("interacted");
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

}
