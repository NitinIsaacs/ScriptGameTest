using UnityEngine;

public class Script4 : MonoBehaviour
{
    //Public Vector3 variables
    public Vector3 position;
    public Vector3 movement;

    void Start()
    {
        transform.position = position;
    }

    void Update()
    {
        //Move the object every frame.
        //Multiplying by Time.deltaTime so its per second.
        transform.position += movement * Time.deltaTime;
    }
}