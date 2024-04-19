using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements; 

public class PlayerControl : MonoBehaviour
{

    public Rigidbody rb;

    public MapController map;

    public float moveSpeed = 0.01f;

    public float turningSpeed = 0.07f;

    public InputActionReference move;   

    private Vector2 cylindricalMoveDirection = new Vector2(1.0f, 1.0f).normalized;

    private Vector2 cylindricalPosition = Vector2.zero;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // We are only interested in the X value of the vector: left or right
        // A negative value indicate to turn left
        // A positive value indicate to turn right
        Vector2 playerMovement = move.action.ReadValue<Vector2>();
        float turningSpeed = 0.07f;
        float turnAngleRad = - turningSpeed * playerMovement.x;
        cylindricalMoveDirection = new Vector2(
        cylindricalMoveDirection.x * Mathf.Cos(turnAngleRad) - cylindricalMoveDirection.y * Mathf.Sin(turnAngleRad),
        cylindricalMoveDirection.x * Mathf.Sin(turnAngleRad) + cylindricalMoveDirection.y * Mathf.Cos(turnAngleRad)
        ).normalized;            
    }

    private void FixedUpdate()
    {
        
        Vector2 velocity = cylindricalMoveDirection * moveSpeed;
        cylindricalPosition += velocity;

        Vector3 newPosition = map.To3dVector(cylindricalPosition);

        transform.position = newPosition;
        


    }
}
