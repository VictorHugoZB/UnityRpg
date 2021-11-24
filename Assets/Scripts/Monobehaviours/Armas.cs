using System;
using System.Collections.Generic;
using UnityEngine;

public class Armas : MonoBehaviour
{
    public GameObject municaoPrefab;            // armazena o prefab da Municao
    static List<GameObject> municaoPiscina;     // Pool de munição
    public int tamanhoPiscina;                  // Tamanho da Piscina
    public float velocidadeArma;                // velocidade da Municao

    private void Awake()
    {
        if(municaoPiscina == null)
        {
            municaoPiscina = new List<GameObject>();
        }
        for (int i = 0; i < tamanhoPiscina; i++)
        {
            GameObject municaoO = Instantiate(municaoPrefab);
            municaoO.SetActive(false);
            municaoPiscina.Add(municaoO);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DisparaMunicao();
        }
    }

    void DisparaMunicao()
    {
        Vector3 posicaoMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject municao = SpawnMunicao(transform.position);
        if(municao != null){
            Arco arcoScript = municao.GetComponent<Arco>();
            float duracaoTrajetoria = 1.0f / velocidadeArma;
            StartCoroutine(arcoScript.arcoTrajetoria(posicaoMouse, duracaoTrajetoria));
        }
    }

    GameObject SpawnMunicao(Vector3 posicao)
    {
        foreach (GameObject municao in municaoPiscina)
        {
            if(municao.activeSelf == false)
            {
                municao.SetActive(true);
                municao.transform.position = posicao;
                return municao;
            }
        }
        return null;
    }

    private void OnDestroy()
    {
        municaoPiscina = null;
    }
}
