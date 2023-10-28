using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public float startLife;
    public bool destroyOnKill = false;
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

    public void Damage(float damage)
    {
        _currentLife -= damage;

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
}
