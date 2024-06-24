using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKamney : MonoBehaviour
{
    public GameObject kamen, spawn;
    public Vector3 startPointPosition;
    public float randomPlace;

    void Start()
    {
        startPointPosition = gameObject.transform.position;
        InvokeRepeating("SpawnKamen", 3f, 1f);
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

    void SpawnKamen()
    {
        randomPlace = Random.Range(-25f, 9f);
        startPointPosition.x = randomPlace;
        Instantiate(kamen, startPointPosition, Quaternion.identity);
    }
}
