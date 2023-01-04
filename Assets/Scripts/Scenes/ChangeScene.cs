using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{
   public class ChangeScene : MonoBehaviour
   {
      [SerializeField] private string nombreEscena;
      bool _playerInRange;
      [Header("Visual Cue")] [SerializeField]
      private GameObject visualCue;
      private void Awake()
      {
         _playerInRange = false;
         visualCue.SetActive(false);
      }
      private void OnTriggerEnter2D(Collider2D col)
      {
         if (col.gameObject.CompareTag("Player"))
         {
            _playerInRange = true;
         }
      }

      private void OnTriggerExit2D(Collider2D other)
      {
         if (other.gameObject.CompareTag("Player"))
         {
            _playerInRange = false;
         }
      }
      private void Update()
      {
         if (_playerInRange)
         {
            visualCue.SetActive(true);
            if (InputHandler.instance.input.interact)
            {
               if (!InputHandler.instance.input.interactHasBeenUsed)
               {
                  SceneManager.LoadScene(nombreEscena);
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
