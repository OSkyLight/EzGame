using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialThornController : MonoBehaviour {

    public GameObject player;
    private float distanceThornPlayer;
    private Vector3 pos, starPos;
 

    // Use this for initialization
    void Start() {
        starPos = this.transform.position;
    }

    // Update is called once per frame
    void Update() {
        distanceThornPlayer = this.transform.position.x - player.transform.position.x;
        if (distanceThornPlayer <= 1.8 && distanceThornPlayer >= 0)
        {

            this.transform.position = new Vector3(this.transform.position.x, -0.9f);
        }
    }

    public void specialThronReset()
    {
        this.transform.position = starPos;
    }
}
