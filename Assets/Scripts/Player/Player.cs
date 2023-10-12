using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 1f;
    public float turnSpeed = 1f;
    public float gravity = -9.8f;

    private float _vSpeed = 0f;
    void Update()
    {
        // adicionando rotação ao personagem
        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);

        // Usando eixo vertical pra ir pra frente e pra trás
        var speedVector = transform.forward * Input.GetAxis("Vertical") * speed;

        _vSpeed += gravity * Time.deltaTime;
        speedVector.y = _vSpeed;

        characterController.Move(speedVector * Time.deltaTime);
    }
}
