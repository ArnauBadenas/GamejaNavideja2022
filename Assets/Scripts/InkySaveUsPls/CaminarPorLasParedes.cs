using System.Collections;
using Player;
using UnityEngine;

namespace InkySaveUsPls
{
    public class CaminarPorLasParedes : MonoBehaviour
    {
        [Header("RigidBody")]
        [SerializeField] Rigidbody2D rbPlayer;
        private bool playerInRange;
        private bool freeze;
    
        private void Awake()
        {
            playerInRange = false;
            freeze = true;
            rbPlayer.GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (InputHandler.instance.input.interact)
            {
                if (!InputHandler.instance.input.interactHasBeenUsed)
                {
                    ChangeRotationState();
                    StartCoroutine(wait());
                }
            }
        }

        public void ChangeRotationState()
        {
            if (playerInRange)
            {
                Debug.Log("Rotar");
                if (freeze)
                {
                    rbPlayer.isKinematic = true;
                    rbPlayer.constraints = RigidbodyConstraints2D.None;
                }
                else
                {
                    rbPlayer.isKinematic = false;
                    rbPlayer.constraints = RigidbodyConstraints2D.FreezeRotation;
                }
            }
        }
    
        IEnumerator wait()
        {
            InputHandler.instance.input.interactHasBeenUsed = true;
            yield return new WaitForEndOfFrame();
        }
    
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.tag == "Player")
            {
                playerInRange = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                playerInRange = false;
            }
        }
    }
}
