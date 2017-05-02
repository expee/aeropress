using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {

    public GameObject[] MainMenu;
	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void FadeIn(GameObject UIObj, float duration)
    {
        UIObj.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
        UIObj.GetComponent<Image>().CrossFadeAlpha(1.0f, duration, true);
    }

    public void FadeOut(GameObject UIObj, float duration)
    {
        UIObj.GetComponent<CanvasRenderer>().SetAlpha(1.0f);
        UIObj.GetComponent<Image>().CrossFadeAlpha(0.0f, duration, true);
    }
}
