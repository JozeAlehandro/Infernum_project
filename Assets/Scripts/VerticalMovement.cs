using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    public float speed = 10f, diapason = 10f, timer;
    public bool onlyUp = false;

    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        StartCoroutine(c_Move());
    }

    IEnumerator c_Move()
    {
        var min = transform.position.y;
        var max = transform.position.y + diapason;

        var direction = Mathf.Sign(speed);
        rb2d.constraints = RigidbodyConstraints2D.FreezePosition;
        yield return new WaitForSeconds(timer);
        rb2d.constraints = RigidbodyConstraints2D.FreezePositionX;
        if (onlyUp)
        {
            while (true)
            {
                if (transform.position.y < min && direction < 0.0f)
                {
                    direction = -direction;
                }

                rb2d.velocity = new Vector2(speed * direction, rb2d.velocity.x);

                yield return null;
            }
        }
        else
        {
            while (true)
            {
                if (transform.position.y > max && direction > 0.0f)
                {
                    direction = -direction;
                }
                else if (transform.position.y < min && direction < 0.0f)
                {
                    direction = -direction;
                }

                rb2d.velocity = new Vector2(speed * direction, rb2d.velocity.x);

                yield return null;
            }
        }
    }
}
