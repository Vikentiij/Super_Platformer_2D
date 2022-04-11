using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolLeftRight : MonoBehaviour
{

    [SerializeField] float moveTime = 2f;
    [SerializeField] float movementSpeed = 1f;

    float currentMoveTime;

    // Start is called before the first frame update
    void Start()
    {
        currentMoveTime = moveTime;

        // By default, enemy is faced right and starts moving right.
        // If we make the enemy to face left through negative X scale, invert the speed to start moving left.
        if (transform.localScale.x < 0)
            movementSpeed *= -1;
    }

    void FixedUpdate()
    {
        currentMoveTime -= Time.deltaTime;

        if (currentMoveTime > 0)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(movementSpeed, 0);
        }
        else
        {
            Flip();
            currentMoveTime = moveTime;
        }
    }

    void Flip()
    {
        movementSpeed *= -1;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
}
