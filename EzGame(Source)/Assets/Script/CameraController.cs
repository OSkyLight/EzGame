using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    // Use this for initialization
    public Transform player;
    public float boundaryCamearaLeft, boundaryCameraRight;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x >= boundaryCamearaLeft && player.position.x <= boundaryCameraRight)
        {
            transform.position = new Vector3(player.position.x,
                                                transform.position.y,
                                                transform.position.z);
        }

    }
}
