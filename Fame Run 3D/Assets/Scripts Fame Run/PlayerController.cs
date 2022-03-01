using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private float moveSpeedLR = 3;
    public static bool Move = false;

    public int directionBoundaries;
    
    private void Start()
    {

    } 
    private void Update()
    {
        if(Move)
        {
            TouchInputThings(); //ayrýlsýn diye koydum
        }
        
    }

   
    private void CharacterMove()
    {
        Move = true;
    }
    private void TouchInputThings()
    {
        transform.localPosition += Vector3.right * TouchInput.Instance.horizontal * moveSpeedLR * Time.deltaTime;
        float xPos = Mathf.Clamp(transform.localPosition.x, -directionBoundaries, directionBoundaries);

        transform.localPosition = new Vector3(xPos, transform.localPosition.y, transform.localPosition.z);
    }
    private void Win()
    {
        Move = false;
    }

    private void Lose()
    {
        Move = false;
    }
    private void OnEnable()
    {
        GameManager.OnGameStart += CharacterMove;
        GameManager.OnGameWin += Win;
        GameManager.OnGameLose += Lose;
    }

    private void OnDisable()
    {
        GameManager.OnGameStart -= CharacterMove;
        GameManager.OnGameWin -= Win;
        GameManager.OnGameLose -= Lose;
    }
}
