using UnityEngine;

public class BallController: MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector2 dir = Vector2.left;
    private Vector2 startPos;
    private GameManager gameManager;

    private void Start()
    {
        startPos = transform.position;
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }

    public Vector2 ModifyDir(Vector2 direction)
    {
       dir = new Vector2(dir.x,direction.y).normalized;
       return dir;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dir = Vector2.Reflect(dir,-dir).normalized;
        }
        
        if (other.gameObject.CompareTag("Limit"))
        {
            if (other.transform.position.y > transform.position.y)  // limite de arriba
            {
                dir = Vector2.Reflect(dir,Vector2.down).normalized;
            }
            else
            {
                dir = Vector2.Reflect(dir,Vector2.up).normalized;
            }                                                       // limite de abajo
        }
        
        if (other.gameObject.CompareTag("ArcLeft"))
        {
            RestartPosition();
            gameManager.AddPointsGreen(1);
        }

        if (other.gameObject.CompareTag("ArcRight"))
        {
            RestartPosition();
            gameManager.AddPointsRed(1);
        }
    }

    void RestartPosition()
    {
        transform.position = startPos;
       // dir = Random.Range(0, 2) == 0 ? new Vector2(-1, -1).normalized : new Vector2(1, 1).normalized;        // buscar forma de que no sea siempre arriba o abajo
        dir = Random.Range(0, 2) == 0 ? Vector2.left : Vector2.right;   // respawn aleatorio
    }
}
