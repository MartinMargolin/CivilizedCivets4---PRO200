using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Grab : MonoBehaviour
{
    [SerializeField] InputActionProperty grabAction;
    [SerializeField] Transform holdTransform;

    [SerializeField] Grab otherHand;

    public SkinnedMeshRenderer meshRenderer;

    [SerializeField] bool test = false;
    public bool grabbing = false;
    public bool stay = false;
    GameObject holding;

    Color good = new Color(134, 255, 169, 255);
    Color basic = new Color(255, 253, 134, 255);

    private void Awake()
    {
        meshRenderer = this.GetComponentInChildren<SkinnedMeshRenderer>();
        Debug.Log(meshRenderer.material.name);

    }

    void Update()
    {
        if (grabAction.action.ReadValue<float>() > 0.9 || test == true)
        {
            grabbing = true;
        }
        else grabbing = false;


        if (!grabbing && holding != null)
        {
            holding.gameObject.transform.SetParent(null);
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

            if (otherHand.GetComponent<Grab>().holding != null && otherHand.GetComponent<Grab>().holding.gameObject == other.gameObject) { }
            else
            {
                other.transform.SetParent(this.gameObject.transform);
                //Debug.Log(this.gameObject.name + " | " + this.gameObject.transform);

                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;

                holding = other.gameObject;
            }
            
        }

        // if (other.gameObject.tag == "Grabbable") { meshRenderer.material.SetColor("_Color", good); } else meshRenderer.material.SetColor("_Color", basic);
        // Debug.Log(holding);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Grabbable" && grabbing && holding == null && !stay)
        {
 
                if (otherHand.GetComponent<Grab>().holding != null && otherHand.GetComponent<Grab>().holding.gameObject == other.gameObject) { }
                else
                {
                    other.transform.SetParent(this.gameObject.transform);
                    //Debug.Log(this.gameObject.name + " | " + this.gameObject.transform);

                    other.GetComponent<Rigidbody>().useGravity = false;
                    other.GetComponent<Rigidbody>().isKinematic = true;

                    holding = other.gameObject;
                    stay = true;
                }

            
        }

        // if (other.gameObject.tag == "Grabbable") { meshRenderer.material.SetColor("_Color", good); } else meshRenderer.material.SetColor("_Color", basic);
        //Debug.Log(holding);
    }

    private void OnTriggerExit(Collider other)
    {
       // meshRenderer.material.SetColor("_Color", basic);
    }
}