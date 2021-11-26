using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe filha de caractere, pois todo inimigo é um caractere.
/// Implementa métodos relacionados a colisão e pontos de dano do inimigo
/// </summary>
public class Inimigo : Caractere
{
    float pontosVida;           // equivalente a saude do inimigo
    public int forcaDano;       // poder de dano

    Coroutine danoCoroutine;

    private void OnEnable()
    {
        ResetCaractere();
    }

    /* Checa se a colisão do inimigo foi com o player, e retira vida do player se for o caso.
     * Inicia a rotina de dano. */
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            
            Player player = collision.gameObject.GetComponent<Player>();
            if (danoCoroutine == null)
            {
                
                danoCoroutine = StartCoroutine(player.DanoCaractere(forcaDano, 1.0f));
            }
        }
    }

    /* Para a rotina de dano após o inimigo sair da colisão com o player */
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(danoCoroutine != null)
            {
                StopCoroutine(danoCoroutine);
                danoCoroutine = null;
            }
        }
    }

    /* Realiza processos relacionados ao dano do inimigo: piscar em vermelho, perca de vida e intervalo
     * até tomar dano novamente 
     */
    public override IEnumerator DanoCaractere(int dano, float intervalo)
    {
        while (true)
        {
            StartCoroutine(FlickerCaractere());
            pontosVida -= dano;

            somPlayer.PlayOneShot(somPlayer.clip);

            print(dano);
            if (pontosVida <= float.Epsilon)
            {
                KillCaractere();
                break;
            }
            if(intervalo > float.Epsilon)
            {
                yield return new WaitForSeconds(intervalo);
            }
            else
            {
                break;
            }
        }
    }

    /* Reinicializa a vida di caractere */
    public override void ResetCaractere()
    {
        pontosVida = inicioPontosDano;
    }

    // Start is called before the first frame update
    void Start()
    {
        somPlayer = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
