using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Classe utilizada para controlar o botão para restartar o jogo
/// </summary>
public class RestartButton: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* método para dar restart no jogo quando apertado o botão*/
    public void RestartGame()
    {
        SceneManager.LoadScene("Lab5_RPG1_setup");
    }
}
