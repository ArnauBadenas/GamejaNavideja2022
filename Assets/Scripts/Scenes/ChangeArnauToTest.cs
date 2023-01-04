using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{
   public class ChangeArnauToTest : MonoBehaviour
   {
      private void OnTriggerEnter2D(Collider2D col)
      {
         if (col.CompareTag("Player") && InputHandler.instance.input.interactHasBeenUsed)
         {
            SceneManager.LoadScene("Test");
         }
      }
   }
}
