using System;
using UnityEngine;

public class BulletMechanic : MonoBehaviour
{
    float timer = 5.0f;
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Angrity")
        {
            Destroy(gameObject);
        }
    }
}
