using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knopkaArrowSpawn : MonoBehaviour
{
    public GameObject SpawnArrow;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SpawnArrow.SetActive(true);
        }
    }
}
