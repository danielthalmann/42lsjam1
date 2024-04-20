using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameManager;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public delegate void OnCollectableChange(int value);
    public OnCollectableChange onCollacteChange;

    public delegate void OnStateChange(GameState state);
    public OnStateChange onStateChange;

    public int collected = 0;

    public enum GameState
    {
        init,
        start,
        win,
        loose
    }

    public GameState state = GameState.init;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        InitGame();
    }

    // Update is called once per frame
    void Update()
    {
                
    }

    /// <summary>
    /// Quit l'application
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }

    /// <summary>
    /// Charge un nouveau niveau
    /// </summary>
    /// <param name="level"></param>
    public void loadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    /// <summary>
    /// Effectue 
    /// </summary>
    /// <param name="newState"></param>
    public void ChangeState(GameState newState)
    {
        state = newState;
        onStateChange?.Invoke(state);
    }

    /// <summary>
    /// initialise le jeu
    /// </summary>
    public void InitGame()
    {
        collected = 0;
        ChangeState(GameState.init);
    }

    /// <summary>
    /// Indique que le jeu est perdu
    /// </summary>
    public void GameLoose()
    {
        ChangeState(GameState.loose);
    }

    /// <summary>
    /// indique le nombre d'élément collecté
    /// </summary>
    /// <param name="value"></param>
    public void Collecte(int value = 1)
    {
        collected += value;
        onCollacteChange?.Invoke(collected);
    }


}
