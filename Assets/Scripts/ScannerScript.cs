using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Object") && other.GetComponent<Object>().isScanned == false)
        {
            FindObjectOfType<AudioManager>().Play("ItemScan");
            other.GetComponent<Object>().isScanned = true;
        }
    }
}
