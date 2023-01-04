using System.Collections;
using UnityEngine;

namespace Player
{
    public class PauseHandler : MonoBehaviour
    {
        [SerializeField] private GameObject canvas;
        private bool isActive;

        private void Awake()
        {
            canvas.SetActive(false);
            isActive = false;

        }

        private void Update()
        {
            if (InputHandler.instance.input.exit)
            {
                if (!InputHandler.instance.input.exitHasBeenUsed)
                {
                    PauseMenu();
                    StartCoroutine(wait());
                }
            }
        }

        public void PauseMenu()
        {
            if (!isActive)
            {
                canvas.SetActive(true);
                isActive = true;
            }
            else
            {
                canvas.SetActive(false);
                isActive = false;
            }
        }

        public void Exit()
        {
            Debug.Log("Saliendo");
            Application.Quit();
        }

        IEnumerator wait()
        {
            InputHandler.instance.input.exitHasBeenUsed = true;
            yield return new WaitForEndOfFrame();
        } 
    }
}
