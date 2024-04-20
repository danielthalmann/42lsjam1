using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static GameManager;

public class EnemyPop : MonoBehaviour
{

    public MapController map;
    public GameObject[] bugPrefabs;
    

    private int bugIndex = 0;

    private void Start()
    {
        if (map == null)
        {
            map = FindAnyObjectByType<MapController>();

        }
        GameManager.instance.onStateChange += OnStateChange;
        GameManager.instance.onCollacteChange += OnCollacteChange;

    }

    void OnStateChange(GameState state)
    {
        if (state == GameState.init)
        {
            SpawnCollectable();
        }
    }

    void OnCollacteChange(int value)
    {
        SpawnCollectable();
    }

    /// <summary>
    /// Crée un bug aléatoirement
    /// </summary>
    public void SpawnCollectable()
    {

        float maxWidth = 2 * Mathf.PI * map.mapRadius;
        float maxHeight = map.mapHeight;


        Vector2 newPos = new Vector2 (Random.Range(0, maxWidth), Random.Range(0.1f, maxHeight - 0.1f));

        (Vector3 newPosition, Vector3 normal) = map.cylindricalTo3d(newPos);
        Vector3 lookForwardTmp = (newPosition - transform.position).normalized;

        Vector3 lookUp = normal;
        Vector3 lookRight = Vector3.Cross(normal, lookForwardTmp).normalized;
        Vector3 lookForward = Vector3.Cross(lookRight, normal).normalized;
                
        Instantiate(bugPrefabs[bugIndex], newPosition, Quaternion.LookRotation(lookForward, normal));
        bugIndex++;
        bugIndex = bugIndex % bugPrefabs.Length;

    }

}
