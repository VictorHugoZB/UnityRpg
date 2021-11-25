using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Classe utilizada para controlar o botão ir para a próxima tela de créditos
/// </summary>
public class CreditsNextButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* método para ir para a próxima tela de créditos quando apertado o botão*/
    public void NextCreditsScreen()
    {
        SceneManager.LoadScene("Credits_2");
    }
}
