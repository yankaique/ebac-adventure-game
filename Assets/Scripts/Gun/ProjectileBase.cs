using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{

    public float timeToDestroy = 2f;

    public int damageAmount = 1;
    public float speed = 50f;

    private void Awake()
    {
        Destroy(gameObject, timeToDestroy);    
    }
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var damageable = collision.transform.GetComponent<IDamageable>();

        if (damageable != null)
        {
            Vector3 dir = collision.transform.position - transform.position;
            dir = -dir.normalized;
            dir.y = 0;

            damageable.Damage(damageAmount);
            Destroy(gameObject);
        }

    }
}
