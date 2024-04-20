using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class PauseController : MonoBehaviour
{

    public GameObject panel; 
    public InputActionReference escape;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!panel.activeSelf && escape.action.ReadValue<float>() == 1.0f)
        {
            panel.SetActive(true);
            Time.timeScale = 0.0f;
        };
    }

    public void Resume()
    {
        panel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Leave()
    {
        GameManager.instance.loadLevel("Menu");
    }

    public void OnApplicationPause(bool pause)
    {
        
    }
}
