using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform player;
    public GameObject angrity;
    float randomX, randomY;
    int x, y;
    [SerializeField] float time = 2f;
    [SerializeField] float timer;
    Vector2 pos;
    void Start()
    {
        timer = time;
    }

    // Update is called once per frame
    void Update()
    {
        pos = new Vector2(player.position.x, player.position.y);
        x = UnityEngine.Random.Range(0,2);
        y = UnityEngine.Random.Range(0,2);
        randomX = UnityEngine.Random.Range(10f, 20f);
        randomY = UnityEngine.Random.Range(10f, 20f);
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (x == 0 && y == 0)
            {
                Instantiate(angrity, new Vector2(pos.x - randomX, pos.y - randomY), Quaternion.identity);
            }
            if (x == 1 && y == 0)
            {
                Instantiate(angrity, new Vector2(pos.x + randomX, pos.y - randomY), Quaternion.identity);
            }
            if (x == 0 && y == 1)
            {
                Instantiate(angrity, new Vector2(pos.x - randomX, pos.y + randomY), Quaternion.identity);
            }
            if (x == 1 && y == 1)
            {
                Instantiate(angrity, new Vector2(pos.x + randomX, pos.y + randomY), Quaternion.identity);
            }
            Debug.Log(x + ", " + y + ", " + pos.x + ", " + randomX + ", " + pos.y + ", " + randomY);
            timer = time;
        }

    }
}
