using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Caractere
{
    public Inventario inventarioPrefab; // referência ao objeto prefab criado do inventário
    Inventario inventario;
    public HealthBar healthBarPrefab;   // referência ao objeto prefab criado da Health Bar
    HealthBar healthBar;

    private void Start(){
        inventario = Instantiate(inventarioPrefab);
        pontosDano.valor = inicioPontosDano;
        healthBar = Instantiate(healthBarPrefab);
        healthBar.caractere = this;
    }

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
                    default:
                        break;
                }
                if (DeveDesaparecer) {
                    collision.gameObject.SetActive(false);
                }
            }
        }
    }

    public bool AjustePontosDano(int quantidade){
        if (pontosDano.valor < MaxPontosDano){
            pontosDano.valor = pontosDano.valor + quantidade;
            return true;
        }
        return false;
    }
}
