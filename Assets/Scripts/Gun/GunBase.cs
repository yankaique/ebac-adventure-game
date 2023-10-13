using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase prefabProjectile;
    public Transform positionToShoot;

    public float timeBetweenShoot = 1f;

    private Coroutine _currentCoroutine;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            _currentCoroutine = StartCoroutine(StartShoot());
        } else if (Input.GetKeyUp(KeyCode.R))
        {
            if(_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
            }
        }
    }

    IEnumerator StartShoot()
    {
        while(true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }

    public void Shoot()
    {
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionToShoot.position;
        projectile.transform.rotation = positionToShoot.rotation;
    }
}
