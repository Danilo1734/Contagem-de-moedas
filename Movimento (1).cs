using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Movimento : MonoBehaviour
{
    private CharacterController character;
    private Animator animator;
    private Vector3 inputs;

    private float velocidade = 2f;
    private float gravidade = -9.8f;
    private float forcaPulo = 5f;

    private float velocidadeY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        character = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputs.Set(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        character.Move(inputs * Time.deltaTime * velocidade);
        character.Move(Vector3.down * Time.deltaTime);

        if (inputs != Vector3.zero)
        {
            animator.SetBool("Walking", true);
            transform.forward = Vector3.Slerp(transform.forward, inputs, Time.deltaTime * 10);
        }
        else
        {
            animator.SetBool("Walking", false);
        }

        if (character.isGrounded)
        {
            if (velocidadeY < 0)
                velocidadeY = -2f;


            if (Input.GetButtonDown("Jump"))
            {
                velocidadeY = forcaPulo;
                animator.SetTrigger("Jumping");
            }
        }

        velocidadeY += gravidade * Time.deltaTime;

        Vector3 movimento = inputs * velocidade;
        movimento.y = velocidadeY;

        character.Move(movimento * Time.deltaTime);
    }
}
