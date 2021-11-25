using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Classe utilizada para controlar o bot�o para carregar a tela de cr�ditos
/// </summary>
public class CreditButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* m�todo para prosseguir carregar os cr�ditos quando apertado o bot�o */
    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
