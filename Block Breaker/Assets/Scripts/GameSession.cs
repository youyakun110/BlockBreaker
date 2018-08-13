using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour {

    //speed seeting
    [Range(0.1f, 10f)] [SerializeField] float speed;


    //score setting
    [SerializeField] int pointsPerBlockDestory;

    [SerializeField] int currentScore;

    //Set UI text
    [SerializeField] TextMeshProUGUI scoreText;

	// awake

	void Awake()
	{
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if(gameStatusCount > 1){
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
	}


	// Use this for initialization
	void Start () {
        //scoreText = FindObjectOfType<TextMeshProUGUI>();
        currentScore = 0;
        pointsPerBlockDestory = 3;
        scoreText.text = currentScore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        Time.timeScale = speed;
	}
    public void addPointPerDestory()
    {
        //scoreText = FindObjectOfType<TextMeshProUGUI>();
        currentScore += pointsPerBlockDestory;
        Debug.Log(currentScore);
        scoreText.text = currentScore.ToString();
        Debug.Log(scoreText.text);
    }
    public void resetTheGame()
    {
        Destroy(gameObject);
    }


}