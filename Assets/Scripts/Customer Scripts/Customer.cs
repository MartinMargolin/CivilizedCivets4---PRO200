using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NavMeshMovement), typeof(PathFollower))]
public class Customer : MonoBehaviour
{
    [SerializeField] Movement movement;
    [SerializeField] PathFollower follower;

    private GameObject dest;
    private bool pause = false;

    private void Start()
    {
        // get destination
        //dest = ?;
    }

    private void Update()
    {
        if (!pause)
        {
            // continue to next destination
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Register"))
        {
            pause = true;
            // spawn items
        }
    }
}
