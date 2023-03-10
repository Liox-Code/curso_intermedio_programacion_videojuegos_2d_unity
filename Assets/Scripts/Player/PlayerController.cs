using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    private float movementX;
    private float movementY;

    [SerializeField] private float speed;
    [SerializeField] private int rotationSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private GameObject bullet;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnFire()
    {
        SoundManager.instance.PlayShoot();
        GameObject go = Instantiate(bullet);
        go.transform.position = transform.position;
        go.transform.rotation = transform.rotation;
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        //Movement
        //rb.velocity = new Vector2(movementX, movementY) * speed;

        //Movement && Rotation
        rb.rotation -= movementX * rotationSpeed;
        speed = Mathf.Clamp(speed + movementY,1.5f,maxSpeed);
        rb.velocity = transform.up * speed;
        //Debug.Log($"{rb.rotation} -= {movementX} * {rotationSpeed}");
        //Debug.Log($"{speed} = value{speed + movementY} * min {1.5f} max{maxSpeed}");

    }
}
