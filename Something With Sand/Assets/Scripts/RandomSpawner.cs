using System.Collections;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] float SpawnRadius = 100f;
    [SerializeField] float SpawnInterval = 2f;
    public GameObject Bomb;
    public Transform PlayerTransform;


    private bool canSpawn = true;

    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

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