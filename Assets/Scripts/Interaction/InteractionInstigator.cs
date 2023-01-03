using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Interaction
{
    public class InteractionInstigator : MonoBehaviour
    {
        private List<Interactable> m_NearbyInteractables = new List<Interactable>();

        public bool HasNearbyInteractables()
        {
            return m_NearbyInteractables.Count != 0;
        }
        
        private void Update()
        {
            if (HasNearbyInteractables())
            {
                //Ideally, we'd want to find the best possible interaction (ex: by distance & orientation).
                m_NearbyInteractables[0].DoInteraction();
                Debug.Log("Estoy aqui");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Interactable interactable = other.GetComponent<Interactable>();
            if (interactable != null)
            {
                m_NearbyInteractables.Add(interactable);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            Interactable interactable = other.GetComponent<Interactable>();
            if (interactable != null)
            {
                m_NearbyInteractables.Remove(interactable);
            }
        }
    }
}