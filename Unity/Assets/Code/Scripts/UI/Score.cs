using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using static GameManager;

public class Score : MonoBehaviour
{
    public TMP_Text textComponent;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.onCollacteChange += this.onCollected;
        GameManager.instance.onStateChange += OnStateChange;
    }

    void OnStateChange(GameState state)
    {
        Debug.Log(state);
        if (state == GameState.loose)
        {
            this.gameObject.SetActive(false);
        }
    }

    void onCollected(int value)
    {
        this.textComponent.text = "Score:" + GameManager.instance.collected.ToString();
    }
}
