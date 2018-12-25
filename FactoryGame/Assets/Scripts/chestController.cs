using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestController : MonoBehaviour {

    private int containItems;

	// Use this for initialization
	void Start () {
        containItems = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "gear")
        {
            Destroy(collision.gameObject);
            containItems++;
            Debug.Log(containItems);
        }
    }
}
