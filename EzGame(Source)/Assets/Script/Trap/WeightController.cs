using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightController : MonoBehaviour
{

    // Use this for initialization
    public GameObject player;
    public GameObject gameController;

    private Rigidbody2D weightRigidbody;
    private float distanceWeightPlayer;
    private Vector3 startPos;
    void Start()
    {
        weightRigidbody = GetComponent<Rigidbody2D>();
        weightRigidbody.gravityScale = 0;
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        distanceWeightPlayer = this.transform.position.x - player.transform.position.x;
        if (distanceWeightPlayer <= 1.8 && distanceWeightPlayer > 0)
        {
            weightRigidbody.gravityScale = 6.5f;
        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            this.gameObject.SetActive(false);
            weightRigidbody.gravityScale = 0;
        }
    }

    public void weightReset()
    {
        this.transform.position = startPos;
        this.gameObject.SetActive(true);
    }
}
