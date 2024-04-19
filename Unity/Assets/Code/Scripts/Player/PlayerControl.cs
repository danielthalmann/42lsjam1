using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using 

public class PlayerControl : MonoBehaviour
{

    public Rigidbody rb;

    public float moveSpeed = 1f;

    public InputActionReference move;

    private Vector2 cylindricalMoveDirection = new Vector2(1.0, 0.0);

    public Vector2 cylindricalPosition = Vector2.zero;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        cylindricalMoveDirection = move.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        velocity = moveDirection * moveSpeed;
        


    }
}
