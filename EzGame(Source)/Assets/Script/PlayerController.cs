using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed, boundaryLeft, boundaryRight;
    public float force, jumpForce;
    private bool isPause;

    private bool isGround;
    Rigidbody2D playerRigidbody;
    private float positionY, distanceWeightPlayer;
    private Animator anim;
    private Vector3 scale, pos, startPos;
    private bool isCheckPoint;
    
    public GameObject checkPoint;
    public GameController gameCtrl;

    public int curHealth;
    public int maxHealth;
    public int starHealth;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emtyHeart;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        scale = this.transform.localScale;
        playerRigidbody = this.GetComponent<Rigidbody2D>();
        checkPoint.GetComponent<GameObject>();
        isGround = false;
        isCheckPoint = false;
        curHealth = maxHealth;
        startPos = this.transform.position;
        isPause = false;
        if (MainMenu.difficultLevel == 1)
        {
            starHealth = 8;
            maxHealth = 8;
        }
        else if (MainMenu.difficultLevel == 2)
        {
            starHealth = 6;
            maxHealth = 6;
        }
        else if (MainMenu.difficultLevel == 3)
        {
            starHealth = 4;
            maxHealth = 4;
        }
        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(curHealth == 0)
        {
            isCheckPoint = false;
        }
        
        //Di chuyen va nhay
        pos = this.transform.position;
        if(isPause == false)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (isGround == true)
                {
                    anim.Play("Walking");
                }
                if(this.transform.position.x <= boundaryRight)
                {
                    scale.x = -2;
                    transform.localScale = scale;
                    pos.x += speed * Time.deltaTime;
                    transform.position = pos;
                }
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (isGround == true)
                {
                    anim.Play("Walking");
                }
                if (this.transform.position.x >= boundaryLeft)
                {
                    scale.x = 2;
                    transform.localScale = scale;
                    pos.x -= speed * Time.deltaTime;
                    transform.position = pos;
                }
            }
            else if (isGround == true)
            {
                anim.Play("Idle");
            }
            if (isGround == true && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)))
            {
                anim.Play("Jump");
                playerRigidbody.AddForce(Vector2.up * force);
                isGround = false;
            }
        }

        // Hien mau
        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < curHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emtyHeart;
            }
            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "ground" && isGround == false)
        {
            isGround = true;
            playerRigidbody.gravityScale = 1.5f;
        }
        if (target.gameObject.tag == "water" || target.gameObject.tag == "Trap")
        {
            curHealth--;
            isPause = true; 
            gameCtrl.countinueUI();
            respond();
        }
        if (target.gameObject.tag == "JumpPad")
        {
            playerRigidbody.AddForce(Vector2.up * jumpForce);
            isGround = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "CheckPoint")
        {
            isCheckPoint = true;
        }
    }

    void respond()
    {
        if (isCheckPoint == false)
        {
            this.transform.position = startPos;
            playerRigidbody.gravityScale = 1.5f;
        }
        else if (isCheckPoint == true)
        {
            this.transform.position = checkPoint.transform.position;
            playerRigidbody.gravityScale = 1.5f;
        }
    }

    public void ground()
    {
        isGround = false;
    }

    public void pause()
    {
        isPause = true;
    }

    public void unPause()
    {
        isPause = false;
    }
}
