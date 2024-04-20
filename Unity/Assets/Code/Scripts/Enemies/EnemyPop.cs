using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPop : MonoBehaviour
{

    public MapController map;
    public GameObject[] bugs;
    

    private int bugIndex = 0;


    /// <summary>
    /// Crée un bug aléatoirement
    /// </summary>
    public void PopBug()
    {

        float maxWidth = 2 * Mathf.PI * map.mapRadius;
        float maxHeight = map.mapHeight;

        Vector2 newPos = new Vector2 (Random.Range(0, maxWidth), Random.Range(0.1f, maxHeight - 0.1f));

        // Instantiate(bugs[bugIndex], map.To3dVector(newPos), map.ToQuaternion(newPos));

    }

}
