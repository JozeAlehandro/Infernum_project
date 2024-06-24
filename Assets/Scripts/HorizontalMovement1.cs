using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement1 : MonoBehaviour
{
    public float speed = 10f;
    public float diapason = 10f;
    public bool moveLeft, moveRight;

    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        StartCoroutine(c_Move());
    }

    IEnumerator c_Move()
    {
        if(moveLeft && moveRight)
        {
            var min = transform.position.x - diapason;
            var max = transform.position.x + diapason;

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
        else if (moveLeft)
        {
            var direction = Mathf.Sign(speed);
            while (true)
            {

                rb2d.velocity = new Vector2(speed * -direction, rb2d.velocity.y);

                yield return null;
            }
        }
        else if (moveRight)
        {
            var direction = Mathf.Sign(speed);
            while (true)
            {

                rb2d.velocity = new Vector2(speed * direction, rb2d.velocity.y);

                yield return null;
            }
        }
    }
}
