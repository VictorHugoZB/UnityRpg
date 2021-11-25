using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Classe utilizada para controlar o botão para prosseguir para o nível 2
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

    /* método para prosseguir para o nível 2 quando apertado o botão */
    public void LoadLevelTwo()
    {
        SceneManager.LoadScene("Level 2");
    }
}
