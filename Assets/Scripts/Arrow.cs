using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        StartCoroutine(c_Move());
    }

    IEnumerator c_Move()
    {
        var direction = Mathf.Sign(speed);

        while (true)
        {
            rb2d.velocity = new Vector2(speed * direction, rb2d.velocity.y);
            yield return null;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}