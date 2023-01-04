using System.Collections;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{
   public class ChangeScene : MonoBehaviour
   {
      [SerializeField] private string nombreEscena;
      bool _playerInRange;
      private string _escenaActual;
      private GameObject _player;
      private void Awake()
      {
         _escenaActual = SceneManager.GetActiveScene().name;
         _playerInRange = false;
         _player = GameObject.FindGameObjectWithTag("Player");
      }
      private void SaveCurrentCoords(string sceneName)
      {
         var position = _player.transform.position;
         PlayerPrefs.SetFloat(sceneName + "X", position.x);
         PlayerPrefs.SetFloat(sceneName + "Y", position.y);
         PlayerPrefs.SetFloat(sceneName + "Z", position.z);
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
         if (!_playerInRange) return;
         if (!InputHandler.instance.input.interact) return;
         if (InputHandler.instance.input.interactHasBeenUsed) return;
         SaveCurrentCoords(_escenaActual);
         InputHandler.instance.input.interactHasBeenUsed = true;
         //Load scene
         SceneManager.LoadScene(nombreEscena);
      }
   }
}
