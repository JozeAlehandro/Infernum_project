using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public float diapason = 10f;

    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        StartCoroutine(c_Move());
    }

    IEnumerator c_Move()
    {
        var min = transform.position.x - diapason;
        var max = transform.position.x + diapason;

        var direction = Mathf.Sign(speed);

        while (true)
        {
            if (transform.position.x > max && direction > 0.0f)
            {
                direction = -direction;
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else if (transform.position.x < min && direction < 0.0f)
            {
                direction = -direction;
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }

            rb2d.velocity = new Vector2(speed * direction, rb2d.velocity.y);

            yield return null;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}