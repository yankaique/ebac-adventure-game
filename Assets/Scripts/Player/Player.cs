using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour //, IDamageable
{
    public Animator animator;

    public CharacterController characterController;
    public float speed = 75f;
    public float turnSpeed = 80f;
    public float gravity = 9.8f;

    public float jumpSpeed = 15f;

    [Header("Run")]
    public KeyCode KeyRun = KeyCode.LeftShift;
    public float speedRun = 1.5f;

    private float _vSpeed = 0f;

    [Header("Flash")]
    public List<FlashColor> flashColors;

    [Header("Health")]
    public HealthBase healthBase;

    private void Awake()
    {
        OnValidate();
        healthBase.OnDamage += Damage;
    }

    private void OnValidate()
    {
        if(healthBase == null) healthBase = GetComponent<HealthBase>();
    }

    #region Life
    public void Damage(HealthBase h)
    {
        flashColors.ForEach(color => color.Flash());
    }

    public void Damage(float damage, Vector3 direction)
    {
        //Damage(damage);
    }
    #endregion

    void Update()
    {
        // adicionando rotação ao personagem
        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);

        var inputAxisVertical = Input.GetAxis("Vertical");
        // Usando eixo vertical pra ir pra frente e pra trás
        var speedVector = transform.forward * inputAxisVertical * speed;

        if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
        {
            _vSpeed = jumpSpeed;
        }
        var isWalking = inputAxisVertical != 0;

        if (isWalking && Input.GetKeyDown(KeyRun))
        {
            speedVector *= speedRun;
            animator.speed = speedRun;
        } else
        {
            animator.speed = 1;

        }


        _vSpeed -= gravity * Time.deltaTime;
        speedVector.y = _vSpeed;

        characterController.Move(speedVector * Time.deltaTime);

        animator.SetBool("Run", isWalking);
    }
}
