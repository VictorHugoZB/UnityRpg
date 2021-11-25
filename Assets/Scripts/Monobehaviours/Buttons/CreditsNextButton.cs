using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Classe utilizada para controlar o bot�o ir para a pr�xima tela de cr�ditos
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

    /* m�todo para ir para a pr�xima tela de cr�ditos quando apertado o bot�o*/
    public void NextCreditsScreen()
    {
        SceneManager.LoadScene("Credits_2");
    }
}
