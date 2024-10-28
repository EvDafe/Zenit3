using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneFollower : MonoBehaviour
{
    private Transform _player;

    private void Awake()
    {
        _player = GameObject.Find("Rocket").transform;
    }

    private void Update()
    {
        transform.position = new Vector3(0, _player.position.y, -10);
    }
}
