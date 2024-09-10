using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour {

    public GameObject weight;

    private Rigidbody2D weightRigidbody;
    private Vector3 starPos, weightStartPos;
	// Use this for initialization
	void Start () {
        weightRigidbody = weight.GetComponent<Rigidbody2D>();
        starPos = this.transform.position;
        weightStartPos = weight.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   
}
