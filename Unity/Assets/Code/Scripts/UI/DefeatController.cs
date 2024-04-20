using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;
using static GameManager;

public class DefeatController : MonoBehaviour
{

    public GameObject panelGame;
    public TMPro.TMP_Text score;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.onStateChange += OnStateChange;
    }

    void OnStateChange(GameState state)
    {
        Debug.Log(state);
        if (state == GameState.loose)
        {
            Defeat();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Defeat()
    {
        panelGame.SetActive(true);
        score.text = "Score : " + GameManager.instance.collected.ToString();
        Time.timeScale = 0.0f;
    }

    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Debug.Log(scene.name);

        panelGame.SetActive(false);
        Time.timeScale = 1.0f;

    }

    public void Leave()
    {
        GameManager.instance.loadLevel("Menu");
    }

}
