using Narration.Dialogue.Data.Nodes;

namespace Narration.Dialogue.Data
{
    public interface DialogueNodeVisitor
    {
        void Visit(BasicDialogueNode node);

        void Visit(ChoiceDialogueNode node);
    }
}
