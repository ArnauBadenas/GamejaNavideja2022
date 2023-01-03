using Narration.Dialogue.Data.Nodes;
using UnityEngine;

namespace Narration.Dialogue
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Narration/Dialogue/Dialogue Channel")]
    public class DialogueChannel : ScriptableObject
    {
        public delegate void DialogueCallback(global::Dialogue.Dialogue dialogue);
        public DialogueCallback OnDialogueRequested;
        public DialogueCallback OnDialogueStart;
        public DialogueCallback OnDialogueEnd;

        public delegate void DialogueNodeCallback(DialogueNode node);
        public DialogueNodeCallback OnDialogueNodeRequested;
        public DialogueNodeCallback OnDialogueNodeStart;
        public DialogueNodeCallback OnDialogueNodeEnd;

        public void RaiseRequestDialogue(global::Dialogue.Dialogue dialogue)
        {
            OnDialogueRequested?.Invoke(dialogue);
        }

        public void RaiseDialogueStart(global::Dialogue.Dialogue dialogue)
        {
            OnDialogueStart?.Invoke(dialogue);
        }

        public void RaiseDialogueEnd(global::Dialogue.Dialogue dialogue)
        {
            OnDialogueEnd?.Invoke(dialogue);
        }

        public void RaiseRequestDialogueNode(DialogueNode node)
        {
            OnDialogueNodeRequested?.Invoke(node);
        }

        public void RaiseDialogueNodeStart(DialogueNode node)
        {
            OnDialogueNodeStart?.Invoke(node);
        }

        public void RaiseDialogueNodeEnd(DialogueNode node)
        {
            OnDialogueNodeEnd?.Invoke(node);
        }
    }
}