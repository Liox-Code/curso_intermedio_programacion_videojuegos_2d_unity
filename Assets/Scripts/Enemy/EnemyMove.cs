using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform target;

    [SerializeField] int speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 direction = target.position - transform.position;
        rb.velocity = (Vector3)direction.normalized * speed ;
    }
}
