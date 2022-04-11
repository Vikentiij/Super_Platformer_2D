using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10f;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * speed  * -1;
    }

    void OnTriggerEnter2D(Collider2D hitInfo) {
        Destroy(gameObject);
    }
}
