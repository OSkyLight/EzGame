using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishGroundController : MonoBehaviour {

    public GameObject player;
    private Rigidbody2D playerRigidbody;
    // Use this for initialization
    void Start () {
        playerRigidbody = player.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            this.gameObject.SetActive(false);
        }
    }
}
