using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{

    public Rigidbody rb;

    public float moveSpeed = 1f;

    public InputActionReference move;

    private Vector3 moveDirection = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = move.action.ReadValue<Vector2>();

        moveDirection = new Vector3(direction.x, 0, direction.y);

    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection * moveSpeed;
    }
}
