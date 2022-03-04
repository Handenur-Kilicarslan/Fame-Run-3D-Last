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

        Debug.Log("Bura çalýþýyor mudur acabasýýýý");
    }

    private void Lose()
    {
        Move = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("EndTrigger"))
        {
            Debug.Log("End Trigger'a çarptýk GameWin i uyandýr");

            GameManager.OnGameWin?.Invoke(); 
            Win();
        }

        if(other.TryGetComponent(out Collectable collectable))
        {
            Debug.Log("Ruj topladýk");
            Destroy(other.gameObject);
            UIManager.Instance.UpdateScore(collectable.famePoint);
        }

        if(other.TryGetComponent(out DoorInfo door))
        {
            Debug.Log("This is door");
            UIManager.Instance.UpdateScore(door.doorFamePoint);
            transform.Rotate(Vector3.up * 50 * Time.deltaTime, Space.Self);
            //rotate it
        }
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
