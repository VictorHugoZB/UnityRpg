using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe utilizada para controlar o bot�o para sair do jogo
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

    /* m�todo para sair do jogo quando apertado o bot�o*/
    public void QuitGame()
    {
        Application.Quit();
    }
}
