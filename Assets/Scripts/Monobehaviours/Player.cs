using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Essa classe define o player. É classe filha da classe Caractere, assim como inimigo.
/// </summary>
public class Player : Caractere
{
    public Inventario inventarioPrefab; // referência ao objeto prefab criado do inventário
    Inventario inventario;
    public HealthBar healthBarPrefab;   // referência ao objeto prefab criado da Health Bar
    HealthBar healthBar;

    public PontosDano pontosDano; // Tem valor do objeto de script

    public AudioSource ColetarSom;     // Som que toca ao coletar

    /* carrega o som de item coletado */
    private void Awake()
    {
        ColetarSom = gameObject.AddComponent<AudioSource>();
        ColetarSom.clip = Resources.Load<AudioClip>("Sons/Collect");
    }

    /* faz as instancias / inicializações necessarias */
    private void Start(){
        inventario = Instantiate(inventarioPrefab);
        pontosDano.valor = inicioPontosDano;
        healthBar = Instantiate(healthBarPrefab);
        healthBar.caractere = this;

        
        somPlayer = gameObject.GetComponent<AudioSource>();
        
    }

    /* Esse método tem as intruções de dano do jogador: piscar em vermelho, tempo de invencibilidade,
     * além de checar se ele morreu ou não */
    public override IEnumerator DanoCaractere(int dano, float intervalo)
    {
        while (true)
        {
            StartCoroutine(FlickerCaractere());
            pontosDano.valor = pontosDano.valor - dano;

            somPlayer.PlayOneShot(somPlayer.clip); // Som de hit ao tomar dano

            if(pontosDano.valor <= float.Epsilon)
            {
                KillCaractere();
                SceneManager.LoadScene("GameOver"); // Player morreu, carrega cena de GameOver
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

    /* Método para matar (destruir a instancia) do jogador e de seus itens relacionados */
    public override void KillCaractere()
    {
        base.KillCaractere();
        Destroy(healthBar.gameObject);
        Destroy(inventario.gameObject);
    }

    /* Reinicializa o player */
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
                        if(inventario.podeColetarBau())
                        {
                            inventario.consomeChave();
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
                    ColetarSom.Play();
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
