using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace InkySaveUsPls
{
    public class DialogueManager : MonoBehaviour
    {
        [Header("Dialogue UI")] [SerializeField]
        private GameObject dialoguePanel;

        [SerializeField] private TextMeshProUGUI dialogueText;
        [Header("Dialogue UI")] [SerializeField]
        private GameObject[] choices;
        private TextMeshProUGUI[] choicesText;
        
        private Story currentStory;
        public bool dialogueIsPlaying { get; private set; }
        public static DialogueManager instance;

        private const string SPEAKER_TAG = "speaker";
        private const string PORTRAIT_TAG = "portrait";
        private const string LAYOUT_TAG = "layout";

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
            
            // get all of the choices text 
            choicesText = new TextMeshProUGUI[choices.Length];
            int index = 0;
            foreach (GameObject choice in choices)
            {
                choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
                index++;
            }
        }

        public void EnterDialogueMode(TextAsset inkJSON)
        {
            if (!dialogueIsPlaying)
            {
                currentStory = new Story(inkJSON.text);
                dialogueIsPlaying = true;
                dialoguePanel.SetActive(true);
            }

            if (currentStory.currentChoices.Count == 0)
            {
                ContinueStory();
            }
        }

        private IEnumerator ExitDialogueMode() 
        {
            yield return new WaitForSeconds(0.2f);

            dialogueIsPlaying = false;
            dialoguePanel.SetActive(false);
            dialogueText.text = "";
        }

        public void ContinueStory()
        {
            if (currentStory.canContinue)
            {
                dialogueText.text = currentStory.Continue();
                DisplayChoices();
                HandleTags(currentStory.currentTags);
            }
            else
            {
                StartCoroutine(ExitDialogueMode());
            }
        }

        private void HandleTags(List<string> currentTags)
        {
            // Loopp through each tag and handle it accordingly
            foreach (string tag in currentTags)
            {
                string[] splitTag = tag.Split(':');
                if (splitTag.Length != 2)
                {
                    Debug.LogError("Tag could not be appropiately parsed: " + tag);
                }

                string tagKey = splitTag[0].Trim();
            }
        }

        private void DisplayChoices()
        {
            List<Choice> currentChoices = currentStory.currentChoices;

            if (currentChoices.Count > choices.Length)
            {
                Debug.LogError("More choices were given than the UI can support. Number of choices given: " + currentChoices.Count);
            }

            int index = 0;
            // enable and initialize the choices up to the amount of choices for this line of dialogue
            foreach (Choice choice in currentChoices)
            {
                choices[index].gameObject.SetActive(true);
                choicesText[index].text = choice.text;
                index++;
            }
            // go through the remaining choices the UI supports and make sure they're hidden
            for (int i = index; i < choices.Length; i++)
            {
                choices[i].gameObject.SetActive(false);
            }

            StartCoroutine(SelectFirstChoice());
        }

        private IEnumerator SelectFirstChoice()
        {
            EventSystem.current.SetSelectedGameObject(null);
            yield return new WaitForEndOfFrame();
            EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
        }

        public void MakeChoice(int choiceIndex)
        {
            if (InputHandler.instance.input.interact)
            {
                Debug.Log("Interact");
                if (!InputHandler.instance.input.interactHasBeenUsed)
                {
                    Interact(choiceIndex);
                }
            }
            ContinueStory();
        }
        
        private void Interact(int choiceIndex)
        {
            currentStory.ChooseChoiceIndex(choiceIndex);
            StartCoroutine(wait());
        }
    
        IEnumerator wait()
        {
            InputHandler.instance.input.interactHasBeenUsed = true;
            yield return new WaitForEndOfFrame();
        }
    }
}
