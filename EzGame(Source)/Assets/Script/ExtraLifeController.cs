using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLifeController : MonoBehaviour {

    public PlayerController playerCtrl;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag ==  "Player" )
        {
            if(playerCtrl.curHealth < playerCtrl.maxHealth)
            {
                playerCtrl.curHealth += 1;
            }
            else if(playerCtrl.curHealth == playerCtrl.maxHealth && playerCtrl.maxHealth < 8)
            {
                playerCtrl.maxHealth += 1;
                playerCtrl.curHealth += 1;
            }
            this.gameObject.SetActive(false);
        }
    }

    public void extraLiefReset()
    {
        this.gameObject.SetActive(true);
    }
}
