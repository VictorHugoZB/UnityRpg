using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPlayer : MonoBehaviour
{
    public float VelocidadeMovimento = 3.0f;    // equivale ao momento (impulso) a ser dado para o player
    Vector2 Movimento = new Vector2();          // detectar movimento pelo teclado

    Animator animator;                          // guarda a componente do controlador de animação
    string estadoAnimacao = "EstadoAnimacao";   // guarda o nome do parâmetro de animação
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

    private void FixedUpdate(){
        MoveCaractere();
    }

    private void MoveCaractere(){
        Movimento.x = Input.GetAxisRaw("Horizontal");
        Movimento.y = Input.GetAxisRaw("Vertical");
        Movimento.Normalize();
        rb2D.velocity = Movimento * VelocidadeMovimento;
    }

    private void UpdateEstado(){
        if (Movimento.x > 0){
            animator.SetInteger(estadoAnimacao, (int)EstadosCaractere.andaLeste);
        } else if (Movimento.x < 0) {
            animator.SetInteger(estadoAnimacao, (int)EstadosCaractere.andaOeste);
        } else if (Movimento.y > 0) {
            animator.SetInteger(estadoAnimacao, (int)EstadosCaractere.andaNorte);
        } else if (Movimento.y < 0) {
            animator.SetInteger(estadoAnimacao, (int)EstadosCaractere.andaSul);
        } else {
            animator.SetInteger(estadoAnimacao, (int)EstadosCaractere.idle);
        }
    }
}