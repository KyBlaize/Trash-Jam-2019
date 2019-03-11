using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = 10;
    public int Health = 5;
    public int Ammo = 0;
    public LayerMask LayersToCollide;

    private bool grounded = false;
    private float groundedDistance = 0.1f;
    private float xDirection = 0f;
    private float yDirection = 0f;
    private float groundPoint;
    private Vector3 direction;
    private Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        xDirection = Input.GetAxis("Horizontal");
        direction = new Vector3(xDirection,yDirection);
    }

    private void FixedUpdate()
    {
        CheckForGround();
        Debug.DrawRay(transform.position,Vector3.down*15,Color.red);
        Move();
    }

    private void Move()
    {
        rigidbody.transform.Translate((direction * MoveSpeed) * Time.deltaTime);
    }

    private void CheckForGround()
    {
        RaycastHit2D _hit = Physics2D.Raycast(transform.position,Vector2.down,15,LayersToCollide);
        if (_hit && transform.position.y <= _hit.point.y+1f)
        {
            Debug.Log("pos y: "+transform.position.y +", hit pos: "+ _hit.point.y);
            yDirection = 0;
            grounded = true;
        }
        else
        {
            ApplyGravity();
            grounded = false;
        }
    }

    private void ApplyGravity()
    {
        yDirection -= 0.075f;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        PickUpFruit _fruit = collision.gameObject.GetComponent<PickUpFruit>();
        Ammo = Mathf.RoundToInt(_fruit.Fruit.Value);
        Debug.Log("I got "+Ammo+" bullets!");
        collision.gameObject.SetActive(false);
    }
}
