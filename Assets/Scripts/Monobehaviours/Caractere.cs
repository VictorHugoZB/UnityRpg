using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe que define informações essenciais de qualquer caracter no jogo,
/// seja player ou inimigo.
/// </summary>
public abstract class Caractere : MonoBehaviour
{

    public float inicioPontosDano;  // valor minimo inicial de saúde do player
    public float MaxPontosDano; // valor maximo de saúde do player

    public AudioClip hitSom;        // Som que toca ao perder vida
    public AudioSource somPlayer;          // Referencia ao AudioSource

    public abstract void ResetCaractere();

    /* Faz o efeito de dano no caractere, mudando a sua cor ao perder vida */
    public virtual IEnumerator FlickerCaractere()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    
    /* Método implementado nas classes filhas, define o dano causado em um caractere
       e verifica se ele morreu. Define o tempo até ele poder tomar dano novamente. */
    public abstract IEnumerator DanoCaractere(int dano, float intervalo);

    /* Remove a instancia do caractere quando ele morre */
    public virtual void KillCaractere()
    {
        Destroy(gameObject);
    }
}
