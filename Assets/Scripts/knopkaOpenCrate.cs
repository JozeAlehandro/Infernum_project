using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knopkaOpenCrate : MonoBehaviour
{
    public GameObject ClosedRedCrate, OpenedRedCrate, Bomb;
    public float timeToOpenCrate;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(waitForOpen());
            IEnumerator waitForOpen()
            {
                yield return new WaitForSeconds(timeToOpenCrate);
                OpenedRedCrate.SetActive(true);
                ClosedRedCrate.SetActive(false);
                Bomb.SetActive(true);
                GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
}
