using UnityEngine;
using System.Collections;

public class GrabObject : MonoBehaviour
{
    private GameObject grabbedObject;
    private bool isGrabbing;

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                if (hit.collider.gameObject.CompareTag("Grabbable"))
                {
                    grabbedObject = hit.collider.gameObject;
                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                    grabbedObject.transform.SetParent(this.transform);
                    isGrabbing = true;
                }
            }
        }

        if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch) && isGrabbing)
        {
            grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
            grabbedObject.transform.SetParent(null);
            grabbedObject = null;
            isGrabbing = false;
        }
    }
}