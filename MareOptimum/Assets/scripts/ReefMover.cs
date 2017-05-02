using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReefMover : MonoBehaviour
{
    public float speed;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0)
            transform.Translate(Time.deltaTime * speed, 0, 0);
        else
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
