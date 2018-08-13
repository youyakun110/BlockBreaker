using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] float screenWidthInUnits = 21.3333333f;
    [SerializeField] float paddleXMin = 1.0f;
    [SerializeField] float paddleXMax = 20.3333333f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(Input.mousePosition.x / Screen.width * screenWidthInUnits);
        float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        mousePosInUnits = Mathf.Clamp(mousePosInUnits, paddleXMin, paddleXMax);
        Vector2 paddlePos = new Vector2(
            mousePosInUnits, this.transform.position.y
        );
        this.transform.position = paddlePos;
	}
}
