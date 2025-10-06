using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
public class PlayerController : MonoBehaviourPunCallbacks
{
    [Header("Speed")]
    [SerializeField, Min(1)] private float speed;
    
    [Header("References")]
    [SerializeField] private BallController ball;
    [SerializeField, Min(0.1f)] private float yOffset; // margen para que no se salga
    
    private Vector2 movDirection;
    private float inputY;
    private float yLimit;
    
    private SpriteRenderer spriteRenderer;
    
    private void Start()
    {
        float cameraHeight = Camera.main.orthographicSize;  // uso el tamaño de la camara para setear el limite
        yLimit = cameraHeight - yOffset;        // le resto un offset
    }
    
    private void Update()
    {
        if (photonView.IsMine)
        { 
            inputY = Input.GetAxisRaw("Vertical");
    
            transform.Translate(0, inputY * speed * Time.deltaTime, 0);
    
            float clampedY = Mathf.Clamp(transform.position.y, -yLimit, yLimit); // clampeo, limito la posicion en y entre los limites de la camara
            transform.position = new Vector3(transform.position.x, clampedY, transform.position.z); 
    
            movDirection = new Vector2(0, inputY).normalized;
        }
          
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ball.ModifyDir(movDirection);
        }
    }

    public void ChangeColor(Color newColor) // Podes elegir el color al empezar a jugar
    {
        spriteRenderer.color = newColor;
    }

    public void MultiplayerSet()
    {
        // Reduce el tamaño de la paleta asi hay 2 jugadores x equipo
    }
}
