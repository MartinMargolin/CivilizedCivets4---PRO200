using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Grab : MonoBehaviour
{
    [SerializeField] InputActionProperty grabAction;
    [SerializeField] Transform holdTransform;

    [SerializeField] Grab otherHand;

    public bool grabbing = false;
    public bool stay = false;
    GameObject holding;
   
    void Update()
    {
        if (grabAction.action.ReadValue<float>() > 0.9)
        {
            grabbing = true;
        }
        else grabbing = false;

        if (grabbing && holding != null)
        {
            holding.transform.position = holdTransform.position;
            holding.transform.rotation = holdTransform.rotation;

        }
        else if (!grabbing && holding != null)
        {
            //holding.gameObject.transform.SetParent(null);
            holding.GetComponent<Rigidbody>().useGravity = true;
            holding.GetComponent<Rigidbody>().isKinematic = false;
            holding = null;
            stay = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Grabbable" && grabbing && holding == null)
        {
            //other.transform.SetParent(other.gameObject.transform);
            other.GetComponent<Rigidbody>().useGravity = false;
            other.GetComponent<Rigidbody>().isKinematic = true;
        }

        holding = other.gameObject;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Grabbable" && grabbing && holding == null && !stay)
        {
            //other.transform.SetParent(other.gameObject.transform);
            other.GetComponent<Rigidbody>().useGravity = false;
            other.GetComponent<Rigidbody>().isKinematic = true;
        }

        holding = other.gameObject;
        stay = true;
    }
}
