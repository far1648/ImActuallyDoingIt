using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float speed = 1.0f;

    public Vector3 offset;
    private Vector3 targetPos;
    Player player;
    void Start()
    {
        if (target == null) return;

        offset = transform.position - target.position;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        if (target == null) return;

        if (player.lari == true)
        {
            speed = 2;
        } else
        {
            speed = 1;
        }

        targetPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);
    }
}
