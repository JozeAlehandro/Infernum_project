using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCirkulyarki : MonoBehaviour
{
    public GameObject cirkulyarka, spawn;
    public Vector3 startPointPosition;
    public float randomPlace;

    void Start()
    {
        startPointPosition = gameObject.transform.position;
        InvokeRepeating("SpawnCirkulyarka", 3f, 0.7f);
        StartCoroutine(waitForTimer());
        IEnumerator waitForTimer()
        {
            yield return new WaitForSeconds(59);
            Destroy(spawn);
        }
    }

    void Update()
    {

    }

    void SpawnCirkulyarka()
    {
        randomPlace = Random.Range(-2.35f, 26.5f);
        startPointPosition.y = randomPlace; 
        Instantiate(cirkulyarka, startPointPosition, Quaternion.identity);
    }
}
