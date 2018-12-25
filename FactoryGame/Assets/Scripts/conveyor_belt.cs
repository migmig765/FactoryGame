using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conveyor_belt : MonoBehaviour {

    public GameObject[] rollen;
    public float rollenGeschwindigkeit;

    // Use this for initialization
    void Start () {

     }
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject rolle in rollen)
        {
            rolle.transform.Rotate(Vector3.forward * rollenGeschwindigkeit * Time.deltaTime);
        }
	}
}
