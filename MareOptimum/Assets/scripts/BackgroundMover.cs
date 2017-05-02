using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour 
{
    public float speed = 0;
    private BackgroundManager bg_script;

	// Use this for initialization
	void Start () 
    {
        GameObject bg = GameObject.FindWithTag("background_manager");
        bg_script = bg.GetComponent<BackgroundManager>();
       
	}
	
	// Update is called once per frame
	void Update () 
    {
        speed = bg_script.speed;
        transform.Translate(Time.deltaTime * (-speed), 0, 0);
	}

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
    }
}
