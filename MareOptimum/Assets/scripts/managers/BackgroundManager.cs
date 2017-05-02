using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour {

    public GameObject bg_blue_2;
    public GameObject bg_blue_3;
    public GameObject bg_blue_4;
    public GameObject bg_blue_5;
    public GameObject bg_blue_6;
    public GameObject bg_blue_7;
    public GameObject bg_blue_8;
    public GameObject bg_blue_9;
    public GameObject bg_blue_10;
    public GameObject bg_blue_11;
    public GameObject bg_blue_1;
    private GameObject[] all_background;

    public Vector3 spawnValue;
    public float start_wait;
    public float spawnWait;
    public float justWait = 0;
    public float step = 5.0f;

    private float position_z;
    private int index = 0;
    public float speed = 0;
    public bool boost = false;
	// Use this for initialization
	void Start () 
    {
        position_z = 50.0f;
        all_background = new GameObject[11]
        {
            bg_blue_2, bg_blue_3, bg_blue_4, bg_blue_5, bg_blue_6, bg_blue_7, bg_blue_8,
            bg_blue_9, bg_blue_10, bg_blue_11, bg_blue_1
        };

        StartCoroutine(drawBackGround());
	}

    IEnumerator drawBackGround()
    {
       yield return new WaitForSeconds(start_wait);
       while(true)
       {
           Quaternion spawnRotation = new Quaternion();
           position_z += step;
           Vector3 spawnPosition = new Vector3(spawnValue.x, spawnValue.y, position_z);

           if (position_z > 70.0f)
               position_z = 50.0f;

           Instantiate(all_background[index++], spawnPosition, spawnRotation);
           if (index == 11)
               index = 0;
           //Debug.Log("boost = " + boost);
           if (boost)
           {
               break;
           }
           yield return new WaitForSeconds(spawnWait);
       }
       yield return new WaitForSeconds(justWait);
    }

    
}
