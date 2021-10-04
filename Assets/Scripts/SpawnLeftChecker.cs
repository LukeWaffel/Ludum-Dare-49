using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExpPlus.Phariables;

public class SpawnLeftChecker : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private float spawnWidth = 1f;
    [SerializeField]
    private BoolRepherence leftSpawn;


    private void Update()
    {
        if (playerTransform.position.x > transform.position.x)
            leftSpawn.value = true;
    }
}
