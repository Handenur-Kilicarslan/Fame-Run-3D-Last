using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    private Animator playerAnimation;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IdleToStart()
    {
       playerAnimation.SetBool("IdleToStart", true);
    }

    private void OnEnable()
    {
        GameManager.OnGameStart += IdleToStart;
       // GameManager.OnGameWin += Win;
       // GameManager.OnGameLose += Lose;
    }

    private void OnDisable()
    {
        //GameManager.OnGameStart -= CharacterMove;
       // GameManager.OnGameWin -= Win;
        //GameManager.OnGameLose -= Lose;
    }
}
