using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Classe utilizada para controlar o botão para carregar a tela de créditos
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

    /* método para prosseguir carregar os créditos quando apertado o botão */
    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
