using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadController : MonoBehaviour {

    // Use this for initialization
    private Animator jumpAnim;
	void Start () {
        jumpAnim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        jumpAnim.Play("Idle");
	}
    void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Player")
        {
            jumpAnim.Play("Jump");
        }
    }
}
