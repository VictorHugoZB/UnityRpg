using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe utilizada para definir a trajet�ria que o tiro do player ir� realizar.
/// </summary>
public class Arco : MonoBehaviour
{

    /* Define a trajet�ria que o tiro do player ir� realizar dado o ponto de destino
     * e o intervalo de tempo at� ele.
     */
    public IEnumerator arcoTrajetoria(Vector3 destino, float duracao)
    {
        var posicaoInicial = transform.position;
        var percentualCompleto = 0.0f;
        while (percentualCompleto < 1.0f)
        {
            percentualCompleto += Time.deltaTime / duracao;
            var alturaCorrente = Mathf.Sin(Mathf.PI * percentualCompleto);
            transform.position = Vector3.Lerp(posicaoInicial, destino, percentualCompleto) + Vector3.up*alturaCorrente;
            yield return null;
        }
        gameObject.SetActive(false);
    }
    
}
