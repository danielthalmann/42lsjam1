using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Score : MonoBehaviour
{
    public TMP_Text textComponent;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.onCollacteChange += this.onCollected;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onCollected(int value)
    {
        this.textComponent.text = "Score2:" + GameManager.instance.collected.ToString();
    }
}
