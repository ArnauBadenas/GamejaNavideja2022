using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Player
{
    public class PauseHandler : MonoBehaviour
    {
        [Header("Canvas UI")]
        [SerializeField] private GameObject canvas;
        [Header("Button UI")]
        [SerializeField] private GameObject button;
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
                StartCoroutine(SelectFirstChoice());
            }
            else
            {
                canvas.SetActive(false);
                isActive = false;
            }
        }
        
        private IEnumerator SelectFirstChoice()
        {
            EventSystem.current.SetSelectedGameObject(null);
            yield return new WaitForEndOfFrame();
            EventSystem.current.SetSelectedGameObject(button.gameObject);
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
