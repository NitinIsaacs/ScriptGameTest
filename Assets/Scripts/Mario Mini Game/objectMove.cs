using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public Vector3 startingPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 1; i++)
        {
            this.transform.position = Vector3.right;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
