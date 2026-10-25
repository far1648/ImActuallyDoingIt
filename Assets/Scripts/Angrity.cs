using UnityEngine;

public class Angrity : MonoBehaviour
{
    public Transform player;
    Rigidbody2D Rb;
    float moveSpeed = 3f;
    float randomX, randomY;
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        randomX = Random.Range(-11.92f, 14.63f);
        randomY = Random.Range(-5.6f, 7.05f);
        transform.position = new Vector2(randomX, randomY);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
