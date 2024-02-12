using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Player Movement")]
    public float playerSpeed = 1.1f;

    [Header("Player Animator & Gravity")]
    public CharacterController cC;

    private void Update()
    {
        PlayerMove();
    }

    private void  PlayerMove()
    {
        float horizontalAxis = Input.GetAxisRaw("Horizontal");
        float verticalAxis = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontalAxis,0f, verticalAxis).normalized;
        
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            cC.Move(direction.normalized * playerSpeed * Time.deltaTime);
        }

    }
}
