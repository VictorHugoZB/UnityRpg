using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// classe criada para gerenciar o jogo, como por exemplo, fazer o spawn do player.
/// </summary>
public class RPGGameManager : MonoBehaviour
{
    public static RPGGameManager instanciaCompartilhada = null;
    public RPGCameraManager cameraManager;

    public PontoSpawn playerPontoSpawn;

    /* cria uma instância compartilhada dessa classe quando o script é carregado */
    private void Awake()
    {
        if(instanciaCompartilhada != null && instanciaCompartilhada != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instanciaCompartilhada = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SetupScene();
    }

    private void SetupScene()
    {
        SpawnPlayer();
    }

    /* Faz o spawn do player e configura a camera para segui-lo */ 
    public void SpawnPlayer()
    {
        if(playerPontoSpawn != null)
        {
            GameObject player = playerPontoSpawn.SpawnO();
            
            cameraManager.virtualCamera.Follow = player.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfItemsCollected();
    }

    /* Checa se todos os items colecionaveis já foram coletados pelo player (exceto os corações).
     * Caso positivo, carrega a cena de conclusão do nivel
     */
    public void CheckIfItemsCollected()
    {
        bool changeScene = true;                                                        // booleano para auxiliar se a cena deve ser mudada
        GameObject[] colecionaveis = GameObject.FindGameObjectsWithTag("Coletavel");    // lista de objetos restantes para colecionar

        foreach (GameObject colecionavel in colecionaveis)  // Para cada colecionavel que ainda resta, verifica se é do tipo HEALTH ou não.
        {                                                   // Caso algum não seja, não mudar de cena.
            if (colecionavel.gameObject.GetComponent<Consumivel>().item.tipoItem != Item.TipoItem.HEALTH)
                changeScene = false;    
        }

        
        if (changeScene) // Para mudar de cena, devemos saber em qual nível estamos.
        {
            if (SceneManager.GetActiveScene().name == "Lab5_RPG1_setup")
                SceneManager.LoadScene("LevelComplete");
            else if (SceneManager.GetActiveScene().name == "Level 2")
                SceneManager.LoadScene("Vitoria");
        }
    }
}
