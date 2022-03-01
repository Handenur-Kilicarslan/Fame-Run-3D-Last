using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Swerwe Manager")]
    [SerializeField] private float swerveSpeed = 4f;
    [SerializeField] private float maxSwerveAmount = 4f;
    private SwerveInputSystem swerveInputSystem;

    [Header("Movement Variables")]
    [SerializeField] private float speed;

    private void Start()
    {
        swerveInputSystem = GetComponent<SwerveInputSystem>();
    }

    private void Update()
    {
        if(true)
        {
            MovementAndSwerwe();
        }
    }

    void MovementAndSwerwe()
    {
        #region Swerwe Movement
        float swerveAmount = Time.deltaTime * swerveSpeed * swerveInputSystem.MoveFactorX;
        swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
        transform.Translate(swerveAmount, 0, 0);
        #endregion

        //forward movement
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        
    }



}
