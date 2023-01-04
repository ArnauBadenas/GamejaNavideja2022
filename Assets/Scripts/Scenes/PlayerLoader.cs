using System;
using System.Collections;
using Player;
using Unity.VisualScripting;
using UnityEngine;
namespace Scenes
{
    public class PlayerLoader : MonoBehaviour
    {
        [SerializeField]
        Transform[] startingPositions;

        [SerializeField] private string nombreEscena;
        
        private Transform _lastPosition;
        private GameObject player;

        private void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (startingPositions.Length == 1)
            {
                player.transform.position = startingPositions[0].position;
            }
            else
            {
                if (PlayerPrefs.GetFloat(nombreEscena + "X") != 0.0f)
                {
                    LoadCurrentCoords(nombreEscena);
                }
                else
                {
                    player.transform.position = startingPositions[0].position;
                }
            }
        }
        private void LoadCurrentCoords(string sceneName)
        {
            player.transform.position = new Vector3(PlayerPrefs.GetFloat(sceneName + "X"), PlayerPrefs.GetFloat(sceneName + "Y"), PlayerPrefs.GetFloat(sceneName + "Z"));
        }
        
    }
    
}