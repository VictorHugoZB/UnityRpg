using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : Caractere
{
    float pontosVida;           // equivalente a saude do inimigo
    public int forcaDano;       // poder de dano

    Coroutine danoCoroutine;

    private void OnEnable()
    {
        ResetCaractere();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        print("Colide");
        if (collision.gameObject.CompareTag("Player"))
        {
            print("Player acho");
            Player player = collision.gameObject.GetComponent<Player>();
            if (danoCoroutine == null)
            {
                print("COroutine nula");
                danoCoroutine = StartCoroutine(player.DanoCaractere(forcaDano, 1.0f));
            }
        }
    }

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

    public override IEnumerator DanoCaractere(int dano, float intervalo)
    {
        while (true)
        {
            StartCoroutine(FlickerCaractere());
            pontosVida -= dano;
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

    public override void ResetCaractere()
    {
        pontosVida = inicioPontosDano;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
