using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{

    public float mapRadiusBottom = 1.0f;

    public float mapRadiusTop = 1.0f;
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
            Vector3 radiusTop = (new Vector3(Mathf.Cos(angle * i), 0, Mathf.Sin(angle * i))) * mapRadiusTop;
            Vector3 radiusBottom = (new Vector3(Mathf.Cos(angle * i), 0, Mathf.Sin(angle * i))) * mapRadiusBottom;

            startPosition = (transform.rotation * ((transform.position + radiusBottom) - transform.position)) + transform.position;
            endPosition = (transform.rotation * (transform.position + radiusTop + new Vector3(0, mapHeight, 0) - transform.position)) + transform.position;

            Gizmos.DrawLine(startPosition, endPosition);
        }

        Gizmos.color = Color.blue;

        (Vector3 position, Vector3 normal) = cylindricalTo3d(mapStartPoint);
        Gizmos.DrawSphere(position, .1f);


    }


    // cylPosition represents the UV coordinates on the "flattened" cylinder.
    //
    // 1st return Vector is the XYZ position on the cylinder
    // 2nd return Vector is the normal vector at this point.
    public (Vector3, Vector3) cylindricalTo3d(Vector2 flattenCylPosition)
    {
        float z = flattenCylPosition.y;
        float rho = mapRadiusBottom + z / mapHeight * mapRadiusTop / mapRadiusBottom;
        
        float phi = (flattenCylPosition.x / rho) ;
        

        Vector3 position3d = new Vector3(rho*Mathf.Cos(phi), z, rho * Mathf.Sin(phi));
        position3d = transform.rotation * position3d;
        position3d += transform.position;

        // Lets switch to the simple case of the cylinder, centered and oriented to the Y axis:
        Quaternion rot_inv = Quaternion.Inverse(transform.rotation);
        Vector3 simplePosition = rot_inv * (position3d - transform.position);
        Vector3 simpleNormale = new Vector3(simplePosition.x, 0, simplePosition.z);
        // Switch back to rotated cylinder
        Vector3 normalVector =  transform.rotation * simpleNormale;

        return (position3d, normalVector.normalized);

    }



}
