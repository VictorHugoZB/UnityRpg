using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// abstract indica que a classe não pode ser instanciada
public abstract class Caractere : MonoBehaviour
{
    public PontosDano pontosDano; // Tem valor do objeto de script
    public float inicioPontosDano;  // valor minimo inicial de saúde do player
    public float MaxPontosDano; // valor maximo de saúde do player
}
