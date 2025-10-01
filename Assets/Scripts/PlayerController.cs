using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private float inputY;
    public BallController ball;
    private Vector2 movDirection;
    
    private void Update()
    {
        inputY = Input.GetAxisRaw("Vertical");

        transform.Translate(0, inputY * speed * Time.deltaTime, 0);
        movDirection = new Vector2(0, inputY).normalized;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ball.ModifyDir(movDirection);
        }
    }
}
