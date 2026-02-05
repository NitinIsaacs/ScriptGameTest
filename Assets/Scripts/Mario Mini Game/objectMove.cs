using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public Vector3 startingPosition;
    
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