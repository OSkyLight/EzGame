using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextStage : MonoBehaviour {

    public GameObject stageClearUI;
    public Text txt, buttonText, textStage;
    public PlayerController playerCtrl;

    private void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(textStage.text == "Stage 1")
            {
                stageClearUI.SetActive(true);
                txt.text = "Stage 1 Cleared";
                buttonText.text = "Move to Stage 2";
                Time.timeScale = 0;
                playerCtrl.curHealth = playerCtrl.maxHealth;
            }
            else if(textStage.text == "Stage 2")
            {
                stageClearUI.SetActive(true);
                txt.text = "GAME CLEARED";
                buttonText.text = "Back to Menu";
                Time.timeScale = 0;
                playerCtrl.curHealth = playerCtrl.maxHealth;
            }
            
        }
    }
}
