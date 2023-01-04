using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{
    public class ChangeDespachoToPasillo : MonoBehaviour
    {
        // Start is called before the first frame update
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                SceneManager.LoadScene("Pasillo");
            }
        }
    }
}
