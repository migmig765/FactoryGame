using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionAttachment : MonoBehaviour {

    public GameObject zahnradmaschine;
    public GameObject nextItem;
    private zahnradmaschine zahnradmaschineScript;

	// Use this for initialization
	void Start () {
        zahnradmaschineScript = zahnradmaschine.GetComponent<zahnradmaschine>();
    }
	
	// Update is called once per frame
	void Update () {
        if(nextItem != null)
        {
            if (zahnradmaschineScript.getProgressState() == false)
            {
                Destroy(nextItem);
                zahnradmaschineScript.inputImpulse();
                nextItem = null;
            }
        }
	}
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "item")
        {
           if(zahnradmaschineScript.getProgressState() == false)
            {
                Destroy(collision.gameObject);
                zahnradmaschineScript.inputImpulse();
            }       
           else
            {
                nextItem = collision.gameObject;
            }
        }
    }
}
