using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private string playerTag;
    [SerializeField] private float plusY;
    [SerializeField][Range(0.5f, 7.5f)] private float movingSpeed = 1.5f;

    void Start()
    {
        if (this.playerTransform == null)
        {
            if (this.playerTag == "")
            {
                this.playerTag = "Player";
            }

            this.playerTransform = GameObject.FindGameObjectWithTag(this.playerTag).transform;
        }

        this.transform.position = new Vector3()
        {
            x = this.playerTransform.position.x,
            y = this.playerTransform.position.y + plusY,
            z = this.playerTransform.position.z - 10,
        };
    }

    private void Update()
    {
        if (this.playerTransform)
        {
            Vector3 target = new Vector3()
            {
                x = this.playerTransform.position.x,
                y = this.playerTransform.position.y + plusY,
                z = this.playerTransform.position.z - 10,
            };

            Vector3 pos = Vector3.Lerp(this.transform.position, target, this.movingSpeed * Time.deltaTime);

            this.transform.position = pos;
        }
    }
}
