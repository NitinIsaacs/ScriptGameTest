using UnityEngine;

public class Script2 : MonoBehaviour
{
    //Public float variables, Assigned in inspector
    public float a;
    public float b;
    public float c;

    void Start()
    {
        //multiply b and c, then add a
        float total = a + (b * c);

        //Display total in console
        Debug.Log("Total: " + total);
    }
}