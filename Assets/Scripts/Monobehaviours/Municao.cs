using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Municao : MonoBehaviour
{
    public int danoCausado;


    public Coroutine ArcoTrajetoria;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.activeSelf && collision is BoxCollider2D && collision.gameObject.tag != "Player")
        {
            Inimigo inimigo = collision.gameObject.GetComponent<Inimigo>();
            StartCoroutine(inimigo.DanoCaractere(danoCausado, 0.0f));
            if (ArcoTrajetoria != null) StopCoroutine(ArcoTrajetoria);
            //gameObject.SetActive(false);

            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
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
