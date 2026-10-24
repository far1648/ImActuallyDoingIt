using System;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    public Vector2 PointerPosition { get ; set ;}
    private void Update()
    {
        Vector2 direction = (PointerPosition-(Vector2)transform.position).normalized;
        transform.right = direction;
        
        Vector2 scale = transform.localScale;
        if (direction.x < 0)
        {
            scale.y = -0.5f;
        } else if (direction.x > 0)
        {
            scale.y = 0.5f;
        }
        transform.localScale = scale;
    }
}
