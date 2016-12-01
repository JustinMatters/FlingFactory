using UnityEngine;
using System.Collections;

public class JM_FlyingDisc : MonoBehaviour {

    public int version = 3;
    public float liftFactor = 2.0f;
    public float spinSpeed = 1.0f;
    public float thresholdSpeed = 0.3f;
    private Rigidbody rb;

	// Use this for initialization
	void Awake () {
        // get the Rigidbody of the disc
        rb = GetComponent<Rigidbody>();
            // If there is no rigid body, add one and set it's values for a flying disc.
            if (!rb)
            {
                rb = gameObject.AddComponent<Rigidbody>();
                rb.isKinematic = false;
                rb.useGravity = true;
                rb.mass = 1.0f;
                rb.angularDrag = 0.1f;
                rb.drag = 0.1f;
            }
        }
	
	// FixedUpdate is called on a regular timeframe
	void FixedUpdate () {
	    if (!rb.isKinematic)
        {
            // work out how fast the disc is going not including movement parallel to its axis of symettry (Y-axis)
            float discSpeed = Mathf.Sqrt((rb.velocity.x * rb.velocity.x) + (rb.velocity.z * rb.velocity.z));
            // use the speed of the disc to determine the amount of lift the disc provides
            Vector3 lift = new Vector3(0.0f, discSpeed * liftFactor, 0.0f);
            //apply the ift as a force on the disc
            rb.AddForce(lift);
            if (discSpeed > thresholdSpeed)
            {
                transform.Rotate(Vector3.forward, discSpeed * spinSpeed);
            }
        }

	}
}
