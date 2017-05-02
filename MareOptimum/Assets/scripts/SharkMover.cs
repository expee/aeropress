using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkMover : MonoBehaviour {

    public float speed;
    private GameObject player;
    private float position_x = 0;
    private float distance = 0;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = transform.position.x - player.transform.position.x;
        if (distance <= 70)
        {
            speed = 50;
            transform.Translate(Time.deltaTime * speed, 0, 0);
        }
        else
        {
            transform.Translate(Time.deltaTime * speed, 0, 0);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
    }
}
