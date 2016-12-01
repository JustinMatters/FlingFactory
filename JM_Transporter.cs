using UnityEngine;
using System.Collections;

public class JM_Transporter : MonoBehaviour {

    // a delay is implemented to prevent ping pong TPs
    public float teleportDelay = 0.0f;

    // references to the teleporter destination
    public GameObject targetPad;
    private JM_Transporter targetPadScript;

    // Use this for initialization
    void Start()
    {
        //get and store reference to the teleport script on the other pad
        targetPadScript = targetPad.GetComponent<JM_Transporter>();
    }

    // Update is called once per frame
    void Update()
    {
        //decrement the delay on this teleport pad if one exists
        if (teleportDelay > 0.0f)
        {
            teleportDelay -= Time.deltaTime;
        }
    }

    void OnTriggerStay(Collider transportedObject)
    {
        // if the teleporter is not currently turned off
        if (teleportDelay <= 0.0f && transportedObject.tag != "Player")
        {
            // disable the target pad
            targetPadScript.teleportDelay = 2.0f;
            // move the object to the other pad
            transportedObject.transform.position = targetPad.transform.position;

        }

    }
}
