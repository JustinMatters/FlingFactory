using UnityEngine;
using System.Collections;

public class JM_Target : MonoBehaviour {

    public int iteration = 3;
    public GameObject throwingDisc;
    private Renderer targetAppearance;

    // Use this for initialization
    void Start () {
        targetAppearance = GetComponent<Renderer>();
        targetAppearance.material.color = Color.yellow;
    }

    void OnCollisionEnter(Collision otherObject)
    {
        if (otherObject.gameObject.tag == "TagThrowingDisc")
        {
            targetAppearance.material.color = Color.magenta;
            Debug.Log("Target Hit");
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
