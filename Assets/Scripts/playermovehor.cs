using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovehor : MonoBehaviour {

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
            other.transform.position += new Vector3( 5 * Time.deltaTime, 0);

       
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
