using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermoveup : MonoBehaviour {

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
            other.transform.position += new Vector3(0, 5 * Time.deltaTime);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
