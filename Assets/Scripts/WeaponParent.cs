using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    public Vector2 PointerPosition { get ; set ;}

    private void Update()
    {
        transform.right = (PointerPosition-(Vector2)transform.position.normalized);
                
    }
}
