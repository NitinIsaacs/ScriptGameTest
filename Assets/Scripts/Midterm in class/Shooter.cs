using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletForce = 500f;
    public Transform bulletSpawnPosition;

    void Update()
    {
        // Check if left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Spawn a bullet at bulletSpawnPosition
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPosition.position, bulletSpawnPosition.rotation);

            // Get Rigidbody component of bullet and apply a forward force
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.AddForce(bulletSpawnPosition.forward * bulletForce, ForceMode.Impulse);

            // Destroy the bullet after 3 seconds
            Destroy(bullet, 3f);
        }
    }
}
