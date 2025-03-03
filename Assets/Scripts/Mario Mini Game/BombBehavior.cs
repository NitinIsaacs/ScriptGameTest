using UnityEngine;

public class BombBehavior : MonoBehaviour
{
     // to destroy the bomb
    public void Explode()
    {
        Destroy(gameObject);
    }
}
