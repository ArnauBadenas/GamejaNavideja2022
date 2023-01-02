using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _rotationSpeed;

    private Rigidbody2D _rigidbody;
    private Vector2 _movementInput;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;

    //On game start
    private void Awake(){
        //Set variables
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    //Every Frame
    private void FixedUpdate()
    {
        //Define smooth movement parameters
        //This function will make the speed increment increase smoothly.
        setPlayerVelocity();
        rotateInDirectionOfInput();
    }

    private void setPlayerVelocity()
    {
        _smoothedMovementInput = Vector2.SmoothDamp(
                    _smoothedMovementInput,
                    _movementInput,
                    ref _movementInputSmoothVelocity,
                    0.1f //Transition time
                );

        _rigidbody.velocity = _smoothedMovementInput * _speed;
    }

    private void rotateInDirectionOfInput(){
        if(_movementInput != Vector2.zero){
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _smoothedMovementInput);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

            _rigidbody.MoveRotation(rotation);
        }
    }

    private void OnMove(InputValue inputValue){
        //Get movement input from current vectors x and y
        _movementInput = inputValue.Get<Vector2>();
    }
}
