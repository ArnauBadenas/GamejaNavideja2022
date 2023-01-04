using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    // Start is called before the first frame update
    public void Play()
    {
        Debug.Log("jugar");
        SceneManager.LoadScene("Despacho");
    }

    // Update is called once per frame
    public void Salir()
    {
        Debug.Log("cerrar juego");
        Application.Quit();
    }
}
