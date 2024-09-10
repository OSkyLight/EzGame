using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenController : MonoBehaviour {

    // Use this for initialization
    public float endPoint, speed;
    private Vector3 starPos, currentPos;
    private bool flag;
	void Start () {
        starPos = transform.position;
        flag = true;
	}
	
	// Update is called once per frame
	void Update () {
        currentPos = transform.position;
        if(currentPos.y <= starPos.y)
        {
            flag = true;
        }
        else if(currentPos.y >= endPoint)
        {
            flag = false;
        }
        if(flag == true)
        {
            currentPos.y += speed * Time.deltaTime;
            this.transform.position = currentPos;
        }
        else if(flag == false)
        {
            currentPos.y -= speed * Time.deltaTime;
            this.transform.position = currentPos;
        }
    }
}
