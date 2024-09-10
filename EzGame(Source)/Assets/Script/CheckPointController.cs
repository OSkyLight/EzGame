using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour {

    private Animator ckAnim;
    private bool isCheck;
	// Use this for initialization
	void Start () {
        ckAnim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(isCheck == true)
        {
            ckAnim.Play("Check");
        }
	}

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.gameObject.tag == "Player")
        {
            isCheck = true;
        }
    }
}
