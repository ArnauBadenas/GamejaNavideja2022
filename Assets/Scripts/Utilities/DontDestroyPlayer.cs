using UnityEngine;

namespace Utilities
{
    public class DontDestroyPlayer : MonoBehaviour
    {
        // Start is called before the first frame update
        void Awake()
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");
            if (objs.Length > 1)
            {
                Destroy(this.gameObject);
            }
            DontDestroyOnLoad(this.gameObject);
        }

    }
}
