using UnityEngine;
using System.Collections;

public class JM_TeleporterZone : MonoBehaviour {


    // a delay is implemented to prevent ping pong TPs
    public float teleportDelay = 0.0f;

    // the transported item is made exempt until it is touched again
    public Collider exemptItem;

    // references to the teleporter destination
    public GameObject targetPad;
    public BoxCollider thisCollider;
    private JM_TeleporterZone targetPadScript;

    // Use this for initialization
    void Start()
    {
        thisCollider = GetComponent<BoxCollider>();
        //get and store reference to the teleport script on the other pad
        targetPadScript = targetPad.GetComponent<JM_TeleporterZone>();
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
    
    void OnTriggerExit (Collider transportedObject)
    {
        if (transportedObject == exemptItem)
        {
            exemptItem = null;
        }
    }

    void OnTriggerEnter(Collider transportedObject)
    {
        // if the teleporter is not currently turned off and a ring arrives
        if (exemptItem != transportedObject && transportedObject.gameObject.tag == "TagThrowingDisc")
        {
            // disable the target pad
            //targetPadScript.teleportDelay = 2.0f;
            Debug.Log("Teleporting");
            targetPadScript.exemptItem = transportedObject;
            // move the object to the other pad
            Vector3 newPosition = targetPad.transform.position;
            //newPosition.y += 2.0f;
            transportedObject.transform.position = newPosition;
        }

    }
}
