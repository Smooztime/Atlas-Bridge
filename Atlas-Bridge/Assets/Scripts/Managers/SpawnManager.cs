using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnManager : MonoBehaviour
{
    [Header("rolling barrel spawn")]
    [SerializeField] private GameObject rollBarrelPerfab;
    [SerializeField] private Transform[] barrelSpawnTransform;
    private float spawnTimer = 0f;
    public float spawnInterval = 2f;
    private GameObject barrelObject;
    private List<GameObject> barrels;

    [SerializeField] private float barrelMoveDistance;

    [Header("bomb spawn")]
    [Header("rolling barrel move")]
    public float rollSpeed = 5f;

    private void Awake()
    {
        barrels = new List<GameObject>();
    }

    private void SpawnBarrel()
    {
        foreach (Transform spawnPoint in barrelSpawnTransform)
        {
            GameObject barrelObject = Instantiate(rollBarrelPerfab, spawnPoint.position, Quaternion.Euler(0f, -90f, 0f));
            barrels.Add(barrelObject);
        }
    }

    private void MoveBarrel()
    {
        for (int i = barrels.Count - 1; i >= 0; i--)
        {
            GameObject barrel = barrels[i];

            if (barrel != null)
            {
                // Move the barrel to the left
                barrel.transform.position += Vector3.forward * rollSpeed * Time.fixedDeltaTime;

                // Destroy the barrel if it goes beyond a certain position
                if (barrel.transform.position.z > barrelMoveDistance)
                {
                    Destroy(barrel);
                    barrels.RemoveAt(i); // Remove the destroyed barrel from the list
                }
            }
        }
    }

    void FixedUpdate()
    {
        // Update the spawn timer
        spawnTimer += Time.fixedDeltaTime;

        // Spawn a new barrel if the spawn interval has elapsed
        if (spawnTimer >= spawnInterval)
        {
            SpawnBarrel();
            spawnTimer = 0f; // Reset the spawn timer
        }

        // Move all barrels
        MoveBarrel();
    }
}
