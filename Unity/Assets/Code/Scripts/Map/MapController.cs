using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{

    public float mapRadius = 1.0f;
    public float mapHeight = 1.0f;


    public Vector2 mapStartPoint = Vector2.zero;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawRay(transform.position, new Vector3(0, mapHeight, 0));
        Vector3 startPosition = transform.position;
        Vector3 endPosition = (transform.rotation * (transform.position + new Vector3(0, mapHeight, 0) - transform.position)) + transform.position;

        Gizmos.DrawLine(startPosition, endPosition);

        int segment = 16;
        float angle = (2 * Mathf.PI / segment);

        for (int i = 0; i < segment; i++)
        {   
            Vector3 radius = (new Vector3(Mathf.Cos(angle * i), 0, Mathf.Sin(angle * i))) * mapRadius;

            startPosition = (transform.rotation * ((transform.position + radius) - transform.position)) + transform.position;
            endPosition = (transform.rotation * (transform.position + radius + new Vector3(0, mapHeight, 0) - transform.position)) + transform.position;

            Gizmos.DrawLine(startPosition, endPosition);
        }

        Gizmos.color = Color.blue;

        Gizmos.DrawSphere(To3dVector(mapStartPoint), .1f);


    }


    public Vector3 To3dVector(Vector2 position)
    {

        float angle = (position.x / mapRadius) ;

        Vector3 radius = (new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle))) * mapRadius;

        return (transform.rotation * (transform.position + radius + new Vector3(0, position.y, 0) - transform.position)) + transform.position;

    }



}
