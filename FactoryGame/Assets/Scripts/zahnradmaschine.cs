using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zahnradmaschine : MonoBehaviour {

    public GameObject stampfer;
    public GameObject outputPointer;
    public GameObject pseudoItem;

    private float stampferStartHeight;
    public int produktionszeit; //in ms 

    private bool doStampfen = false;
    private float stampfDirection = -1f;
    public float stampferOffset;
    public float stampfGeschwindigkeit;

    public GameObject outputItem;
    private static bool isInProgress = false;

	// Use this for initialization
	void Start () {
        stampferStartHeight = stampfer.transform.position.y; //3.8f
    }
	
	// Update is called once per frame
	void Update () {
        if(stampfer.transform.position.y >= stampferStartHeight)
        {
            stampfDirection = 0;
            if (isInProgress)
            {
                stampfDirection = -1f;
            }
        }
        if(stampfer.transform.position.y <= (stampferStartHeight-stampferOffset))
        {
            stampfDirection = 1f;
        }
        stampfer.transform.Translate(new Vector3(0,0,stampfGeschwindigkeit * stampfDirection * Time.deltaTime));
	}

    IEnumerator ProgressTimer()
    {
        pseudoItem.SetActive(true);
        yield return new WaitForSeconds(produktionszeit);   
        isInProgress = false;
        pseudoItem.SetActive(false);
        GameObject newItem = (GameObject)Instantiate(outputItem, outputPointer.transform.position, Quaternion.identity);
        newItem.transform.Rotate(90,0,0);
    }


    public void inputImpulse()
    {
        isInProgress = true;
        StartCoroutine(ProgressTimer());
    }
    public bool getProgressState()
    {
        return isInProgress;
    }

}
