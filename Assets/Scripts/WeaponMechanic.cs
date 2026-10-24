using UnityEngine;

public class WeaponMechanic : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform pos;
    
    public Transform gunPoint;
    public float bulletForce = 20f;

    public Transform parent;
    public Camera cam;
    Vector2 mousePos;

    void Update()
    {
        NormalizeScale();
        NormalizeRotation();

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Rigidbody2D Rb = bullet.GetComponent<Rigidbody2D>();
        Rb.AddForce(gunPoint.right * bulletForce, ForceMode2D.Impulse);
    }

    void NormalizeScale()
    {
        if (parent.localScale.y < 0)
        {
            transform.localScale = new Vector2(1, -1);
        }
        else
        {
            transform.localScale = new Vector2(1, 1);
        }
    }
    void NormalizeRotation()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDir = mousePos - (Vector2)pos.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
