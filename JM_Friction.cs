using UnityEngine;
using System.Collections;

public class JM_Friction : MonoBehaviour {

    // the transported item is made exempt until it is touched again
    public bool discAttached;
    public GameObject movingPlatform;
    public Transform parentTransform;
    public Transform platformPositionOnContact;
    public Transform discPosition;

    public Vector3 oldPosition;
    public Vector3 newPosition;

    // Use this for initialization
    void Start()
    {
        movingPlatform = this.gameObject;
        parentTransform = gameObject.GetComponentInParent<Transform>();
        platformPositionOnContact = movingPlatform.transform;
        newPosition = parentTransform.position;
        oldPosition = newPosition;
    }

    /* Update is called once per frame
    void FixedUpdate()
    {
        if (exemptItem != null)
        {
            thisCollider.size = new Vector3 (0.01f, 0.01f, 0.01f);
        }
        else
        {
            thisCollider.size = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }*/

    void OnTriggerEnter(Collider transportedObject)
    {
        if (discAttached == false && transportedObject.gameObject.tag == "TagThrowingDisc")
        {
            // unparent disc from platform
            discAttached = true;
            //platformPositionOnContact = movingPlatform.transform;
            newPosition = parentTransform.position;
            oldPosition = newPosition;
        }
    }

    void OnTriggerExit(Collider transportedObject)
    {
        if (discAttached == true && transportedObject.gameObject.tag == "TagThrowingDisc")
        {
            // unparent disc from platform
            discAttached = false;
        }
    }

    void OnTriggerStay(Collider transportedObject)
    {
        newPosition = parentTransform.position;
        // if the disc lands on the moving pad
        if (discAttached == true && transportedObject.gameObject.tag == "TagThrowingDisc")
        {
            // move the disc identically to the pad
            //transportedObject.gameObject.transform.position = movingPlatform.transform.position - platformPositionOnContact.position;
            //transportedObject.gameObject.transform.position = movingPlatform.transform.position + new Vector3 (2,2,2);
            transportedObject.gameObject.transform.position += newPosition - oldPosition;
        }
        oldPosition = newPosition;
    }


    // Update is called once per frame
    void Update () {
	
	}
}
