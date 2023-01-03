using UnityEngine;
using UnityEngine.Events;

namespace Interaction
{
    public class Interactable : MonoBehaviour
    {
        [SerializeField]
        UnityEvent m_OnInteraction;

        public void DoInteraction()
        {
            m_OnInteraction.Invoke();
        }
    }
}