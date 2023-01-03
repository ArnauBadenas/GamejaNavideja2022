using System;
using System.Collections;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InkySaveUsPls
{
    public class DialogueTrigger  : MonoBehaviour
    {
        [Header("Visual Cue")] [SerializeField]
        private GameObject visualCue;
        
        [Header("Ink JSON")] [SerializeField]
        private TextAsset inkJSON;
        
        private bool playerInRange;

        public bool isPlayerInRange()
        {
            return playerInRange;
        }

        private string getInfo()
        {
            return inkJSON.text;
        }

        private void Awake()
        {
            playerInRange = false;
            visualCue.SetActive(false);
        }

        private void Update()
        {
            if (playerInRange)
            {
                visualCue.SetActive(true);
                if (InputHandler.instance.input.interact)
                {
                    Debug.Log("Interact");
                    if (!InputHandler.instance.input.interactHasBeenUsed)
                    {
                        Interact();
                    }
                }
            }
            else
            {
                visualCue.SetActive(false);
            }
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
        
        private void Interact()
        {
            DialogueManager.instance.EnterDialogueMode(inkJSON);
            StartCoroutine(wait());
        }
    
        IEnumerator wait()
        {
            InputHandler.instance.input.interactHasBeenUsed = true;
            yield return new WaitForSeconds(.2f);
        }
    }
}