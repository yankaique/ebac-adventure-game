using System.Collections.Generic;
using UnityEngine;
using Camera;
using Ebac.core.Singleton;
using System.Collections;
using Cloth;


public class Player : Singleton<Player> //, IDamageable
{
    public List<Collider> colliders;
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

    [Space]
    [SerializeField] private ClothChanger _clothChanger;

    private bool _alive = true;

    protected override void Awake()
    {
        base.Awake();
        OnValidate();
        healthBase.OnDamage += Damage;
        healthBase.OnKill += OnKill;
    }

    private void OnValidate()
    {
        if(healthBase == null) healthBase = GetComponent<HealthBase>();
    }

    #region Life
    public void Damage(HealthBase h)
    {
        flashColors.ForEach(color => color.Flash());
        ShakeCamera.Instance.Shake(3f, 3f, 3f);
        EffectsManager.Instance.ChangeVignette();
    }

    public void Damage(float damage, Vector3 direction)
    {
        //Damage(damage);
    }
    #endregion

    private void OnKill(HealthBase h)
    {
        if(_alive)
        {
            _alive = false;
            animator.SetTrigger("Death");
            
            Invoke(nameof(Revive), 3f);
            Invoke(nameof(TurnOnColliders), 3f);
        }
    }

    private void TurnOnColliders()
    {
        colliders.ForEach(collider => collider.enabled = false);
    }

    private void Revive()
    {
        _alive = true;
        healthBase.ResetLife();
        animator.SetTrigger("Revive");
        colliders.ForEach(collider => collider.enabled = true);
        Respawn();
    }

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

    [NaughtyAttributes.Button]
    public void Respawn()
    {
        if (CheckPointManager.Instance.HasCheckPoint())
        {
            transform.position = CheckPointManager.Instance.GetPositionToRespawnPlayerFromLastCheckPoint();
        }
    }

    public void ChangeSpeed(float speed, float duration)
    {
        StartCoroutine(ChangeSpeedCoroutine(speed, duration));
    }


    IEnumerator ChangeSpeedCoroutine(float localSpeed, float duration)
    {
        var defaultSpedd = speed;
        speed = localSpeed;

        yield return new WaitForSeconds(duration);
        speed = defaultSpedd;
    }

    public void ChangeTexture(ClothSetup setup, float duration)
    {
        StartCoroutine(ChangeTextureCoroutine(setup, duration));

    }

    IEnumerator ChangeTextureCoroutine(ClothSetup setup, float duration)
    {
        _clothChanger.ChangeTexture(setup);
        yield return new WaitForSeconds(duration);
        _clothChanger.ResetTexture();
    }
}
