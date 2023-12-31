using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cloth;

public class HealthBase : MonoBehaviour, IDamageable
{
    public float startLife;
    public bool destroyOnKill = false;
    public float damageMultiply = 1f;

    [SerializeField] private float _currentLife;

    public List<UIGunUpdater> uIGunUpdater;

    public Action<HealthBase> OnDamage;
    public Action<HealthBase> OnKill;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        ResetLife();
    }

    public void ResetLife()
    {
        _currentLife = startLife;
        Updateui();
    }


    protected virtual void Kill()
    {
        if(destroyOnKill)
        {
            Destroy(gameObject, 3f);
        }
        OnKill?.Invoke(this);
    }

    public void Damage(float damage = 1)
    {
        _currentLife -= damage * damageMultiply;

        if (_currentLife <= 0)
        {
            Kill();
        }

        Updateui();
        OnDamage?.Invoke(this);
    }

    private void Updateui()
    {
        if(uIGunUpdater  != null)
        {
            uIGunUpdater.ForEach(i => i.UpdateValue((float)_currentLife / startLife));
        }
    }

    [NaughtyAttributes.Button]
    public void DebugDamage()
    {
        Damage(3.0f);
    }

    public void Damage(float damage, Vector3 direction)
    {
        Damage(damage);
    }

    public void ChangeDamageMultiply(float damage, float duration)
    {
        StartCoroutine(ChangeDamageMultiplyCoroutine(damage, duration));

    }

    IEnumerator ChangeDamageMultiplyCoroutine(float damageMultiply, float duration)
    {
        this.damageMultiply = damageMultiply;
        yield return new WaitForSeconds(duration);
        this.damageMultiply = 1;
    }
}
