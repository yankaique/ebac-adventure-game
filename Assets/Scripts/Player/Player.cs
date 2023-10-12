using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;

    public CharacterController characterController;
    public float speed = 75f;
    public float turnSpeed = 80f;
    public float gravity = -9.8f;

    public float jumpSpeed = 15f;

    private float _vSpeed = 0f;
    void Update()
    {
        // adicionando rota��o ao personagem
        var inputAxisVertical = Input.GetAxis("Vertical");
        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);

        // Usando eixo vertical pra ir pra frente e pra tr�s
        var speedVector = transform.forward * inputAxisVertical * speed;

        if(Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
        {
            _vSpeed = jumpSpeed;
        }

        _vSpeed += gravity * Time.deltaTime;
        speedVector.y = _vSpeed;

        characterController.Move(speedVector * Time.deltaTime);

        animator.SetBool("Run", inputAxisVertical != 0);
    }
}
