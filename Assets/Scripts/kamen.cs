using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamen : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "DieSpace")
        {
            Destroy(this.gameObject);
        }
    }
}
