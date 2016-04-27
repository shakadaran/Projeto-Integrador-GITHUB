using UnityEngine;
using System.Collections;

public class PlayerInputs : MonoBehaviour {
    public float h, v, r;
    public bool atk1, atk2,run;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        this.h = Input.GetAxis("Horizontal");
        this.v = Input.GetAxis("Vertical");
        this.r = Input.GetAxis("Mouse X");
        this.atk1 = Input.GetButton("Fire1");
        this.atk2 = Input.GetButton("Fire2");
        this.run= Input.GetButton("Fire3");
    }
}
