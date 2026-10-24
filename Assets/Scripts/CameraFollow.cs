using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float speed = 1.0f;

    public Vector3 offset;
    private Vector3 targetPos;
    void Start()
    {
        if (target == null) return;

        offset = transform.position - target.position;
    }

    void Update()
    {
        if (target == null) return;

        targetPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);
    }
}
