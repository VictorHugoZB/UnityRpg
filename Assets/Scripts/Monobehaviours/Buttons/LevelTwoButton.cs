using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Classe utilizada para controlar o bot�o para prosseguir para o n�vel 2
/// </summary>
public class LevelTwoButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* m�todo para prosseguir para o n�vel 2 quando apertado o bot�o */
    public void LoadLevelTwo()
    {
        SceneManager.LoadScene("Level 2");
    }
}
