using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Classe para definir como o player se movimenta: Controle, tipo de animação, velocidade
/// </summary>
public class MovimentoPlayer : MonoBehaviour
{
    public float VelocidadeMovimento = 3.0f;    // equivale ao momento (impulso) a ser dado para o player
    Vector2 Movimento = new Vector2();          // detectar movimento pelo teclado

    Animator animator;                          // guarda a componente do controlador de 
    Rigidbody2D rb2D;                           // guarda a componente corpo rígido do player

    enum EstadosCaractere{
        andaLeste = 1,
        andaOeste = 2,
        andaSul = 3,
        andaNorte = 4,
        idle = 5
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateEstado();
    }

    /* corrige animação do player */
    private void FixedUpdate(){
        MoveCaractere();
    }

    /* Faz o deslocamento do player pelo mapa */
    private void MoveCaractere(){
        Movimento.x = Input.GetAxisRaw("Horizontal");
        Movimento.y = Input.GetAxisRaw("Vertical");
        Movimento.Normalize();
        rb2D.velocity = Movimento * VelocidadeMovimento;
    }

    /* define parâmetros que serão utilizados na realização da animação */
    private void UpdateEstado(){
        if(Mathf.Approximately(Movimento.x, 0) && Mathf.Approximately(Movimento.y, 0))
        {
            animator.SetBool("Caminhando", false);
        }
        else
        {
            animator.SetBool("Caminhando", true);
        }
        animator.SetFloat("dirX", Movimento.x);
        animator.SetFloat("dirY", Movimento.y);
    }
}
