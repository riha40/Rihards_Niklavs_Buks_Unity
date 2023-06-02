using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] float SpawnRadius = 100f;
    [SerializeField] float SpawnInterval = 2f;
    public GameObject Bomb;
    public Transform PlayerTransform;


    private bool canSpawn = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    // Coroutine function for spawning objects at a defined interval
    private IEnumerator SpawnObjects()
    {
        while (true)
        {
                Vector3 randomOffset = Random.insideUnitCircle * SpawnRadius;
                Vector3 spawnPosition = PlayerTransform.position + randomOffset;
                GameObject.Instantiate(Bomb, spawnPosition, Quaternion.identity);
                canSpawn = false;
                yield return new WaitForSeconds(SpawnInterval);
                canSpawn = true;
            }
    }
}