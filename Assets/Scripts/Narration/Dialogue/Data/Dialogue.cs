using Narration.Dialogue.Data.Nodes;
using UnityEngine;

namespace Dialogue
{
    [CreateAssetMenu(menuName = "Scriptable Object/Narration/Line")]
    public class Dialogue : ScriptableObject
    {
        [SerializeField] private DialogueNode m_FirstNode;
        public DialogueNode FirstNode => m_FirstNode;
    }
}
