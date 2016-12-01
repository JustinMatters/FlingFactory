using UnityEngine;
using System.Collections;

public class JM_ConveyorAnimation : MonoBehaviour {

    public Vector2 UVspeed;
    private Vector2 UVoffset = Vector2.zero;
    private Renderer planeRenderer;

	// Use this for initialization
	void Start () {
        planeRenderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        UVoffset += (UVspeed * Time.deltaTime);
        planeRenderer.material.SetTextureOffset("_MainTex", UVoffset);
	}
}
