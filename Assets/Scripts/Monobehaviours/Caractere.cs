using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// abstract indica que a classe não pode ser instanciada
public abstract class Caractere : MonoBehaviour
{

    public float inicioPontosDano;  // valor minimo inicial de saúde do player
    public float MaxPontosDano; // valor maximo de saúde do player

    public abstract void ResetCaractere();

    public abstract IEnumerator DanoCaractere(int dano, float intervalo);

    public virtual void KillCaractere()
    {
        Destroy(gameObject);
    }
}
