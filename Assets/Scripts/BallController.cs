using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float speed;
    Rigidbody2D rb;
    Vector2 dir;

// NO USAR FUERZAS PARA MOVER
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dir = transform.position;
    }

    void Update()
    {
        //transform.Translate(dir.x , dir.y, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //rebota player
            dir = new Vector2(1 * speed * Time.deltaTime, 0);
        }

        if (collision.gameObject.CompareTag("Limit"))
        {
            // rebota
        }

        if (collision.gameObject.CompareTag("Arcs"))
        {
            // suma punto

        }
    }
}
