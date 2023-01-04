using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{
   public class ChangeArnauToTest : MonoBehaviour
   { 
      bool playerInRange;
      [Header("Visual Cue")] [SerializeField]
      private GameObject visualCue;
      private void Awake()
      {
         playerInRange = false;
         visualCue.SetActive(false);
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
                  SceneManager.LoadScene("Test");
               }
            }
         }
         else
         {
            visualCue.SetActive(false);
         }
      }
   }
}
