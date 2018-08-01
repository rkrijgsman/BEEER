using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public bool rotate;
    private Rigidbody playerBody;
    private PlayerController playerController;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
        playerBody = player.GetComponent<Rigidbody>();
        playerController = player.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void LateUpdate () {

        if (rotate)
        {
            Vector3 offsetRotated = Quaternion.Euler(0, playerController.GetAngle(), 0) * offset;
            offsetRotated.y = offset.y;
            transform.position = player.transform.position + offsetRotated;
            transform.forward = (player.transform.position - transform.position).normalized;
        }
        else
        {
            transform.position = player.transform.position + offset;
        }

    }
}
