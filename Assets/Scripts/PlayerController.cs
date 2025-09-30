using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private float inputY;
    private Vector2 vector;

    private void Update()
    {
        inputY = Input.GetAxisRaw("Vertical");

        transform.Translate(0, inputY * speed * Time.deltaTime, 0);
    }
}
