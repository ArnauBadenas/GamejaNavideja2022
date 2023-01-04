using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{
   public class ChangeScene : MonoBehaviour
   {
      [SerializeField] private string nombreEscena;
      bool _playerInRange;
      private string escenaActual;
      private GameObject player;
      private void Awake()
      {
         escenaActual = SceneManager.GetActiveScene().name;
         _playerInRange = false;
         player = GameObject.FindGameObjectWithTag("Player");
      }
      private void SaveCurrentCoords(string sceneName)
      {
         PlayerPrefs.SetFloat(sceneName + "X", player.transform.position.x);
         PlayerPrefs.SetFloat(sceneName + "Y", player.transform.position.y);
         PlayerPrefs.SetFloat(sceneName + "Z", player.transform.position.z);
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
      private void FixedUpdate()
      {
         if (_playerInRange)
         {
            if (InputHandler.instance.input.interact)
            {
               if (!InputHandler.instance.input.interactHasBeenUsed)
               {
                  SaveCurrentCoords(escenaActual);
                  //Load scene
                  SceneManager.LoadScene(nombreEscena);
                  //Transport player into door position
                  
               }
            }
         }
      }
   }
}
