using Ink.Runtime;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InkySaveUsPls
{
    public class DialogueManager : MonoBehaviour
    {
        [Header("Dialogue UI")] [SerializeField]
        private GameObject dialoguePanel;

        [SerializeField] private TextMeshProUGUI dialogueText;

        private Story currentStory;
        private bool dialogueIsPlaying;
        public static DialogueManager instance;

        private void Awake()
        {
            if (instance != null)
            {
                Debug.LogWarning("Found more than one Dialogue Manager in the scene");
            }

            instance = this;
        }

        private void Start()
        {
            dialogueIsPlaying = false;
            dialoguePanel.SetActive(false);
        }

        public void EnterDialogueMode(TextAsset inkJSON)
        {
            if (!dialogueIsPlaying)
            {
                currentStory = new Story(inkJSON.text);
                dialogueIsPlaying = true;
                dialoguePanel.SetActive(true);
            }
            
            ContinueStory();
        }

        private void ExitDialogueMode()
        {
            dialogueIsPlaying = false;
            dialoguePanel.SetActive(true);
            dialogueText.text = "";
        }

        public void ContinueStory()
        {
            if (currentStory.canContinue)
            {
                dialogueText.text = currentStory.Continue();
            }
            else
            {
                ExitDialogueMode();
            }
        }
    }
}
