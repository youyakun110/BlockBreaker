using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    public int blocksLeft;

    private SceneLoader sceneLoader;

	// Use this for initialization
	void Start () {
        sceneLoader = FindObjectOfType<SceneLoader>();
	}
	

    //add a block to the stock

    public void addBlock()
    {
        blocksLeft++;
    }

    //delete the destoried block
    public void deleteBlock()
    {
        blocksLeft--;
        if (blocksLeft == 0)
        {
            sceneLoader.LoadNextScene();
        }
    }

}
