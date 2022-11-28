using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public bool isScanned = false;

    private void OnTriggerStay(Collider other)
    {
            if (GameObject.Find("Left Hand").GetComponent<Grab>().grabbing == true && GameObject.Find("Left Hand").GetComponent<Grab>().holding == this.gameObject || GameObject.Find("Right Hand").GetComponent<Grab>().grabbing == true && GameObject.Find("Right Hand").GetComponent<Grab>().holding == this.gameObject)
            {
                return;
            }
            else if (other.gameObject.tag == "Conveyor")
            {
                switch (other.gameObject.GetComponent<Conveyor>().direction)
                {
                    case 1:
                        transform.position += Vector3.forward / 70;
                        break;
                    case 2:
                        transform.position += Vector3.right / 70;
                        break;
                    case 3:
                        transform.position += Vector3.back / 70;
                        break;
                    case 4:
                        transform.position += Vector3.left / 70;
                        break;
                }

            }
        
    }
}
