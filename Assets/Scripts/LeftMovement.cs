using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMovement : MonoBehaviour
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
        var min = transform.position.x - 1.7;
        var max = transform.position.x + 0.6;

        var direction = Mathf.Sign(speed);

        while (true)
        {
            if (transform.position.x > max && direction > 0.0f)
            {
                direction = -direction;
            }
            else if (transform.position.x < min && direction < 0.0f)
            {
                direction = -direction;
            }

            rb2d.velocity = new Vector2(speed * direction, rb2d.velocity.y);

            yield return null;
        }
    }
}
