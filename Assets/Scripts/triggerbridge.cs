using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerbridge : MonoBehaviour {
    public GameObject Balk;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            Destroy(Balk);
    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		


	}
}
