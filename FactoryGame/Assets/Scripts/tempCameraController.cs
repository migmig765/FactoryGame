using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempCameraController : MonoBehaviour {

    public GameObject item;
    public float cameraSpeed;
    private bool doOnce = true;
    private int testvar = 0;

    // Use this for initialization
    void Start () {
        Instantiate(item, new Vector3(-20.2f, 2.62f, 0.5f), Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))    
        {
            Instantiate(item, new Vector3(-20.2f, 2.62f, 0.5f), Quaternion.identity);
        }
        TapSelect();
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                testvar++;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended && testvar < 5)
            {
                Debug.Log("wtf");
                Instantiate(item, new Vector3(-20.2f, 2.62f, 0.5f), Quaternion.identity);
            }
            if (Input.GetTouch(0).phase == TouchPhase.Moved && testvar > 3)
            {
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                transform.Translate(-touchDeltaPosition.x * cameraSpeed * Time.deltaTime, 0, 0);
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            { 
                testvar = 0;
            }
    
         }
        
    }

    void TapSelect()
    {
        int layerMask = 1 << 10;
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {

                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask, QueryTriggerInteraction.Collide))
                {
                    Debug.Log("Did Hit");
                }
            }
        }
    }


}
