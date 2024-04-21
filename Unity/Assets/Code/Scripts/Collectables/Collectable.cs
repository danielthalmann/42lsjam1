using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum InsectType
{
    Blatte = 1,
    Coccinelle = 2,
    Giraffe = 3
}

public class Collectable : MonoBehaviour
{

    public InsectType type;

    public int scoreValue;

    public int bodyValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
