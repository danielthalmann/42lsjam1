using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class ApertureController : MonoBehaviour
{
    public Animator animatorFadeIn;



    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.onStateChange += OnStateChange;
    }

    // Update is called once per frame
    void Update()
    {
                
    }

    void OnStateChange(GameState state)
    {
        if (state == GameState.init)
        {
            animatorFadeIn.SetTrigger("FadeIn");
        }
    }


}
