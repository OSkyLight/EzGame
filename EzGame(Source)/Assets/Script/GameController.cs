using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{

    public PlayerController playerCtrl;
    public GameObject weightRoot, vanishGroundRoot, specialThornRoot, extraLifeRoot;
    

    private WeightController[] weightCtrl;
    private VanishGroundController[] vanishGroundCtrl;
    private SpecialThornController[] specialThornCtrl;
    private ExtraLifeController[] extraLifeCtrl;

    public GameObject PauseUI, player;
    public Text txt, buttonTxt, stageText;


    private Vector3 playerStartPos;
    private bool paused = false;

    // Use this for initialization
    void Start()
    {
        PauseUI.SetActive(false);
        playerStartPos = player.transform.position;
        weightCtrl = weightRoot.GetComponentsInChildren<WeightController>();
        vanishGroundCtrl = vanishGroundRoot.GetComponentsInChildren<VanishGroundController>();
        specialThornCtrl = specialThornRoot.GetComponentsInChildren<SpecialThornController>();
        extraLifeCtrl = extraLifeRoot.GetComponentsInChildren<ExtraLifeController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Game OVer
        if (playerCtrl.curHealth == 0)
        {
            txt.text = "Game Over Ahihi";
            buttonTxt.text = "Try again";
            PauseUI.SetActive(true);
            playerCtrl.pause();
        }

        //Pause UI
        if (Input.GetButtonDown("esc"))
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void countinueUI()
    {
        //Đổi chữ và hiện UI
        txt.text = "YOU DIED!!!";
        buttonTxt.text = "Continue";
        PauseUI.SetActive(true);
        //Reset
    }

    //Pause UI button
    public void resume()
    {
        playerCtrl.unPause();
        if (playerCtrl.curHealth == 0)
        {
            playerCtrl.curHealth = playerCtrl.starHealth;
            playerCtrl.maxHealth = playerCtrl.starHealth;
            player.transform.position = playerStartPos;
            //Reset Extra Life
            for (var i = 0; i < extraLifeCtrl.Length; i++)
            {
                extraLifeCtrl[i].extraLiefReset();
            }
        }
        Time.timeScale = 1;
        PauseUI.SetActive(false);
        //Reset Weight
        for (var i = 0; i < weightCtrl.Length; i++)
        {
            weightCtrl[i].weightReset();
        }
        //Reset vanishground
        for(var i = 0; i<vanishGroundCtrl.Length; i++)
        {
            vanishGroundCtrl[i].gameObject.SetActive(true);
        }
        //Reset special thorn
        for( var i = 0; i < specialThornCtrl.Length; i++)
        {
            specialThornCtrl[i].specialThronReset();
        }
        
    }

    public void stageClear()
    {
        if(stageText.text == "Stage 1")
        {
            SceneManager.LoadScene("Stage2");
            Time.timeScale = 1;
        }
        else if(stageText.text == "Stage 2")
        {
            SceneManager.LoadScene("Menu");
            Time.timeScale = 1;
        }

    }
    public void exit()
    {
        SceneManager.LoadScene("Menu");
    }
}
