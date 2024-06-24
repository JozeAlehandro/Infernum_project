using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Bomb : MonoBehaviour
{
    public GameObject ClosedRedCrate, OpenedRedCrate, Boom;
    public Renderer bomba;
    public float timeForDestroy;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Ground")
        {
            Boom.SetActive(true);
            bomba = GetComponent<Renderer>();
            bomba.sortingOrder = -1000;
            StartCoroutine(waitForDestroy());
        }
        IEnumerator waitForDestroy()
        {
            yield return new WaitForSeconds(timeForDestroy);
            Destroy(this.gameObject);
        }
    }
}

