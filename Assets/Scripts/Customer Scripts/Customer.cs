using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NavMeshMovement), typeof(PathFollower))]
public class Customer : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] Movement movement;
    [SerializeField] PathFollower follower;

    [Header("Aesthetics")]
    [SerializeField] bool randomizeColor = false;
    [SerializeField] List<Material> colors;

    [HideInInspector] public bool pause = false;
    private GameObject dest;

    private void Awake()
    {
        if (randomizeColor) RandomizeMaterial(colors);
    }

    private void RandomizeMaterial(List<Material> materials)
    {
        if (materials.Count > 0)
        {
            int random = Random.Range(0, materials.Count - 1);
            gameObject.GetComponent<MeshRenderer>().material = materials[random];
        }
    }
}
