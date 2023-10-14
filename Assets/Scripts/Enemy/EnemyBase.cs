using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public float startLife;

    private float _currentLife;

    private void Awake()
    {
        
    }

    protected void ResetLife()
    {
        _currentLife = startLife;
    }

    protected virtual void Init()
    {
        ResetLife();
    }

    protected virtual void Kill()
    {
        OnKill();
    }

    protected virtual void OnKill()
    {
        Destroy(gameObject);
    }

    public void OnDamage(float damage)
    {
        _currentLife -= damage;

        if(_currentLife <= 0 )
        {
            Kill();
        }
    }
}
