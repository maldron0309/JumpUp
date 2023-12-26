using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRespawn : MonoBehaviour
{
    [SerializeField] private float spawn;

    private void FixedUpdate()
    {
        if (transform.position.y < spawn)
        {
            transform.position = new Vector3(-6, 1, 2);
        }
    }
}
