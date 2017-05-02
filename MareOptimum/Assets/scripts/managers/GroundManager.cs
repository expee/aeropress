using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour {

    public GameObject ground;
    public Vector3 spawnValue;

    public float start_wait = 0;
    public float spawnWait = 0;
    public float justWait = 0;
	// Use this for initialization
    void Start()
    {
        StartCoroutine(drawGround());
    }

    IEnumerator drawGround()
    {
        yield return new WaitForSeconds(start_wait);
        while (true)
        {
            Quaternion spawnRotation = new Quaternion();
            Vector3 spawnPosition = new Vector3(spawnValue.x, spawnValue.y, spawnValue.z);
            Instantiate(ground, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(spawnWait);
        }
       // yield return new WaitForSeconds(justWait);
    }
}
