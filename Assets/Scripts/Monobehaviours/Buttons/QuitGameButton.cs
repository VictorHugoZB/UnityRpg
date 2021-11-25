using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe utilizada para controlar o botão para sair do jogo
/// </summary>
public class QuitGameButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* método para sair do jogo quando apertado o botão*/
    public void QuitGame()
    {
        Application.Quit();
    }
}
