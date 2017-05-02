using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour 
{

    // small reef
    public GameObject small_reef_1;
    public GameObject small_reef_2;
    public GameObject small_reef_3;
    // medium reef
    public GameObject medium_reef_1;
    public GameObject medium_reef_2;
    public GameObject medium_reef_3;

    // high reef
    public GameObject high_reef_1;
    public GameObject high_reef_2;
    public GameObject high_reef_3;

    public Vector3 spawnValue;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public float sharkWait = 20;
    private float default_wait = 8;
    // shark
    public GameObject shark;
    private bool time_to_show_shark = false;

    private int m_reefCount;
    private GameObject[] m_reef;


    void Start ()
    {
        m_reefCount = 5;
        m_reef = new GameObject[6] 
        { 
            small_reef_1, small_reef_2, small_reef_3, 
            medium_reef_1, medium_reef_2, medium_reef_3,
            //high_reef_1, high_reef_2, high_reef_3
        };
        StartCoroutine(drawObstacle());
    }

    IEnumerator drawObstacle()
    {
        yield return new WaitForSeconds(startWait);
        while(true)
        {
            for (int i = 0; i < m_reefCount; i++)
            {

                time_to_show_shark = false;
                int index_reef;
                // CALCULATE RANDOMNESS OF REEF TYPE
                index_reef = Random.Range(0, m_reef.Length);

                // CALCULATE RANDOMNESS POSITION OF REEF
                int where = Random.Range(0, 2);
                float position_y = 0.0f;
                Quaternion spawnRotation = new Quaternion();

                if (where == 0)
                {
                    if (index_reef <= 2)
                        position_y = 32.5f;
                    else if (index_reef >= 3 && index_reef <= 5)
                        position_y = 20.0f;
                    else
                        position_y = 6.5f;
                }
                else
                {
                    if (index_reef <= 2)
                        position_y = -32.5f;
                    else if (index_reef >= 3 && index_reef <= 5)
                        position_y = -20.0f;
                    else
                        position_y = -6.5f;
                    spawnRotation = Quaternion.Euler(0, 0, 180f);
                }

                Vector3 spawnPosition = new Vector3(spawnValue.x, position_y, spawnValue.z);
                Instantiate(m_reef[index_reef], spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }

            // CALCULATE NEW REEF_COUNT
            m_reefCount = Random.Range(1, 11);
            if (m_reefCount == 7)
                time_to_show_shark = true;

            if (time_to_show_shark)
            {
                waveWait = sharkWait;
                Quaternion spawnRotation = new Quaternion();
                spawnRotation = Quaternion.Euler(0, 180f, 0);
                Vector3 spawnPosition = new Vector3(spawnValue.x + 80, 0.0f, spawnValue.z);
                Instantiate(shark, spawnPosition, spawnRotation);
            }
            else
            {
                waveWait = default_wait;
            }
            yield return new WaitForSeconds(waveWait);
        }  
    }
}
