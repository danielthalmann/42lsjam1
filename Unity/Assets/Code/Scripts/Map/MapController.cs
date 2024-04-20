using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.Universal.ShaderGUI;
using UnityEngine;

public class MapController : MonoBehaviour
{

    public float mapRadius = 1.0f;
    public float mapHeight = 1.0f;

    public Vector2 mapStartPoint = Vector2.zero;

    void Awake() {
        this.transform.localScale = new Vector3(mapRadius, mapHeight, mapRadius);
    }

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

            startPosition = (transform.rotation * ((transform.position + radius) - new Vector3(0, mapHeight, 0) - transform.position)) + transform.position;
            endPosition = (transform.rotation * (transform.position + radius + new Vector3(0, mapHeight, 0) - transform.position)) + transform.position;

            Gizmos.DrawLine(startPosition, endPosition);
        }

        Gizmos.color = Color.blue;

        (Vector3 position, Vector3 normal) = cylindricalTo3d(mapStartPoint);
        Gizmos.DrawSphere(position, .1f);


    }


    // 1st return Vector is the XYZ position on the cylinder
    // 2nd return Vector is the normal vector at this point.
    public (Vector3, Vector3) cylindricalTo3d(Vector2 position)
    {

        float angle = (position.x / mapRadius) ;

        Vector3 radius = (new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle))) * mapRadius;

        Vector3 position3d = (transform.rotation * (transform.position + radius + new Vector3(0, position.y, 0) - transform.position)) + transform.position;
        
        // FIXME: Works only when the cylinder is oriented in the x-axis direction
        Vector3 normal_vector = position3d - transform.position;
        normal_vector.x = 0.0f;

        // Lets switch to the simple case of the cylinder oriented to the Y axis:
        Vector3 simplePosition = Quaternion.Inverse(transform.rotation) * position3d;
        Vector3 simpleNormale = new Vector3(simplePosition.x, 0, simplePosition.z);
        // Switch back to rotated cylinder
        Vector3 normalVector =  transform.rotation * simpleNormale;

        return (position3d, normalVector.normalized);

    }



}
