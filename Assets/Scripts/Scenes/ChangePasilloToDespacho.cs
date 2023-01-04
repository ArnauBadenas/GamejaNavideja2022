using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{
   public class ChangePasilloToDespacho : MonoBehaviour
   {
      private void OnTriggerEnter2D(Collider2D col)
      {
         if (col.CompareTag("Player"))
         {
            SceneManager.LoadScene("Despacho");
         }
      }
   }
}
