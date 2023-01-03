using UnityEngine;

namespace Narration.Dialogue.Data.Nodes
{
    public abstract class DialogueNode : ScriptableObject
    {
        [SerializeField] private NarrationLine m_DialaogueLine;

        public NarrationLine DialogueLine => m_DialaogueLine;

        public abstract bool CanBeFollowedByNode(DialogueNode node);

        public abstract void Accept(DialogueNodeVisitor visitor);
    }
}
