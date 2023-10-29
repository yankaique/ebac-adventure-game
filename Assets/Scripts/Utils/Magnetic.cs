using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnetic : MonoBehaviour
{
    public float dist = .2f;
    public float coinSpeed = 3f;

    public void Update()
    {
        var playerPosition = Player.Instance.transform.position;
        var coinPosition = transform.position;
        if(Vector3.Distance(coinPosition, playerPosition) > dist)
        {
            coinSpeed++;
            transform.position = Vector3.MoveTowards(coinPosition, playerPosition, Time.deltaTime * coinSpeed);
        }
    }
}
