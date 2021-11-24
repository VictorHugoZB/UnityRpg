using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Caractere
{
    public Inventario inventarioPrefab; // referência ao objeto prefab criado do inventário
    Inventario inventario;
    public HealthBar healthBarPrefab;   // referência ao objeto prefab criado da Health Bar
    HealthBar healthBar;

    public PontosDano pontosDano; // Tem valor do objeto de script

    private void Start(){
        inventario = Instantiate(inventarioPrefab);
        pontosDano.valor = inicioPontosDano;
        healthBar = Instantiate(healthBarPrefab);
        healthBar.caractere = this;
    }

    public override IEnumerator DanoCaractere(int dano, float intervalo)
    {
        while (true)
        {
            pontosDano.valor = pontosDano.valor - dano;
            print("dada");
            if(pontosDano.valor <= float.Epsilon)
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

    public override void KillCaractere()
    {
        base.KillCaractere();
        Destroy(healthBar.gameObject);
        Destroy(inventario.gameObject);
    }

    public override void ResetCaractere()
    {
        inventario = Instantiate(inventarioPrefab);
        healthBar = Instantiate(healthBarPrefab);
        healthBar.caractere = this;
        pontosDano.valor = inicioPontosDano;
    }

    
    /*
     * Esta é a função responsavel pelos itens coletáveis.
     * Caso o item seja um item consumivel, ele será diretamente usado.
     * Caso o item seja um item coletavel, sera chamada a função AddItem no inventario
     * para saber se é possivel coletar o item ou nao.
     */
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Coletavel")){
            Item DanoObjeto = collision.gameObject.GetComponent<Consumivel>().item;
            if (DanoObjeto != null){
                bool DeveDesaparecer = false;
                switch(DanoObjeto.tipoItem){
                    case Item.TipoItem.MOEDA:
                        DeveDesaparecer = inventario.AddItem(DanoObjeto);
                        break;
                    case Item.TipoItem.HEALTH:
                        DeveDesaparecer = AjustePontosDano(DanoObjeto.quantidade);
                        AjustePontosDano(DanoObjeto.quantidade);
                        break;
                    case Item.TipoItem.BAU:
                        if(inventario.podeColetarBau()) {
                            DeveDesaparecer = inventario.AddItem(DanoObjeto);
                        }
                        else
                        {
                            DeveDesaparecer = false;
                        }
                        break;
                    case Item.TipoItem.CHAVE:
                        DeveDesaparecer = inventario.AddItem(DanoObjeto);
                        break;
                    case Item.TipoItem.DIAMANTE:
                        DeveDesaparecer = inventario.AddItem(DanoObjeto);
                        break;
                    case Item.TipoItem.PERGAMINHO:
                        DeveDesaparecer = inventario.AddItem(DanoObjeto);
                        break;
                    default:
                        break;
                }
                if (DeveDesaparecer) {
                    collision.gameObject.SetActive(false);
                }
            }
        }
    }
    
    /*
     * Esta é a função responsavel pelo Ajuste dos pontos de saude do player.
     * Ela é chamada quando for pego o item consumivel que cura o player.
     */
    public bool AjustePontosDano(int quantidade){
        if (pontosDano.valor < MaxPontosDano){
            pontosDano.valor = pontosDano.valor + quantidade;
            return true;
        }
        return false;
    }
}
