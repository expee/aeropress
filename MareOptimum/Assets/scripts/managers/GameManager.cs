using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject UICanvas;
    private enum gameStateEnum
    {
        idle = -1,
        startingGame,
        inGame,
        showingGameOverScreen,
        continueGame,
        showingAds,
        invokeIAP
    };
    private int gameState;
	
    // Use this for initialization
	void Start () {
       // UICanvas.GetComponent<UIManager>().FadeIn(UICanvas, 1.0f);
        gameState = (int)gameStateEnum.idle;

    }
	
	// Update is called once per frame
	void Update () {
		switch(gameState)
        {
            case (int)gameStateEnum.idle:
                {
                    Debug.Log("In Idle Game State");
                    return;
                };
            case (int)gameStateEnum.startingGame:
                {
                    Debug.Log("In Starting Game State");
                    //Do something here
                    ChangeState((int)gameStateEnum.idle);
                }
                break;
            case (int)gameStateEnum.inGame:
                {

                }
                break;
            case (int)gameStateEnum.showingGameOverScreen:
                {

                }
                break;
            case (int)gameStateEnum.continueGame:
                {

                }
                break;
            case (int)gameStateEnum.showingAds:
                {

                }
                break;
            case (int)gameStateEnum.invokeIAP:
                {

                }
                break;
        }
	}

    public void ChangeState(int state)
    {
        Debug.Log("Changing State to " + state);
        gameState = state;
    }
}
