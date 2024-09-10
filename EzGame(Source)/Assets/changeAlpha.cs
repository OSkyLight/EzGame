using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeAlpha : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Color tmp = this.GetComponent<Image>().color;
        tmp.a = 1.0f;
        this.GetComponent<Image>().color = tmp;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
