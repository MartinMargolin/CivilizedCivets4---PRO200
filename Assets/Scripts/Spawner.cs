using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Customer Parameters")]
    [SerializeField] private bool pauseOnEnter = false;
    [SerializeField] private bool destroyOnEnter = false;
    [Header("Spawn Parameters")]
    [SerializeField] private List<GameObject> spawnableObjects;
    [SerializeField] private Transform spawnLocation;
    [Header("Multi Spawn Parameters")]
    [SerializeField] private bool spawnMultiple = false;
    [SerializeField] private int spawnAmount = 2;

    private Customer customerComponent;

    private void OnTriggerEnter(Collider other)
    {
        if (spawnMultiple)
        {
            for (int i = 0; i < spawnAmount; i++)
            {
                Instantiate(spawnableObjects[Random.Range(0, spawnableObjects.Count - 1)], spawnLocation);
            }
        }
        else
            Instantiate(spawnableObjects[Random.Range(0, spawnableObjects.Count - 1)], spawnLocation);

        if (destroyOnEnter) Destroy(other.gameObject);
        if (pauseOnEnter && other.TryGetComponent<Customer>(out customerComponent))
        {
            customerComponent.idle.value = true;
            customerComponent.walk.value = false;
            customerComponent.spawnedItems = true;
        }
    }
}
