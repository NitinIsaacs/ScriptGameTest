using UnityEngine;

public class KnockOver : MonoBehaviour
{
    public GameObject objectToFall;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            objectToFall.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
