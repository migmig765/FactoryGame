using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_control : MonoBehaviour {

    public Vector3 directionVector;
    public float itemMovementSpeed;

    private Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = new Vector3(itemMovementSpeed * directionVector.x, itemMovementSpeed * directionVector.y, itemMovementSpeed * directionVector.z);
        //this.transform.Translate(directionVector.x * itemMovementSpeed * Time.deltaTime,directionVector.y * itemMovementSpeed * Time.deltaTime, directionVector.z * itemMovementSpeed * Time.deltaTime);
    }

    public void setDirectionVector(float xValue, float yValue, float zValue)
    {
        directionVector = new Vector3(xValue, yValue, zValue);
    }
    public Vector3 getDirectionVector()
    {
        return directionVector;
    }

}
