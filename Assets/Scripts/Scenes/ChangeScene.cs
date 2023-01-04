using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{
   public class ChangeScene : MonoBehaviour
   {
      [SerializeField] private string nombreEscena;
      bool _playerInRange;
      private void Awake()
      {
         _playerInRange = false;
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
            if (InputHandler.instance.input.interact)
            {
               if (!InputHandler.instance.input.interactHasBeenUsed)
               {
                  SceneManager.LoadScene(nombreEscena);
               }
            }
         }
      }
   }
}
