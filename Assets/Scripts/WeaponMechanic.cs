using UnityEngine;

public class WeaponMechanic : MonoBehaviour
{
    public GameObject bullet;
    public Transform pos;
    public Transform parent;
    public Camera cam;
    Vector2 mousePos;

    void Update()
    {
        if (parent.localScale.y < 0)
        {
            transform.localScale = new Vector2(1, -1);
        }
        else
        {
            transform.localScale = new Vector2(1, 1);
        }

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDir = mousePos - (Vector2)pos.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }
}
