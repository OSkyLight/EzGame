using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGroundController : MonoBehaviour {

    public GameObject groundRightPos;
    public float distanceGround, speed;
    private float stopPoint;
    private Vector3 startPos;
    private Vector3 pos;
    private bool flag;
	// Use this for initialization
	void Start () {
        stopPoint = groundRightPos.transform.position.x - distanceGround;
        startPos = transform.position;
        flag = true;
    }
	
	// Update is called once per frame
	void Update () {
        pos = this.transform.position;
        if(pos.x <= startPos.x)
        {
            flag = true;
        }
        else if(pos.x >= stopPoint)
        {
            flag = false;
        }
        if (flag == true)
        {
            pos.x += speed * Time.deltaTime;
            transform.position = pos;
        }
        else if(flag == false)
        {
            pos.x -= speed * Time.deltaTime;
            transform.position = pos;
        }
	}
}
