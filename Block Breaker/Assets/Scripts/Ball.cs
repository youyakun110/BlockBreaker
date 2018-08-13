using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField] Paddle Paddle1;
    [SerializeField] float xPush = 2.0f;
    [SerializeField] float yPush = 14.0f;
    [SerializeField] AudioClip[] ballSounds;
 
    private Vector2 paddleToBallPos;
    private bool hasStarted = false;

    //cached components references
    AudioSource myAudioSource;
    Rigidbody2D ballRigidbody2D;

	// Use this for initialization
	void Start () {
        paddleToBallPos = this.transform.position - this.Paddle1.transform.position;
        myAudioSource = this.GetComponent<AudioSource>();
        ballRigidbody2D = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!hasStarted) {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
	}

    void LockBallToPaddle() {
        Vector2 paddlePos = new Vector2(this.Paddle1.transform.position.x, this.Paddle1.transform.position.y);
        this.transform.position = paddlePos + paddleToBallPos;
    }
    void LaunchOnMouseClick() {
        if(Input.GetMouseButtonDown(0))
        {
            ballRigidbody2D.velocity = new Vector2(xPush, yPush);
            hasStarted = true;
        }
        
    }
	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (hasStarted) {
            AudioClip audioClip = ballSounds[Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(audioClip);
            ballRigidbody2D.velocity = new Vector2(ballRigidbody2D.velocity.x, ballRigidbody2D.velocity.y - 0.1f);
        }
	}
}
