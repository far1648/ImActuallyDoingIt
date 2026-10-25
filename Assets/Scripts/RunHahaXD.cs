using UnityEngine;

public class RunHahaXD : MonoBehaviour
{
    public float detectRad = 2f;
    public float moveDis = 3f;

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;

        float distance = Vector2.Distance(transform.position, mousePos);

        if (distance < detectRad)
        {
            Vector2 dir = (Vector2)transform.position - (Vector2)mousePos;

            if (dir.sqrMagnitude > 0.001f)
            {
                dir.Normalize();
                transform.position += (Vector3)(dir*moveDis);
            }
        }
    }
}
